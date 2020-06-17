using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


public class Karty
{
    public void Gra()
    {
        Cards Talia = new Cards();



        int WartoscKartyGracza = 0;
        int WartoscKartyKrupiera = 0;

        Random random = new Random();

        //Losowanie karty z przedziału 1-11 dla karty gracza

        int LosowanieKarty = random.Next(0, Talia.AllCards.Count - 1);
        WartoscKartyGracza += int.Parse(Talia.AllCards[LosowanieKarty].Split()[2]);
        Console.WriteLine("Wylosowałeś: " + Talia.AllCards[LosowanieKarty].Split()[0] + " " + Talia.AllCards[LosowanieKarty].Split()[1]);
        Talia.AllCards.RemoveAt(LosowanieKarty);



        if (WartoscKartyGracza > 21)
        {
            WartoscKartyGracza -= 10;
        }

        //Losowowanie karty z przedziału 1-11 dla karty krupiera

        LosowanieKarty = random.Next(0, Talia.AllCards.Count - 1);
        WartoscKartyKrupiera += int.Parse(Talia.AllCards[LosowanieKarty].Split()[2]);
        Talia.AllCards.RemoveAt(LosowanieKarty);


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
            Console.WriteLine("---------------------------------------");
            string odp = Console.ReadLine();

            //Gracz decyduje się czy chce pociągnąć kartę z talii lub zpassować

            if (odp == "tak")
            {
                Console.WriteLine("---------------------------------------");
                LosowanieKarty = random.Next(0, Talia.AllCards.Count - 1);
                WartoscKartyGracza += int.Parse(Talia.AllCards[LosowanieKarty].Split()[2]);
                Console.WriteLine("Pociągnięta karta to: " + Talia.AllCards[LosowanieKarty].Split()[0] + " " + Talia.AllCards[LosowanieKarty].Split()[1]);
                Talia.AllCards.RemoveAt(LosowanieKarty); //Losowanie kolejnej karty z przedziału 1-11

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
                Console.WriteLine("---------------------------------------");
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



        if (WartoscKartyGracza <= 21) //Wynik gracza to 21 lub mniej
        {
            Console.WriteLine("Krupier losuje karty...");

            //Jeżeli wartość kart krupiera to mniej niż 21 i mniej niż wartosc kart gracza, krupier kontynuuje losowanie kart.

            while (WartoscKartyKrupiera < 21 && WartoscKartyKrupiera < WartoscKartyGracza)
            {

                LosowanieKarty = random.Next(0, Talia.AllCards.Count - 1);
                WartoscKartyKrupiera += int.Parse(Talia.AllCards[LosowanieKarty].Split()[2]);
                Talia.AllCards.RemoveAt(LosowanieKarty);

            }


            if (WartoscKartyGracza == WartoscKartyKrupiera)
            {
                Console.WriteLine("Wartość kart gracza i krupiera jest równa.");
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
