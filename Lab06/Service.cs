using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab06
{
	class Service
	{
		public Service(double _a, double _b, double _p)
		{
			a = _a;
			b = _b;
			pass_prob = _p;
		}

		public bool isFree(double t)
		{
			return (t >= free_time);
		}

		public bool serve(Request r, double t)
		{
			updateFreeTime(t);
			double res = rnd.NextDouble();
			bool pass = res <= pass_prob;
			if (pass)
				r.serve_time = free_time;
			return pass;
		}

		public void updateFreeTime(double t)
		{
			double t_i = a + (b - a) * rnd.NextDouble();
			free_time = t + Math.Round(t_i, 2);
		}

		public double a;
		public double b;
		public double free_time = 0;
		public double pass_prob = 0;

		private Random rnd = new Random();
	}
}
