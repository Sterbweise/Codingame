using System;
using System.Linq;

class Solution
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        string cgxLine = "";
        int str = 0;
        for (int i = 0; i < N; i++)
        {
            string input = Console.ReadLine().ToString();
            // Remove Space
            for (int j = 0; j < input.Length; j++){
                if(input[j] == '\''){
                    str += 1;
                    cgxLine += input[j];
                }else if (input[j] != '\n' && input[j] != '\t' && input[j] != ' ' || str%2 == 1){
                    cgxLine += input[j];
                }
            }
        }
        int lastSpace = 0;
        string _out = "";
        str = 0;
        for (int i = 0; i < cgxLine.Length; i++){
            if(cgxLine[i] == '\''){
                str += 1;
                _out += cgxLine[i];
            }else if (cgxLine[i] == '(' && str%2 == 0){
                if (cgxLine[i+1] != ')'){
                    lastSpace += 4;
                    string indentation = String.Concat(Enumerable.Repeat(' ', (lastSpace)));
                    if (i > 1 && cgxLine[i-1] == '='){
                        _out += $"\n{String.Concat(Enumerable.Repeat(' ', (lastSpace-4)))}{cgxLine[i]}\n{indentation}";
                    }else{
                        _out += $"{cgxLine[i]}\n{indentation}";
                    }
                }else {
                    lastSpace += 4;
                    _out += $"{cgxLine[i]}";
                }
            }else if (cgxLine[i] == ')' && str%2 == 0){
                lastSpace -= 4;
                string indentation = String.Concat(Enumerable.Repeat(' ', (lastSpace)));
                _out += $"\n{indentation}{cgxLine[i]}";
            }else if (cgxLine[i] == ';'){
                string indentation = String.Concat(Enumerable.Repeat(' ', (lastSpace)));
                _out += $"{cgxLine[i]}\n{indentation}";
            }else{
                _out += cgxLine[i];
            }
        }
        Console.WriteLine(_out);
    }
}