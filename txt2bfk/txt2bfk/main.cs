using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text_to_bf
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Count() != 0)
            {
                string input = "";
                for (int i = 0; i < args.Count(); i++)
                {
                    input = input + args[i];
                    if (i != args.Count() -1)
                    {
                        input += " ";
                    }
                }

                ComputeBF ka = new ComputeBF(input);
            }

        }
    }
}
