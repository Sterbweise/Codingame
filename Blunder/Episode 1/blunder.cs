using System;
using System.Collections.Generic;


class Solution
{
    
    static void Main(string[] args)
    {
        string[] inputs = Console.ReadLine().Split(' ');
        int L = int.Parse(inputs[0]);
        int C = int.Parse(inputs[1]);
        char[,] map = new char[L,C];
        int[] _xy = new int[2] {0,0};
        List<int[]> teleporters = new List<int[]>();
        for (int i = 0; i < L; i++){
            string ligne = Console.ReadLine();
            for (int j = 0; j < C; j++){
                map[i,j] = ligne[j];
                if (ligne[j] == '@'){
                    _xy = new int[] {i,j};
                }else if (ligne[j] == 'T'){
                    teleporters.Add(new int[] {i,j});
                }
            }
        }

        // Configuration par defaut
        // Points Cardinaux
        int[] Sud = new int[] {1, 0};
        int[] Nord = new int[] {-1, 0};
        int[] Est = new int[] {0, 1};
        int[] Ouest = new int[] {0, -1};

        // SUD, EST, NORD, OUEST
        int[][] default_direction = new int[][] {Sud, Est, Nord, Ouest};
        string[] default_name_direction = new string[] {"SOUTH", "EAST", "NORTH", "WEST"};
        
        int[][] inversed_direction = new int[][] {Ouest, Nord, Est, Sud};
        string[] inversed_name_direction = new string[] {"WEST", "NORTH", "EAST", "SOUTH"};


        int[][] direction = new int[][] {Sud, Est, Nord, Ouest};
        bool bool_dir = true;
        string[] name_direction = new string[] {"SOUTH", "EAST", "NORTH", "WEST"};

        // Blunder Proprieter
        bool Casseur = false;
        int compteur_direction = 0;

        int init = 0;
        List<string> _output = new List<string>();

        // IA
        while (init < 10000){
            init++;
            char next_emplacement = map[_xy[0] + direction[compteur_direction][0],_xy[1] + direction[compteur_direction][1]];
            if (next_emplacement == '#'){
                compteur_direction = 0;
            }else if (next_emplacement == 'X' && !Casseur){
                compteur_direction = 0;
            }
            // Deplacement
            checknext_emplacement:
            compteur_direction = compteur_direction%4;
            next_emplacement = map[_xy[0] + direction[compteur_direction][0],_xy[1] + direction[compteur_direction][1]];
            int[] next_coord = new int[] {_xy[0] + direction[compteur_direction][0],_xy[1] + direction[compteur_direction][1]};
            if (next_emplacement == '#'){
                compteur_direction += 1;
                goto checknext_emplacement;
            }else if (next_emplacement == 'X'){
                if (!Casseur){
                    compteur_direction += 1;
                    goto checknext_emplacement;
                }else{
                    map[_xy[0] + direction[compteur_direction][0],_xy[1] + direction[compteur_direction][1]] = ' ';
                }
            }
            Console.Error.WriteLine(name_direction[compteur_direction]);
            _output.Add(name_direction[compteur_direction]);
            _xy = next_coord;
            // Bonus
            if (next_emplacement == 'I'){
                string tmp_dir = name_direction[compteur_direction];
                if (bool_dir){
                    direction = inversed_direction;
                    name_direction = inversed_name_direction;
                    compteur_direction = Array.IndexOf(name_direction, tmp_dir);
                    bool_dir = false;
                }else{
                    direction = default_direction;
                    name_direction = default_name_direction;
                    compteur_direction = Array.IndexOf(name_direction, tmp_dir);
                    bool_dir = true;
                }
            }else if ("ESNW".Contains(next_emplacement)){
                switch (next_emplacement)
                {
                    case 'E':
                        compteur_direction = Array.IndexOf(name_direction, "EAST");
                        break;
                    case 'S':
                        compteur_direction = Array.IndexOf(name_direction, "SOUTH");
                        break;
                    case 'N':
                        compteur_direction = Array.IndexOf(name_direction, "NORTH");
                        break;
                    case 'W':
                        compteur_direction = Array.IndexOf(name_direction, "WEST");
                        break;
                }
            }else if (next_emplacement == 'B'){
                Casseur = !Casseur;
            }else if (next_emplacement == 'T'){
                if ($"{next_coord[0]}{next_coord[1]}" == $"{teleporters[1][0]}{teleporters[1][1]}"){
                    Console.Error.WriteLine(1);
                    _xy[0] = teleporters[0][0];
                    _xy[1] = teleporters[0][1];
                }else{
                    _xy[0] = teleporters[1][0];
                    _xy[1] = teleporters[1][1];
                }
            }else if (next_emplacement == '$'){
                break;
            }
        }
        if (init < 10000)
            _output.ForEach(x => Console.WriteLine(x));
        else
            Console.WriteLine("LOOP");
    }
}