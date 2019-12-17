using System;

namespace WindowsFormsApp1.EsaKohtala
{ 
    public class Tykki : IAmmu

    {

        public int ker;
        public double pan;
        

        //konstruktori jossa ampumiskertojen määrä ja panos
        public Tykki(int ker, double pan)
        {
            this.ker = ker;
            this.pan = pan;
        }

        //privaatti laukaus stringi
        private readonly string laukaus = "PUM!";
       
        //lasketaan miten pitkälle ammukset lensivät ja palautetaan tulos
        public double Etaisyys()
        {
            double luku = pan * 4.6;
            
            return luku;
        }

        //ampumismetodi
        public virtual void Ammu()

        {
    
            for (int i = 0; i < ker; i++)
            {
                Console.WriteLine(laukaus);
            }
            
            Console.WriteLine("\nAmmukset lensivät " + Etaisyys() + "m\n");

            
        }



    }


}
