using System;
using System.Linq;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args)
    {
        List<int> R = new List<int>{int.Parse(Console.ReadLine())};
        int L = int.Parse(Console.ReadLine());

        for (int i = 0; i < L-1; i++){
            int counter = 0;
            int last_number = 0;
            int R_L = R.Count();
            List<int> R_tmp = new List<int>{};
            for (int j = 0; j < R_L; j++){
                int x = R[j];
                if (i == 0){
                    R_tmp.Add(1);
                    R_tmp.Add(x);
                }else{
                    if(last_number != x){
                        if ( j != 0){
                            R_tmp.Add(counter);
                            R_tmp.Add(last_number);
                            counter = 0;
                        }
                        last_number = x;
                        counter += 1;
                        if(j == R_L-1){
                            R_tmp.Add(counter);
                            R_tmp.Add(last_number);
                        }
                    }else{
                        counter += 1;
                        if(j == R_L-1){
                            R_tmp.Add(counter);
                            R_tmp.Add(x);
                        }
                    }
                }
            }
            R = R_tmp;
        }
        Console.WriteLine(string.Join(" ", R));
    }
}