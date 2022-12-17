using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04
{
	class ReqQue : Queue<Request>
	{
        public bool push(Request r)
        {
            que_entry++;
            Enqueue(r);
            if (Count > max_size)
            {
                max_size = Count;
                return true;
            }
            return false;
        }
        public Request pop()
        {
            return Dequeue();
        }

        public int max_size = 0;
        public int que_entry = 0;
    }
}
