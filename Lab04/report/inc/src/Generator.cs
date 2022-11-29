class Generator
{
	public Generator(double _a, double _b)
	{
		a = _a;
		b = _b;
	}

	public bool isReady(double t)
	{
		return (t >= gen_time);
	}

	public Request genRequest()
	{
		Request new_r = new Request(gen_time);
		updateGenTime();
		return new_r;
	}

	private void updateGenTime()
	{
		double res = a + (b - a) * rnd.NextDouble();
		gen_time += res;
	}

	public double a;
	public double b;
	public double gen_time = 0;

	private Random rnd = new Random();
}