using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace grupa1_csharp_pj
{
    public class WebDeveloper:Zaposleni
    {
        string tehnologije;
        int brojTehnologija;
        public WebDeveloper(string i, string p, int plata, string t,int brt ):base(i,p,plata)
        {
            brojTehnologija = brt;
            if (brojTehnologija < 1)
                Console.WriteLine("Ne moze poznavati manje od 1 tehnologije! ");
            //tehnologije = new string[brojTehnologija];
           /*for (int br = 0; br < brojTehnologija; br++)
            {
                tehnologije[br] = t[br];
            }*/
                
        }
        //getteri i setteri
        public int BrojTehnologija
        {
            get { return brojTehnologija; }
            set { brojTehnologija = value; }
        }
          public string Tehnologije
        {
            get { return tehnologije; }
            set { tehnologije = value; }
        }

        public override void prikaz()
        {
            Console.WriteLine("Web developer: ");
            Console.Write("Ime: " + ime + ", Prezime: " + prezime + ", Plata: " + plata+ ", Tehnologije: ");
            for (int i = 0; i < brojTehnologija; i++)
                Console.Write(tehnologije[i]+ ", ");
            Console.WriteLine();
        }

        public override float bonus()
        {
            if (brojTehnologija > 5)
                return (float)(0.2 * plata);
            else
                return (float)(0.1 * plata);
        }
       
    }
}
