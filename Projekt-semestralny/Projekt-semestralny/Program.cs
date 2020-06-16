using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSemestralnyC
{
    class Program
    {
        static void Main(string[] args)
        {
            int WartoscKartyGracza = 0;
            int WartoscKartyKrupiera = 0;

            Random random = new Random();

            //Losowanie karty z przedziału 1-11 dla karty gracza

            WartoscKartyGracza += random.Next(1, 12);
            WartoscKartyGracza += random.Next(1, 12);

            if (WartoscKartyGracza > 21)
            {
                WartoscKartyGracza -= 10;
            }

            //Losowowanie karty z przedziału 1-11 dla karty krupiera

            WartoscKartyKrupiera += random.Next(1, 12);
            WartoscKartyKrupiera += random.Next(1, 12);

            if (WartoscKartyKrupiera > 21)
            {
                WartoscKartyKrupiera -= 10;
            }


            while (true)
            {
                if (WartoscKartyGracza == 21)
                {
                    Console.WriteLine("Twoja wartość kart to 21!");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.ResetColor();
                    break;
                }

                Console.WriteLine("Wartość twoich kart to: " + WartoscKartyGracza.ToString() + Environment.NewLine + "Czy chcesz pociągnąć kartę? (tak/nie)");
                string odp = Console.ReadLine();

                //Gracz decyduje się czy chce pociągnąć kartę z talii lub zpassować

                if (odp == "tak")
                {
                    WartoscKartyGracza += random.Next(1, 12); //Losowanie kolejnej karty z przedziału 1-11
                }

                else if (odp == "nie")
                {

                }

                else
                {
                    Console.WriteLine("Zła odpowiedz.");
                    continue;
                }
            }


            switch (WartoscKartyGracza)
            {
                case 1:
                case 11:
                    Console.WriteLine("As");
                    break;

                case 2:
                    Console.WriteLine("Karta o wartości 2.");
                    break;

                case 3:
                    Console.WriteLine("Karta o wartości 3.");
                    break;

                case 4:
                    Console.WriteLine("Karta o wartości 4.");
                    break;

                case 5:
                    Console.WriteLine("Karta o wartości 5.");
                    break;

                case 6:
                    Console.WriteLine("Karta o wartości 6.");
                    break;

                case 7:
                    Console.WriteLine("Karta o wartości 7.");
                    break;

                case 8:
                    Console.WriteLine("Karta o wartości 8.");
                    break;

                case 9:
                    Console.WriteLine("Karta o wartości 9.");
                    break;

                case 10:
                    Console.WriteLine("10 | Król | Królowa | Jupek");
                    break;

                default:
                    Console.WriteLine("Joker");
                    break;
            }

            Console.ReadLine();

        }
    }
}
