using System;
using System.Linq;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        List<int[]> Task = new List<int[]>();
        for (int i = 0; i < N; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            /* 
                - Date de debut "T"
                - Réalisation est caractérisée par une durée "P"
                - Date de Fin "C"
            */
            int T = int.Parse(inputs[0]);
            int P = int.Parse(inputs[1]);
            int C = T + P - 1;
            Task.Add(new int[] {T,P,C});
        }
        Task = Task.OrderBy(p => p[2]).ToList();
        
        // Number Tasks
        int NT = 0;
        int[] LastTask = new int[3];
        for (int i = 0; i < N; i++){
            Console.Error.WriteLine($"{Task[i][0]} {Task[i][1]} {Task[i][2]}");
            if ( i == 0){
                NT+= 1;
                LastTask = new int[]{Task[i][0],Task[i][1],Task[i][2]};
            }
            else if (Task[i][0] > LastTask[2]){
                NT += 1;
                LastTask = new int[]{Task[i][0],Task[i][1],Task[i][2]};

            }
        }
        Console.WriteLine(NT);
    }
}