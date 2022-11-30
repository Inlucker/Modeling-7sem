using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05
{
	class Program
	{
		static void Main(string[] args)
		{
			EventModel model = new EventModel();

			for (int i = 0; i < 25; i++)
			{
				double p = model.getRefuseProb();
				Console.WriteLine(model.getResultsStr());
			}

			Console.WriteLine("Нажмите enter для завершения...");
			Console.ReadLine();
		}
	}
}
