using System;

namespace Uppgift_2b
{
    class Program
    {
        static void Main(string[] args)
        {

            int startNumber = 0,
                startHour = 0,
                startMin = 0,
                startSec = 0,
                goalHour = 0,
                goalMin = 0,
                goalSec = 0,
                finnishHour = 0,
                finnishMin = 0,
                finnishSec = 0,
                bestTime = 0,
                firstPlaceStartnumber = 0,
                firstPlaceHour = 0,
                firstPlaceMin = 0,
                firstPlaceSec = 0,
                endTime = 0,
                Competitors = 0,
                secondPlaceStartnumber = 0,
                secondPlaceTime = 0,
                secondPlaceHour = 0,
                secondPlaceMin = 0,
                secondPlaceSec = 0;
            bool program = true;
            bool check = true;

            while (program)
            {
                check = true;
                do
                {
                    Console.Write("Ange start nummer:");
                    if (!int.TryParse(Console.ReadLine(), out startNumber))
                        Console.WriteLine("Fel inmatning, Ange ett startnummer:");

                    else if (startNumber < 1)
                    {

                        program = false;
                        check = false;
                    }
                    else
                        check = false;

                } while (check);

                if (!program)
                {
                    break;
                }


                // Här tar vi emot timme för start
                check = true;
                do
                {
                    Console.Write("Ange start timme:");
                    if (!int.TryParse(Console.ReadLine(), out startHour) || (startHour < 0 || startHour > 23))
                        Console.WriteLine("Fel inmatning, Ange timme mellan 00-23");

                    else
                        check = false;

                } while (check);

                // Här tar vi emot minut för start
                check = true;
                do
                {
                    Console.Write("Ange start minut:");
                    if (!int.TryParse(Console.ReadLine(), out startMin) || (startMin < 0 || startMin > 59))
                        Console.WriteLine("Fel inmatning, Ange minut mellan 00-60");

                    else
                        check = false;

                } while (check);

                // Här tar vi emot sekund för start
                check = true;
                do
                {
                    Console.Write("Ange start sekund:");
                    if (!int.TryParse(Console.ReadLine(), out startSec) || (startSec < 0 || startSec > 59))
                        Console.WriteLine("Fel inmatning, Ange sekund mellan 00-60");

                    else
                        check = false;


                } while (check);

                // Här start vi emot timme för mål
                check = true;
                do
                {
                    Console.Write("Ange timme för mål:");
                    if (!int.TryParse(Console.ReadLine(), out goalHour) || (goalHour < 0 || goalHour > 23))
                        Console.WriteLine("Fel inmatning, Ange timme mellan 00-23");

                    else
                        check = false;


                } while (check);

                // Här tar vi emot minut för mål
                check = true;
                do
                {
                    Console.Write("Ange minut för mål:");
                    if (!int.TryParse(Console.ReadLine(), out goalMin) || (goalMin < 0 || goalMin > 59))
                        Console.WriteLine("Fel inmatning, Ange minut mellan 00-60");

                    else
                        check = false;


                } while (check);

                // Här tar vi emot sekund för mål
                check = true;
                do
                {
                    Console.Write("Ange sekund för mål:");
                    if (!int.TryParse(Console.ReadLine(), out goalSec) || (goalSec < 0 || goalSec > 59))
                        Console.WriteLine("Fel inmatning, Ange sekund mellan 00-60");

                    else
                        check = false;



                } while (check);

                // Lägger till en deltagare för varje gång programmet körs, tills startNumber är mindre eller = 0
                Competitors++;


                finnishHour = goalHour - startHour;
                finnishMin = goalMin - startMin;
                finnishSec = goalSec - startSec;

                // Räknkar om timmar över midnatt!

                if (finnishSec < 0)
                {
                    finnishSec += 60;
                    finnishMin--;

                }

                if (finnishMin < 0)
                {
                    finnishMin += 60;
                    finnishHour--;

                }

                if (finnishHour < 0)
                {
                    finnishHour += 24;

                }

                // Omvandlar startTimme och startMinut och lägger ihop till total sekunder start
                int totalSecStart = finnishSec + (finnishHour * 3600) + (finnishMin * 60);

                endTime = totalSecStart;

                // Om endTime är sämre än bestTime eller om bestTime är mindre eller = 0
                if (endTime < bestTime || bestTime <= 0)
                {
                    // Om bestTime är högre än 0, då förs värdet över till SecondPlaceTime
                    if (bestTime > 0)
                    {
                        secondPlaceTime = bestTime;
                        secondPlaceStartnumber = firstPlaceStartnumber;
                        secondPlaceHour = firstPlaceHour;
                        secondPlaceMin = firstPlaceMin;
                        secondPlaceSec = firstPlaceSec;
                    }

                    bestTime = endTime;
                    firstPlaceHour = finnishHour;
                    firstPlaceMin = finnishMin;
                    firstPlaceSec = finnishSec;

                    firstPlaceStartnumber = startNumber;

                }
                // Om endTime är bättre än bestTime och endTime är sämre än secondPlaceTime eller minder = 0
                else if ((endTime > bestTime && endTime < secondPlaceTime) || secondPlaceTime <= 0)
                {
                    secondPlaceTime = endTime;
                    secondPlaceStartnumber = startNumber;
                    secondPlaceHour = finnishHour;
                    secondPlaceMin = finnishMin;
                    secondPlaceSec = finnishSec;

                }

            }

            Console.Clear();
            //Skriver ut detta resultat om det är fler än 1 tävlande
            if (Competitors > 1)
            {   // Skriver ut första platsens resultat
                Console.WriteLine($"Första platsen är startnummer" +
                    $" {firstPlaceStartnumber} med tiden: " +
                    $"\n--- {firstPlaceHour} Timmar " +
                    $"{firstPlaceMin} Minuter " +
                    $"{firstPlaceSec} Sekunder---");

                //Skriver ut andra platsens resultat
                Console.WriteLine($"Andra platsen är startnummer " +
                    $"{secondPlaceStartnumber} med tiden " +
                    $"\n--- {secondPlaceHour} Timmar " +
                    $"{secondPlaceMin} Minuter " +
                    $"{secondPlaceSec} Sekunder---");
                // Skriver ut antal deltagare
                Console.WriteLine($"Antal deltagare: {Competitors}");
            }

            // SKriver ut vinnarens startnummer och resultat
            else if (Competitors < 1)
            {
                // Om loppet har färre delagare än 1 kommer detta skivas ut
                Console.WriteLine("Loppet hade inga deltagare");
            }
            else
            {

                Console.WriteLine($"Första platsen är startnummer " +
                    $"{firstPlaceStartnumber} med tiden: " +
                    $"\n--- {firstPlaceHour} Timmar, " +
                    $"{firstPlaceMin} Minuter, " +
                    $"{firstPlaceSec } Sekunder---");
                // Skriver ut antal deltagare
                Console.WriteLine($"Antal deltagare: {Competitors}");
            }






        }


    }
}
