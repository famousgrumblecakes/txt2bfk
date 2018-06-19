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

        List<Queue<int>> generateCells(int[] input, int size, int cell_spread)
        {

            List<Queue<int>> cells = new List<Queue<int>>();


            int cellcount = 0;
            Queue<int> used = new Queue<int>();
            int[] sorted = new int[size];
            for (int i = 0; i < size; i++)
            {
                Queue<int> item = new Queue<int>();
                cells.Add(item);
                for (int k = i; k < size; k++)
                {
                    if (Math.Abs(input[i] - input[k]) <= cell_spread)
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
                            cells[cellcount].Enqueue(input[k]);
                            used.Enqueue(k);
                            sorted[k] = cellcount;
                        }
                    }
                }
                if (cells[cellcount].Count != 0)
                {
                    cellcount++;
                }
                if (used.Count == size)
                {
                    break;
                }
            }

            for (int i = 0; i < cellcount; i++)
            {
                Console.Write("Cell " + i + ": ");
                foreach (int j in cells[i])
                {
                    Console.Write((char)j + ", ");
                }
                Console.WriteLine();
            }


            int x = 0;
            int[] output = new int[cells.Count];
            for (int i = 0; i < cells.Count; i++)
            {
                output[i] = -1;
            }

            foreach (int i in sorted)
            {
                while (x != i)
                {
                    if (x > i)
                    {
                        x--;
                        Console.Write("<");
                        // decrement bfk pointer <
                    }
                    else
                    {
                        x++;
                        Console.Write(">");
                        //increment bfk pointer >
                    }
                }
                int tmp = cells[x].Dequeue();


                //Optimize a cell on its first call, kinda
                if (output[x] == -1)
                {
                    output[x] = 0;


                    int div = 1;
                    Console.Write(">");
                    for (int j = 1; j < tmp /2; j++)
                    {
                        if (tmp % j == 0 && j < tmp / div)
                        {
                            div = j;
                        }
                    }
                    for (int j = 0; j < div; j++)
                    {
                        Console.Write("+");
                    }
                    Console.Write("[<");

                    while (output[x] != tmp / div)
                    {
                        output[x]++;
                        Console.Write("+");

                    }
                    Console.Write(">-]<");
                    output[x] = tmp;
                }
                else
                {
                    while (output[x] != tmp)
                    {
                        if (output[x] > tmp)
                        {
                            output[x]--;
                            Console.Write("-");
                            //decrement whatever output[x] is at
                        }
                        else
                        {
                            output[x]++;
                            Console.Write("+");
                            //increment whatever output[x] is at
                        }
                    }
                }


                

                Console.Write(".");
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
            List<Queue<int>> cells = generateCells(user_input, user_input_str.Length, 5);

            Console.ReadKey();
        }
    }
}
