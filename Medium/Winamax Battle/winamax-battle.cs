using System;
using System.Linq;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args)
    {
        List<string> cards1 = new List<string>();
        int n = int.Parse(Console.ReadLine()); // the number of cards for player 1
        for (int i = 0; i < n; i++)
        {
            cards1.Add(Console.ReadLine()); // the n cards of player 1
        }
        List<string> cards2 = new List<string>();
        int m = int.Parse(Console.ReadLine()); // the number of cards for player 2
        for (int i = 0; i < m; i++)
        {
            cards2.Add(Console.ReadLine()); // the m cards of player 2
        }
        Console.Error.WriteLine($"Cards Player 1: {n} | Cards Player 2: {m}");
        
        string[] value = new string[]{"A", "K", "Q", "J", "10", "9", "8", "7", "6", "5", "4", "3", "2"};
        
        // Game
        int turn = 0;
        while (true){
            List<string> tmp_cards1 = new List<string>();
            List<string> tmp_cards2 = new List<string>();
            Battle:
            int N1 = cards1.Count(); // number cards of player1
            int N2 = cards2.Count(); // number cards of player2
            // Verif Win
            if ( N1 == N2 && N1 == 0 ){
                Console.WriteLine($"PAT");
            }else if (N1 == 0){
                Console.WriteLine($"2 {turn}");
                break;
            }else if (N2 == 0){
                Console.WriteLine($"1 {turn}");
                break;
            }
            // Card to play
            // Player 1
            string c1 = cards1.First(); // Card pick by player1
            int v1 = 0; // Card value of player1

            // Player 2
            string c2 = cards2.First(); // Card pick by player2
            int v2 = 0; // Card value of player2

            Console.Error.WriteLine($"   ### Turn {turn} ###\nPlayer 1: |   Players 2:\nN1: {N1}    |   N2: {N2}\nCard: {c1}   |   Card: {c2}");
            // Calcul Value of Cards
            for ( int i = 0 ; i < value.Count(); i++){
                if ( c1.Contains(value[i])){v1 = i;}
                if ( c2.Contains(value[i])){v2 = i;}
            }
            // If Player 1 Win
            if ( v1 < v2 ){
                cards1.RemoveAt(0);
                cards2.RemoveAt(0);
                tmp_cards1.Add(c1);
                foreach (string c in tmp_cards1){cards1.Add(c);}
                tmp_cards2.Add(c2);
                foreach (string c in tmp_cards2){cards1.Add(c);}
                Console.Error.WriteLine(" ### Player 1 Win ### \n");
            } // If Player 2 Win
            else if ( v2 < v1 ){
                cards2.RemoveAt(0);
                cards1.RemoveAt(0);
                tmp_cards1.Add(c1);
                foreach (string c in tmp_cards1){cards2.Add(c);}
                tmp_cards2.Add(c2);
                foreach (string c in tmp_cards2){cards2.Add(c);}
                Console.Error.WriteLine(" ### Player 2 Win ### \n");
            } // else Ex aequo Launch Battle
            else {
                // Verif if player have 3 cards + previous card
                if (N1 >= 4 && N2 >= 4){
                    for( int r = 0; r < 4; r++){
                        tmp_cards1.Add(cards1[0]);
                        tmp_cards2.Add(cards2[0]);
                        cards1.RemoveAt(0);
                        cards2.RemoveAt(0);
                    }
                    goto Battle;
                }else{
                    Console.WriteLine("PAT");
                    break;
                }
            }
            turn += 1;
        }
    }
}