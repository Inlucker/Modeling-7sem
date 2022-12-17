using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04
{
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
			generated_n++;
			return new_r;
		}

		private void updateGenTime()
		{
			double res = a + (b - a) * rnd.NextDouble();
			gen_time += res;

			if (min_time == -1)
				min_time = res;
			else if (res < min_time)
				min_time = res;

			if (max_time == -1)
				max_time = res;
			else if (res > max_time)
				max_time = res;
		}

		public double a;
		public double b;
		public double gen_time = 0;
		public int generated_n = 0;

		private Random rnd = new Random();
		private double min_time = -1;
		private double max_time = -1;
	}
}
