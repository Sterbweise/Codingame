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

        // game loop
        while (true)
        {
            List <int> Montagne = new List <int> ();
            for (int i = 0; i < 8; i++)
            {
                int mountainH = int.Parse(Console.ReadLine()); // represents the height of one mountain.
                Montagne.Add(mountainH);
            }
            Console.WriteLine(Montagne.IndexOf(Montagne.Max()));
        }
    }
}