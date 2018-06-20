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

        List<Queue<int>> generateCells(int[][] dists, int[] input, int size, int cell_spread)
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
                    if(dists[i][k] <= cell_spread)
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
                Console.WriteLine();

            }

            int x = 0;
            int[] output = new int[cells.Count * 100];
            for (int i = 0; i < cells.Count; i++)
            {
                output[i] = 0;
            }
            //foreach (int i in sorted)
            for(int i = 0; i < sorted.Length; i++)
            {
                int adjust = 0;
                while (x != sorted[i]) //bring the bf cursor back to the cell we want to work with
                {
                    if (x > sorted[i])
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
                if (output[x] == 0)
                {
                    //output[x] = 0;

                    int div = 1;

                    int count = 0;

                    for (int j = 0; output[x + 1 + j] != 0; j++)
                    {
                        count++;
                    }
                    //Console.Write("count = {0}", count);
                    Console.Write(">"); //shift bf to next pointer to begin a counter.

                    for (int j = 0; j < count; j++)
                    {
                        Console.Write(">"); //adjust for when we have to put the counter in a weird place. j is for adjust.
                    }


                    while (div == 1)
                    {
                        for (int j = 1; j < tmp / 2; j++)
                        {
                            if (tmp % j == 0 && j < tmp / div)
                            {
                                div = j;
                            }
                        }
                        if (div == 1)
                        {
                            adjust++;
                            tmp--;
                        }
                    }

                    for (int j = 0; j < div; j++)
                    {
                        Console.Write("+"); //do the loop this many times
                    }
                    Console.Write("["); //begin loop
                    Console.Write("<"); //go back to letter
                    for (int j = 0; j < count; j++)
                    {
                        Console.Write("<"); //adjust for when we have to put the counter in a weird place. j is for adjust.
                    }

                    while (output[x] != tmp / div)
                    {
                        output[x]++;
                        Console.Write("+"); //increment letter
                    }

                    Console.Write(">");//go back to the counter
                    for (int j = 0; j < count; j++)
                    {
                        Console.Write(">"); //adjust for when we have to put the counter in a weird place. j is for adjust.
                    }
                    Console.Write("-]"); //decrement counter
                    Console.Write("<"); //go back to letter
                    for (int j = 0; j < count; j++)
                    {
                        Console.Write("<"); //adjust for when we have to put the counter in a weird place. j is for adjust.
                    }
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
                            //increment whatever output[x] is at until it = the value we want
                        }
                    }
                }
                for (int j = 0; j < adjust; j++)
                {
                    Console.Write("+");
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

            int[][] dists = getDistances(user_input, user_input_str.Length);
            List<Queue<int>> cells = generateCells(dists, user_input, user_input_str.Length, 8);

            Console.ReadKey();
        }
    }
}
