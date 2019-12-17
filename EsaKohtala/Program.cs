using System;
using System.Collections.Generic;
using System.IO;


namespace WindowsFormsApp1.EsaKohtala
{
    static class Program
    {

        public static void EsaKohtala()
        {
            //Tässä ohjelmassa annetaan halutun tyyppiselle tykille nimi ja ammutaan sillä niin monta kertaa kuin halutaan. 
            //Tämän jälkeen nimi tallennetaan nimet.txt -tiedostoon, josta nimet voidaan myös lukea myöhemmin ohjelman alkuvalikon kautta.

            Console.WriteLine("AMMUTAAN TYKILLÄ!");

            //luodaan lista johon tallennetaan tykkien nimet ja ampumisjärjestysnumero (id)

            List<string> lista = new List<string>();
            int num, id = 0, kerrat; 
            double panos;

            do
            {
                Console.WriteLine("\nValitse tykin tyyppi: 1= Normaali tykki (122 H 63) ja 2= Supertykki (155 K 98). " +
                    "Valinta 3 näyttää ampuneet tykit ja ampumisjärjestyksen. Valinta 4 sulkee ohjelman.");
                num = int.Parse(Console.ReadLine());

                if (num == 1)
                {

                    //luodaan tykki-olio ja annetaan sille ampumiskerrat ja panos
                    Console.WriteLine("Montako kertaa tykillä ammutaan?");
                    kerrat = int.Parse(Console.ReadLine());
                    id++;
                    Console.WriteLine("Montako ruutipanosta kartussiin laitetaan? ");
                    panos = double.Parse(Console.ReadLine());
                    Tykki tykki = new Tykki(kerrat, panos);

                    //tallennetaan tiedot listaan ja haetaan etäisyys tykki-luokasta
                    lista.Add(id + ". 122 tykki ampui " + kerrat + " kertaa " + panos + " panoksella " +tykki.Etaisyys()+"m.");
                    Console.WriteLine("122 tykki ampuu "+kerrat+ " kertaa: \n");
                    //kutsutaan luokan tykki metodia ammu
                    tykki.Ammu();
                    //kirjoitetaan listan tiedot tiedostoon
                    File.WriteAllLines("tiedot.txt", lista);
                }

                if (num == 2)
                {

                    //luodaan supertykki-olio ja annetaan sille ampumiskerrat ja panos
                    Console.WriteLine("Montako kertaa tykillä ammutaan?");
                    kerrat = int.Parse(Console.ReadLine());
                    id++;
                    Console.WriteLine("Montako ruutipanosta kartussiin laitetaan? ");
                    panos = int.Parse(Console.ReadLine());
                    Supertykki supertykki = new Supertykki(kerrat, panos);

                    //tallennetaan tiedot listaan ja haetaan etäisyys supertykki-luokasta
                    lista.Add(id + ". 155 tykki ampui "+ kerrat +" kertaa " + panos + " panoksella "+supertykki.Kantama()+"m.");
                    Console.WriteLine("155 tykki ampuu "+kerrat+ " kertaa:\n");

                    //kutsutaan luokan supertykki metodia ammu
                    supertykki.Ammu();

                    //kirjoitetaan listan tiedot tiedostoon
                    File.WriteAllLines("tiedot.txt", lista);
                }

                if (num == 3)
                {
                    Console.WriteLine("\nAmpuneet tykit: ");
                    //luetaan tallennetut tiedot tiedostosta
                    string nimet = File.ReadAllText("tiedot.txt");
                    Console.WriteLine(nimet);
                }

                if (num == 4)
                {
                    break;
                }

            }
            while (true);

        }
    }
}
