using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
    static void Main(string[] args)
    {
        string words = "ABCDEFGHIJKLMNOPQRSTUVWXYZ?";
        int L = int.Parse(Console.ReadLine());
        int H = int.Parse(Console.ReadLine());
        string T = Console.ReadLine(); // Text que long veux afficher
        T = T.ToUpper();
        for (int i = 0; i < H; i++)
        {
            string ROW = Console.ReadLine();
            string line = "";
            foreach(char letter in T){
                int index = words.IndexOf(letter)+1;
                if(index == 0)
                    index = 27;
                int jump = index*L;
                int prejump = jump-L;
                //Console.Error.WriteLine($"{index} {jump} {prejump} {letter} {T}");
                line += ROW[prejump..jump];
            }
            Console.WriteLine(line);
        }
        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");
    }
}