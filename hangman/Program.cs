using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---O Jogo da forca para console - V1.0---");

            string[] words = { "teste", "olho", "caviar", "instituição", "sociedade" };
            Random rand = new Random();
            int pickedWord = rand.Next(0, words.Length - 1);
            string word = words[pickedWord];

            Console.WriteLine("\nA palavra possui {0} letras.\n", word.Length);
            
            int err = 0, correct = 0;
            bool ended = false;
            List<string> triedLetters = new List<string>();
            
            while (ended == false) {
                Console.WriteLine("\nfavor digitar letra: (digite \"sair\" para sair)");
                string ch = Console.ReadLine();
                if (ch == "sair")
                {
                    break;
                }
                if(ch == "" || ch.Length > 1)
                {
                    Console.WriteLine("\nValor inválido! digite apenas uma letra!");
                }
                else{
                    if (word.Contains(ch))
                    {
                        correct += countLetter(word, ch);
                        Console.WriteLine("\nletra achada! Faltam {0} letras.\n", word.Length - correct);
                        triedLetters.Add(ch);
                        if (correct == word.Length)
                        {
                            Console.WriteLine("\n\nParabens, você acertou! a palavra era: {0}", word);
                            ended = true;
                            break;
                        }
                    }
                    else
                    {
                        err++;
                        Console.WriteLine("\nVocê errou! Faltam {0} tentativas.", 6 - err);
                        triedLetters.Add(ch);
                        if (err == 6)
                        {
                            Console.WriteLine("\n\nInfelizmente, você perdeu! a palavra era: {0} ", word);
                            ended = true;
                            break;
                        }
                    }
                }
                Console.WriteLine("Letras tentadas: {0}", toString(triedLetters));
            }
            Console.WriteLine("\n\nO jogo acabou! Pressione tecla para continuar...");
            Console.ReadKey();
        }

        static int countLetter(string word, string ch)
        {
            int c = 0;
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == ch[0])
                {
                    c++;
                }
            }
            return c;
        }

        static string toString(List<string> someList)
        {
            string genString = "";
            foreach (string str in someList){
                genString += str + " ";
            }
            return genString;
        }
    }
}
