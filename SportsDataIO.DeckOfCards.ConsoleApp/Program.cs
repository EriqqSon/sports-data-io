using SportsDataIO.DeckOfCards.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsDataIO.DeckOfCards.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Deck of Cards Coding Challenge — Eric Son\n");


            Console.WriteLine("Q — quit the application");
            Console.WriteLine("N — get a new deck");
            Console.WriteLine("S — shuffle the current deck");
            Console.WriteLine("D — draw next card from current deck and display it on the console");
            Console.WriteLine("R — display on the console all of the cards remaining in the deck\n");

            #region Main Logic

            Deck deck = null;

            bool endApp = false;
            while (!endApp)
            {
                Console.Write("> ");
                switch (Console.ReadLine().ToUpper())
                {
                    case "Q":
                        endApp = true;
                        break;
                    case "N":
                        deck = new Deck();
                        Console.WriteLine("A new deck has been created!");
                        break;
                    case "S":
                        if (deck == null || deck.Cards.Length < 2)
                        {
                            Console.WriteLine("No cards to shuffle!");
                            break;
                        }
                        deck.Shuffle();
                        Console.WriteLine("The current deck has been shuffled!");
                        break;
                    case "D":
                        if (deck == null || deck.Cards.Length == 0)
                        {
                            Console.WriteLine("No cards to draw!");
                            break;
                        }
                        var drawnCard = deck.Draw();
                        Console.WriteLine($"You drew: {drawnCard}");
                        break;
                    case "R":
                        if (deck == null || deck.Cards.Length == 0)
                        {
                            Console.WriteLine("No cards to display!");
                            break;
                        }
                        Console.WriteLine($"Remaining cards: \n{deck}");
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }

            #endregion 
        }
    }
}
