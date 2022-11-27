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
        string[] inputs = Console.ReadLine().Split(' ');
        int W = int.Parse(inputs[0]);
        int H = int.Parse(inputs[1]);
        List<char> headers = new List<char>();
        List<int> position = new List<int>();
        for (int i = 0; i < H; i++)
        {
            string line = Console.ReadLine();
            if (i == 0) {
                for(int j = 0; j < W; j++){
                    if(line[j] != ' '){
                        headers.Add(line[j]);
                        position.Add(j);
                    }
                }
            }
            else if( i > 0 ){
                for(int z = 0; z < headers.Count(); z++){
                    int verif = 0;
                    if (position[z] != W-1){
                        if(line[position[z]+1] == '-' && verif == 0){
                            position[z] = position[z] + 3;
                            verif = 1;
                        }
                    }
                    if (position[z] > 0){
                        if(line[position[z]-1] == '-' && verif == 0){
                            position[z] = position[z] - 3;
                        }
                    }
                    if( i == H-1){
                        Console.WriteLine($"{headers[z]}{line[position[z]]}");
                    }
                }
            }

        }

    }
}