using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab06
{
	class Program
	{
		static void Main(string[] args)
		{
			EventModel model = new EventModel(120);

			for (int i = 0; i < 25; i++)
			{
				double p = model.getResults();
				Console.WriteLine(model.getResultsStr());
			}

			Console.WriteLine("Нажмите enter для завершения...");
			Console.ReadLine();
		}
	}
}
