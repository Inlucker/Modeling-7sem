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

			service_util = service.working_time / curT;
			cur_que_size = req_que.Count();
			avg_que_time_zero = avg_que_time / (service.served_n - que_entry_zero);
			avg_que_time /= service.served_n;
			avg_serve_time = service.working_time / service.served_n;
			avg_gen_time = curT / generator.generated_n;

			printResults();

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
				if (r.create_time == curT)
					que_entry_zero++;
				avg_que_time += curT - r.create_time;
				no_overflow_n++;
				service.serve(r, curT);
				times.Add(service.free_time);

				if (rnd.NextDouble() < feedback)
				{
					Request old_r = new Request(service.free_time);
					req_que.push(old_r);
				}
			}
		}

		private void printResults()
		{
			Console.WriteLine("\nENDTIME = " + curT);
			Console.WriteLine("SERVICE:");
			Console.WriteLine("ENTRIES = " + service.served_n);
			Console.WriteLine("UTIL. = " + service_util);
			Console.WriteLine("AVE. TIME = " + avg_serve_time);
			Console.WriteLine("AVAIL. = " + service.isFree(curT));
			Console.WriteLine("REQQUE:");
			Console.WriteLine("MAX = " + req_que.max_size);
			Console.WriteLine("CONT. = " + cur_que_size);
			Console.WriteLine("ENTRY = " + req_que.que_entry);
			Console.WriteLine("ENTRY(0) = " + que_entry_zero);
			//Console.WriteLine("AVE CONT. = " + avg_que_size);
			Console.WriteLine("AVE TIME. = " + avg_que_time);
			Console.WriteLine("AVE.(-0) = " + avg_que_time_zero);
		}

		public Generator generator;
		public ReqQue req_que;
		public Service service;
		public double feedback;
		public double curT = 0;
		public double no_overflow_time = 0;
		public bool overflow = true;
		public double no_overflow_n = 0;

		public int cur_que_size = 0;
		public double avg_que_size = 0;
		public double avg_que_time = 0;
		public double avg_que_time_zero = 0;
		public double avg_serve_time = 0;
		public double avg_gen_time = 0;
		public double service_util = 0;
		public int que_entry_zero = 0;

		private Random rnd = new Random();
		private List<double> times = new List<double>();
	}
}
