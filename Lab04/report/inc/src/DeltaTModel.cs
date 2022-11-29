class DeltaTModel
{
	public DeltaTModel(double _a, double _b, double l, int al, double fb = 0)
	{
		generator = new Generator(_a, _b);
		req_que = new ReqQue();
		service = new Service(l, al);
		feedback = fb;
	}

	public int getMaxBufSize(double dT = 0.01, double maxT = 1e6)
	{
		overflow = true;
		while (curT <= maxT)
		{
			if (no_overflow_n >= 1e5)
				overflow = false;
			handleGenerator();
			handleService();
			curT += dT;
		}
		if (overflow)
			return -1;
		else
			return req_que.max_size;
	}

	private void handleGenerator()
	{
		if (generator.isReady(curT))
		{
			Request new_r = generator.genRequest();
			if (req_que.push(new_r))
				no_overflow_n = 0;
		}
	}
	
	

	private void handleService()
	{
		if (req_que.Count != 0 && service.isFree(curT))
		{
			Request r = req_que.pop();
			no_overflow_n++;
			service.serve(r, curT);

			if (rnd.NextDouble() < feedback)
			{
				Request old_r = new Request(curT);
				req_que.push(old_r);
			}
		}
	}

	public Generator generator;
	public ReqQue req_que;
	public Service service;
	public double feedback;
	public double curT = 0;
	public double no_overflow_n = 0;
	public bool overflow = true;

	private Random rnd = new Random();
}
