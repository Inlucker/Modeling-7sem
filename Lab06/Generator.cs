using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab06
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
			return new_r;
		}

		private void updateGenTime()
		{
			double t_i = a + (b - a) * rnd.NextDouble();
			gen_time += Math.Round(t_i, 2);
		}

		public double a;
		public double b;
		public double gen_time = 0;

		private Random rnd = new Random();
	}
}
