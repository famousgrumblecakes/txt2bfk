using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text_to_bf
{
    class ComputeBF
    {
        int[][] getDistances(int[] input, int size)
        {
            int[][] dists = new int[size][];

            for (int i = 0; i < size; i++)
            {
                dists[i] = new int[size];
                for (int k = 0; k < size; k++)
                {
                    if (i == k)
                    {
                        dists[i][k] = -1;
                    }
                    else
                    {
                        dists[i][k] = Math.Abs(input[i] - input[k]);
                    }
                }
            }

            for (int i = 0; i < size; i++)
            {
                Console.Write(input[i] + ": ");
                for (int k = 0; k < size; k++)
                {
                    Console.Write(dists[i][k] + ", ");
                }
                Console.WriteLine();
            }


            return dists;

        }


        public ComputeBF()
        {
            Console.WriteLine("Write a line to convert to BF");
            string user_input_str = Console.ReadLine();

            int[] user_input = new int[user_input_str.Length];
            user_input_str.ToCharArray();

            for (int i = 0; i < user_input_str.Length; i++)
            {
                user_input[i] = Convert.ToInt32(user_input_str[i]);
            }
            Console.Write("ASCII Values of {0}: ", user_input_str);
            foreach (int i in user_input)
            {
                Console.Write(i + ", ");
            }
            Console.WriteLine();

            int[][] distances = getDistances(user_input, user_input_str.Length);


            Console.ReadKey();
        }
    }
}
