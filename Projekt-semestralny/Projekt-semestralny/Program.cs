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
                    
                    if (WartoscKartyGracza > 21)
                    {
                        Console.WriteLine("Wartość twoich kart to więcej niż 21.");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("BUST");
                        Console.ResetColor();
                        break;
                    }

                    else
                    {
                        continue;
                    }
                }

                else if (odp == "nie")
                {
                    break;
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Zła odpowiedz.");
                    Console.ResetColor();
                    continue;
                }
            }

            //Ruchy Krupiera

            Console.WriteLine("Krupier losuje karty...");
            
            if(WartoscKartyGracza <= 21) //Wynik gracza to 21 lub mniej
            {
                //Jeżeli wartość kart krupiera to mniej niż 21 i mniej niż wartosc kart gracza, krupier kontynuuje losowanie kart.
                while (WartoscKartyKrupiera < 21 && WartoscKartyKrupiera < WartoscKartyGracza) 
                {
                    WartoscKartyKrupiera += random.Next(1, 12);
                }

                
                if (WartoscKartyGracza == WartoscKartyKrupiera)
                {
                    Console.WriteLine("Wartość kart gracz i krupiera jest równa.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("REMIS");
                    Console.ResetColor();
                }

                else if (WartoscKartyGracza < WartoscKartyKrupiera && WartoscKartyKrupiera <= 21)
                {
                    Console.WriteLine("Wartość kart krupiera to: " + WartoscKartyKrupiera + ".");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Przegrałeś");
                    Console.ResetColor();
                }

                else if (WartoscKartyKrupiera > 21)
                {
                    Console.WriteLine("Wartośc kart krupiera to: " + WartoscKartyKrupiera + ".");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Wygrałeś!");
                    Console.ResetColor();
                }

                else if (WartoscKartyKrupiera == 21)
                {
                    Console.WriteLine("Wartość graczy krupiera to: " + WartoscKartyKrupiera + ".");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Przegrałeś");
                    Console.ResetColor();
                }
            }

            Console.ReadLine();

        }
    }
}
