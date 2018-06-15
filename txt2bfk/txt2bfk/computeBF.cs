using System;
using System.Collections.Generic;

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
                    dists[i][k] = Math.Abs(input[i] - input[k]);
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

        Queue<int>[] generateCells(int[] input, int size, int cell_spread)
        { 

            Queue<int>[] cells = new Queue<int>[size];

            int cellcount = 0;
            Queue<int> used = new Queue<int>();
            for (int i = 0; i < size; i++)
            {

                    cells[cellcount] = new Queue<int>();
                    for (int k = i; k < size; k++)
                    {
                        if(Math.Abs(input[i] - input[k]) <= cell_spread)
                        {
                                bool found = false;

                                foreach (int p in used)
                                {
                                    if (p == k)
                                    {
                                        found = true;
                                    }
                                }
                                if (found == false)
                                {
                                    cells[cellcount].Enqueue(k);
                                    used.Enqueue(k);
                                }
                        }
                    }
                        if (cells[cellcount].Count != 0)
                        {
                            cellcount++;
                        }
                        if(used.Count == size)
                        {
                            break;
                        }
            }

                    Console.WriteLine("Characters: " + size + ". Cells: " + cellcount);

            for (int i = 0; i < cellcount; i++)
            {
                Console.Write("Cell " + i + ": ");
                foreach (int j in cells[i])
                {
                    Console.Write(j + ", ");
                }
                Console.WriteLine();
            }

            return cells;
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

            //getDistances(user_input, user_input_str.Length);
            Queue<int>[] cells = generateCells(user_input, user_input_str.Length, 5);


            Console.ReadKey();
        }
    }
}
