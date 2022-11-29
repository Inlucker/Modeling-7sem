using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04
{
	class EventModel
	{
		public EventModel(double _a, double _b, double l, int al, double fb = 0)
		{
			generator = new Generator(_a, _b);
			req_que = new ReqQue();
			service = new Service(l, al);
			feedback = fb;
		}

		public int getMaxBufSize(double maxT = 1e6)
		{
			overflow = true;
			curT = 0;
			while (curT <= maxT)
			{
				if (no_overflow_time >= 1e5)
					overflow = false;
				/*if (no_overflow_n >= 1e5)
					overflow = false;*/
				handleGenerator();
				handleService();
				no_overflow_time += times.Min() - curT;
				curT = times.Min();
				times.Remove(curT);
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
				{
					no_overflow_time = 0;
					no_overflow_n = 0;
				}
				times.Add(generator.gen_time);
			}
		}

		private void handleService()
		{
			if (req_que.Count != 0 && service.isFree(curT))
			{
				Request r = req_que.pop();
				no_overflow_n++;
				service.serve(r, curT);
				times.Add(service.free_time);

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
		public double no_overflow_time = 0;
		public bool overflow = true;
		public double no_overflow_n = 0;

		private Random rnd = new Random();
		private List<double> times = new List<double>();
	}
}
