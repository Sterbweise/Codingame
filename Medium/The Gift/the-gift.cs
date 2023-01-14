using System;
using System.Linq;

class Solution
{
    public static int N { get; set; }
    public static int C { get; set; }

    public static float repartition(int X){
        C -= X;
        N -= 1;
        return C/N;
    }
    static void Main(string[] args)
    {
        N = int.Parse(Console.ReadLine()); // Number of Pilipius
        C = int.Parse(Console.ReadLine()); // Gift Price
        int[] B = new int[N]; // Budjet list
        for (int i = 0; i < N; i++)
        {
            B[i] = int.Parse(Console.ReadLine());
        }
        // Check if possible to buy the gift
        if (B.Sum() < C){Console.WriteLine("IMPOSSIBLE");}
        else {
            Array.Sort(B);
            // equitable repartition ?
            float egal_rep = C/N;
            int n = N;
            for (int i = 0; i < n; i++){
                int x = B[i];
                if (x < egal_rep){
                    Console.WriteLine(x);
                    egal_rep = repartition(x);
                }else{
                    // Round and arround minimum
                    int res = (int)Math.Ceiling(egal_rep);
                    Console.WriteLine(res);
                    egal_rep = repartition(res);
                }
            }
        }
    }
}