class Service
{
	public Service(double l, int a)
	{
		lambda = l;
		alpha = a;
	}

	public bool isFree(double t)
	{
		return (t >= free_time);
	}

	public void serve(Request r, double t)
	{
		updateFreeTime(t);
		r.serve_time = free_time;
	}

	public void updateFreeTime(double t)
	{
		double res = 0;
		for (int i = 0; i < alpha; i++)
			res -= Math.Log(1 - rnd.NextDouble());
		res /= alpha * lambda;

		free_time = t + res;
	}

	public double lambda;
	public int alpha;
	public double free_time = 0;

	private Random rnd = new Random();
}