using System;

namespace WindowsFormsApp1.EsaKohtala
{ 
    public class Supertykki : Tykki
    {
        //konstruktori jossa ampumiskertojen määrä ja panos
  
        public Supertykki ( int ker, double pan) : base(ker, pan)
        {
            this.ker = ker;
            this.pan = pan;
        }

        //privaatti jysäys
        private readonly string jysays = "KABOOM!";

        //lasketaan miten pitkälle ammukset lensivät ja palautetaan tulos
        public double Kantama()
        {
            double luku = pan * 14;
            return luku;
        }

        //ylikirjoittava ampumismetodi
        public override void Ammu()
        {
            
            for (int i = 0; i < ker; i++)
            {
                Console.WriteLine(jysays);
                
            }
            Console.WriteLine("\nAmmukset lensivät "+Kantama()+"m\n");
        }

    }
}


