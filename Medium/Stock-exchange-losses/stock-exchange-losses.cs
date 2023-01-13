using System;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[] values = Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);
        int maxLoss = 0;
        for (int i = 0; i < n - 1; i++) {
            for (int j = i + 1; j < n; j++) {
                if (values[i] > values[j]){
                    int profit = values[j] - values[i];
                    if (profit < maxLoss) {
                        maxLoss = profit;
                    }
                }else{break;}
            }
        }
        Console.WriteLine(maxLoss);
    }
}