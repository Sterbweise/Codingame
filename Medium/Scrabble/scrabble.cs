using System;
using System.Linq;
using System.Collections.Generic;

class Solution
{
    public static bool CanWriteWord(string letters, string word){
        bool canWriteWord = true;
        foreach (char c in word)
        {
            int index = letters.IndexOf(c);
            if (index < 0)
            {
                return false;
            }
            letters = letters.Remove(index, 1);
        }
        return canWriteWord;
    }
    static void Main(string[] args)
    {
        // Point Section
        string _1 = "eaionrtlsu";
        string _2 = "dg";
        string _3 = "bcmp";
        string _4 = "fhvwy";
        string _5 = "k";
        string _8 = "jx";
        string _10 = "qz";

        int N = int.Parse(Console.ReadLine());
        List<string> words = new List<string>();
        for (int i = 0; i < N; i++){words.Add(Console.ReadLine());}
        string LETTERS = Console.ReadLine();
        int POINTS = 0;
        string best_word = "";

        foreach (string W in words)
        {
            if (CanWriteWord(LETTERS, W)){
                int tmp_point = 0;
                for (int j = 0; j < W.Count(); j++){
                    if (_1.Contains(W[j])){
                        tmp_point += 1;
                    }else if (_2.Contains(W[j])){
                        tmp_point += 2;
                    }else if (_3.Contains(W[j])){
                        tmp_point += 3;
                    }else if (_4.Contains(W[j])){
                        tmp_point += 4;
                    }else if (_5.Contains(W[j])){
                        tmp_point += 5;
                    }else if (_8.Contains(W[j])){
                        tmp_point += 8;
                    }else if (_10.Contains(W[j])){
                        tmp_point += 10;
                    }
                }
                if (tmp_point > POINTS){
                    POINTS = tmp_point;
                    best_word = W;
                }
            }
        }
        Console.WriteLine(best_word);
    }
}