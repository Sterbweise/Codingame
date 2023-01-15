using System;
using System.Linq;
using System.Collections.Generic;

class Solution
{
    public static int Median(List<int> list){
        int lenght = list.Count;
        if (lenght % 2 == 0)
        {
            return list[(lenght+1)/2];
        }else{
            return list[lenght/2];
        }
    }

    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        List<int> X = new List<int>{};
        List<int> Y = new List<int>{};
        for (int i = 0; i < N; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            X.Add(int.Parse(inputs[0]));
            Y.Add(int.Parse(inputs[1]));
        }

        // Sort List
        X.Sort();
        Y.Sort();

        // Set the main cable
        int Xa = X.First(), Xb = X.Last();
        long x = Math.Abs(Xb - Xa); // Width of the cable
        int Ya = Median(Y); // Center cable between clients house

        // Link house to main cable 
        long y = 0;
        for (int i = 0; i < N; i++){
            int Yb = Y[i];
            y += Math.Abs(Yb - Ya);
        }
        Console.WriteLine(x + y);
    }
}