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
        string[,] array = new string[N,3];
        for (int i = 0; i < N; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            string plate = inputs[0];
            string radarname = inputs[1];
            long timestamp = long.Parse(inputs[2]);
            array[i,0] = plate;
            array[i,1] = radarname;
            array[i,2] = timestamp.ToString();
        }

        // Get all unique plate in string
        List<string> Plates = new List<string>();
        for(int j = 0; j < N; j++){
            Plates.Add(array[j,0]);
        }

        List<string> Flashed = new List<string>();
        foreach(string name in Plates.Distinct()){
            //Console.Error.WriteLine($"Test 1 Name: {name}");
            for(int z = 0; z < N; z++){
                if(array[z,0] == name && array[z,1] == "A21-42"){
                    //Console.Error.WriteLine($"Test 2 Radar1: {array[z,1]}");
                    long time1 = (long)Convert.ToDouble(array[z,2]);
                    for(int y = 0; y < N; y++){
                        if(array[y,0] == name && array[y,1] == "A21-55"){
                            long time2 = (long)Convert.ToDouble(array[y,2]);
                            // Calcule de la Vitess. (V = d/t)
                            double v = (((double)13000/((time2-time1)/1000))*3.6);
                            //Console.Error.WriteLine($"Test 2 Vitess: {v}");
                            if(v >= 131)
                                Flashed.Add($"{name} {Math.Truncate(v)}");
                        }
                    }
                }
            }
        }

        foreach(string flashed in Flashed.OrderBy(a => a).ToList()){
            Console.WriteLine($"{flashed}");
        }
    }
}