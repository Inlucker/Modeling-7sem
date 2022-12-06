using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab06
{
	class EventModel
	{
		public EventModel(int _max_clients_n = max_default)
		{
			students = new Generator(0, 0);
			normcontrol_que = new ReqQue();
			normcontrol = new Service(3, 5, 0.7);
			protection_que = new ReqQue();
			comissions = new List<Service> { new Service(5, 10, 0.9), new Service(30, 40, 0.1) };
			max_students_n = _max_clients_n;
		}

		public double getResults()
		{
			reset();

			while (events.Count > 0)
			{
				BaseEvent e = events[0];
				events.RemoveAt(0);

				end_time = e.time;
				e.Handle(this);
			}

			return (double)refused_n / (refused_n + passed_n);
		}

		public void addEvent(BaseEvent e)
		{
			events.Add(e);
			events.Sort();
		}

		public string getResultsStr()
		{
			string res = String.Format("Защитившихся студентов: {0:D} | ", this.passed_n);
			res += String.Format("Несдавших студентов: {0:D} | ", this.refused_n);
			res += String.Format("Вероятность сдачи: {0:F4} | ", Math.Round((double)passed_n / (refused_n + passed_n), 4));
			res += String.Format("Время моделирования: {0:F2} [мин] ", this.end_time);

			return res;
		}

		private void reset()
		{
			students.gen_time = 0;
			normcontrol_que.max_size = 0;
			normcontrol.free_time = 0;
			protection_que.max_size = 0;
			for (int i = 0; i < comissions.Count; i++)
				comissions[i].free_time = 0;

			end_time = 0;
			refused_n = 0;
			passed_n = 0;

			students_n = 0;

			Request first_student = students.genRequest();
			events = new List<BaseEvent> { new EStudentCame(first_student) };
		}

		public Generator students;
		public ReqQue normcontrol_que;
		public Service normcontrol;
		public ReqQue protection_que;
		public List<Service> comissions;
		const int max_default = 120;
		public int max_students_n = max_default;
		public double end_time = 0;
		public int refused_n = 0;
		public int passed_n = 0;
		public int students_n = 0;

		private List<BaseEvent> events = new List<BaseEvent>();
	}
}
