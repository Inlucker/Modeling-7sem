using System;
using System.IO;
using Accord.Math;
using MathNet.Numerics.Distributions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public abstract class IRndGen
    {
        public int MaxN;
        public int MinN;
        public abstract void SetSid(int s);
        public abstract int Rand();
        public abstract int[] RandArr(int size);
    }

    class RndAlgGen: IRndGen
    {
        private int seed;
        public RndAlgGen(int minN, int maxN, int s=0)
        {
            MinN = minN;
            MaxN = maxN;
            SetSid(s);
        }

        public override void SetSid(int s)
        {
            seed = s;
        }

        public override int Rand()
        {
            seed = seed * 16807 + 2147483647;
            var res = ((uint)seed >> 16) % (MaxN - MinN) + MinN;
            return (int)res;
        }

        public override int[] RandArr(int size)
        {
            int[] res = new int[size];
            for (int i = 0; i < size; i++)
                res[i] = Rand();
            return res;
        }
    }

    class RndTabGen : IRndGen
    {
        private int seed;
        private StreamReader f;
        private string fpath;

        public static void FillFile(string fpath_, int min, int max)
        {
            var rand = new Random();
            using (StreamWriter sw = File.CreateText(fpath_))
            {
                for (int i = 0; i < (max - min) * 1000; i++)
                    sw.WriteLine(rand.Next(min, max));
            }
        }
        public RndTabGen(int minN, int maxN, string fp, int s = 0)
        {
            MinN = minN;
            MaxN = maxN;
            fpath = fp;
            SetSid(s);
            var chi = new ChiSquared(1.0);
        }

        private void OpenFile(string fp)
        {
            fpath = fp;
            if (f != null)
                f.Close();
            f = File.OpenText(fpath);
            for (int i = 0; i < seed; i++)
                f.ReadLine();
        }

        public override void SetSid(int s)
        {
            seed = s;
            OpenFile(fpath);
        }

        public override int Rand()
        {
            string fileStr = f.ReadLine();
            if (fileStr == null)
            {
                SetSid(0);
                fileStr = f.ReadLine();
            }
            seed++;
            
            var res = (UInt32.Parse(fileStr)) % (MaxN - MinN) + MinN;
            return (int)res;
        }

        public override int[] RandArr(int size)
        {
            int[] res = new int[size];
            for (int i = 0; i < size; i++)
                res[i] = Rand();
            return res;
        }
    }

    class Crit
    {
        public int[] arr;
        public Crit(int[] arr_)
        {
            arr = arr_;
        }

        public double Value(int min, int max)
        {
            int n = arr.Length;
            double p = 1.0 / (max - min);
            double acc = 0;
            for (int i = min; i < max; i++)
                acc += Math.Pow(arr.Count(x => x == i), 2) / p;
            acc = acc / (double)n - n;

            double res = ChiSquared.CDF(max - min - 1, acc);
            return res;
        }
    }
}
