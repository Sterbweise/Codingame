using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;


class Solution
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        var pi = new int[N];
        int D = 0;
        for (int i = 0; i < N; i++)
        {
            pi[i] = (int.Parse(Console.ReadLine()));
        }
        var pis = pi.OrderBy(v=>v).ToList();
        for(int j = 1; j < pis.Count(); j++){
            if(j == 1)
                D = pis[j] - pis[j-1];
            else if((pis[j] - pis[j-1]) < D)
                 D = pis[j] - pis[j-1];
        }
        Console.WriteLine(D);
    }
}