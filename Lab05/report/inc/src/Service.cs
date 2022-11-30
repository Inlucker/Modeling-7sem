class Service
{
	public Service(double _a, double _b)
	{
		a = _a;
		b = _b;
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
		double t_i = a + (b - a) * rnd.NextDouble();
		free_time = t + Math.Round(t_i, 2);
	}

	public double a;
	public double b;
	public double free_time = 0;

	private Random rnd = new Random();
}
