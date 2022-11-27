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
        string[] inputs = Console.ReadLine().Split(' ');
        int lightX = int.Parse(inputs[0]); // the X position of the light of power
        int lightY = int.Parse(inputs[1]); // the Y position of the light of power
        int initialTx = int.Parse(inputs[2]); // Thor's starting X position
        int initialTy = int.Parse(inputs[3]); // Thor's starting Y position
        // game loop
        while (true)
        {
            int remainingTurns = int.Parse(Console.ReadLine()); // The remaining amount of turns Thor can move. Do not remove this line.

            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");'
            Console.Error.WriteLine($"Thor: Horizon :{initialTx} Hauteur: {initialTy} \n Marteau: Horizon {lightX} Hauteur: {lightY}");
            if (initialTx == lightX){
                if (initialTy < lightY){
                    initialTy +=1;
                    Console.WriteLine("S");
                }
                else if(initialTy > lightY){
                    Console.WriteLine("N");
                    initialTy -= 1;
                }
            }

            else if (initialTy == lightY){
                if (initialTx > lightX){
                    Console.WriteLine("W");
                    initialTx -= 1;
                }
                else if(initialTx < lightX){
                    Console.WriteLine("E");
                    initialTx += 1;
                }
            }

            else if (initialTx > lightX){
                if (initialTy < lightY){
                    Console.WriteLine("SW");
                    initialTx -= 1;
                    initialTy += 1;
                }
                else if(initialTy > lightY){
                    Console.WriteLine("NW");
                    initialTx -= 1;
                    initialTy -= 1;
                }
            }

            else if (initialTx < lightX){
                if (initialTy < lightY){
                    Console.WriteLine("SE");
                    initialTx += 1;
                    initialTy += 1;
                }
                else if(initialTy > lightY){
                    Console.WriteLine("NE");
                    initialTx += 1;
                    initialTy -= 1;
                }
            }
        }
    }
}