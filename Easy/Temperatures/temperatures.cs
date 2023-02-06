using System;
using System.Linq;

class Solution
{

    public static int ComputeClosestToZero(int[] ts)
    {
        if (ts.Count() <= 0){
            return 0;
        }else{
            int close_to_zero = ts[0];
            foreach (int x in ts){
                if (Math.Abs(x) < Math.Abs(close_to_zero)){
                    close_to_zero = x;
                }else if (Math.Abs(x) == Math.Abs(close_to_zero)){
                    close_to_zero = Math.Max(x, close_to_zero);
                }
            }
            return close_to_zero;
        }
    }
}