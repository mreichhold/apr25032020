using Quiz.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    class Program
    {
        static void Main(string[] args)
        {
            Game spiel = new Game(true);
            Question q1 = new Question("Was ist 2+2");
            Answer a1 = new Answer("4", true);
            Answer a2 = new Answer("6");
            q1.AddAnswer(a1);
            q1.AddAnswer(a2);
            spiel.AddQuestion(q1);

            Question q2 = new Question("Wie geht es dir ...");
            Answer a3 = new Answer("gut", true);
            Answer a4 = new Answer("1111");
            q2.AddAnswer(a3);
            q2.AddAnswer(a4);
            spiel.AddQuestion(q2);

            Question q3 = new Question("´Welche Schleife gibt es in C#");
            Answer a5 = new Answer("For-schleife", true);
            Answer a6 = new Answer("Int-Schleife");
            q3.AddAnswer(a5);
            q3.AddAnswer(a6);
            spiel.AddQuestion(q3);


            while(spiel.Status == GameStatus.Active)
            {
                var frage = spiel.NextQuestion;
                var antworten = frage.Answers;
                Console.WriteLine(frage.Text);
                int counter = 0;
                foreach(Answer a in antworten)
                {
                    Console.WriteLine("(" + counter + ") " + a.Text);
                    counter++;
                }
                Console.WriteLine("Geben Sie die richtig: ");
                int eingabeindex = Convert.ToInt32(Console.ReadLine());
                antworten[eingabeindex].IsChecked = true;
                spiel.ValidateCurrentQuestion();
            }

            if(spiel.Status == GameStatus.HasFinished)
            {
                Console.WriteLine("Sie haben gewonnen, erreichtes Level: " + spiel.Level);
            }
            else
            {
                Console.WriteLine("Sie haben Verloren, Aktuelles Level:" + spiel.Level);
            }
            
        }
    }
}
