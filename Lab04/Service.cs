using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04
{
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
			served_n++;
			r.serve_time = free_time;
		}

		public void updateFreeTime(double t)
		{
			double res = 0;
			for (int i = 0; i < alpha; i++)
				res -= Math.Log(1 - rnd.NextDouble());
			res *= lambda;
			//res *= lambda / alpha;

			if (min_res == -1)
				min_res = res;
			else if (res < min_res)
				min_res = res;

			if (max_res == -1)
				max_res = res;
			else if (res > max_res)
				max_res = res;

			free_time = t + res;
			working_time += res;
		}

		public double lambda;
		public int alpha;
		public double free_time = 0;
		public int served_n = 0;
		public double working_time = 0;

		private Random rnd = new Random();
		private double min_res = -1;
		private double max_res = -1;
	}
}
