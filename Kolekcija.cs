using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grupa1_csharp_pj
{
    public class Kolekcija<T> where T : Zaposleni       //izgleda da ne moze vise klasa
    {
        private List<T> lista;
        private int brZaposlenih;
        //getteri i setteri
        public Kolekcija()
        {
            brZaposlenih = 0;
            lista = new List<T>();
        }
        public List<T> Lista
        {
            get { return lista; }
            set { lista = value; }
        }
        public void IspisiSveZaposlene()
        {
            foreach (T zaposleni in lista)
            {
                Console.WriteLine(zaposleni.ToString());
            }
        }

        public void dodaj()
        {
            //lista.Add(brZaposlenih);
        }

        public static Kolekcija<T> operator+(Kolekcija<T> kolekcija,T zaposleni)
        {
            kolekcija.lista.Add(zaposleni);
            return kolekcija;
        }
    }
}
