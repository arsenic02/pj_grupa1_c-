using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace grupa1_csharp_pj
{
    public abstract class Zaposleni
    {
        protected string ime, prezime;
        protected int plata;

        public string Ime
        {
            get { return ime; }
            set { ime = value; }
        }
        public string Prezime
        {
            get { return prezime; }
            set { prezime = value; }
        }
        public int Plata
        {
            get { return plata; }
            set { plata = value; }
        }
        public Zaposleni(string i,string p,int plata)
        {
            ime = i;
            prezime= p;
            this.plata = plata;
        }
        public abstract void prikaz();
        public abstract float bonus();//bonus za povecanje plate

       // public abstract void proveraBonusa();

        //public abstract float getBonus();//samo bonus da vraca 0.2 , 0.3 itd i tako blize
    }
}
