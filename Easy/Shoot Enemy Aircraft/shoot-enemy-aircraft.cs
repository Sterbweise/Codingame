using System;
using System.Linq;
using System.Collections.Generic;


class Solution
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<string> map = new List<string>();
        List<int[]> aircrafts = new List<int[]>();
        int[] missiles = new int[]{};
        // Save Map
        for (int i = 0; i < n; i++){map.Add(Console.ReadLine());}

        // Game
        for (int i = 0; i < n; i++){
            string line = map[i];
            for (int j = 0; j < line.Length; j++){
                char radar = line[j];
                if (radar == '>' || radar == '<'){
                    if (radar == '>')
                        aircrafts.Add(new int[] {i,j,1});
                    else
                        aircrafts.Add(new int[] {i,j,-1});
                }else if (radar == '^') {
                    missiles = new int[] {i,j};
                }
            }
        }
        while (aircrafts.Count() > 0){
            List<int[]> tmp_aircrafts = new List<int[]>();
            bool wait = true;
            foreach (int[] aircraft in aircrafts){
                if (Math.Abs(aircraft[0] - missiles[0]-1) == Math.Abs(missiles[1] - aircraft[1])){
                    Console.WriteLine("SHOOT");
                    wait = false;
                }else{
                    tmp_aircrafts.Add(new int[] {aircraft[0], aircraft[1]+aircraft[2],aircraft[2]});
                }
            }
            if (wait)
                Console.WriteLine("WAIT");
            aircrafts = tmp_aircrafts;
        }
    }
}