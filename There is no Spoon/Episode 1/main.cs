using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;


class Player
{
    static void Main(string[] args)
    {
        int width = int.Parse(Console.ReadLine()); // the number of cells on the X axis
        int height = int.Parse(Console.ReadLine()); // the number of cells on the Y axis
        List<string> grid = new List<string>();
        for (int i = 0; i < height; i++)
        {
            string line = Console.ReadLine(); // width characters, each either 0 or .
            grid.Add(line);
        }
        for (int i = 0; i < height ; i++){
            for (int j = 0; j < width ; j++){
                int[] node = new int[] {-1, -1};
                int[] node2 = new int[] {-1, -1};
                int[] node3 = new int[] {-1, -1};
                if (grid[i][j] == '0'){
                    node = new int[] {j , i};
                    try{
                        for ( int y = i + 1; y < height ; y++){
                            if (grid[y][j] == '0'){
                                node3 = new int[] {j , y};
                                break;
                            }
                        }
                    }catch{}

                    try{
                        for ( int x = j + 1; x < width ; x++){
                            if (grid[i][x] == '0'){
                                node2 = new int[] {x, i};
                                break;
                            }
                        }
                    }catch{}
                    Console.WriteLine($"{node[0]} {node[1]} {node2[0]} {node2[1]} {node3[0]} {node3[1]}");
                }
            }
        }
    }

}