using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab06
{
	class Request
	{
		public Request(double t)
		{
			create_time = t;
		}

		public double create_time = 0;
		public double serve_time = -1;
	}
}
