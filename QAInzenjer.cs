using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grupa1_csharp_pj
{
    public class QAInzenjer : Zaposleni
    {
        int brojQATestova;
        public QAInzenjer(string i, string p, int plata, int b) : base(i, p, plata)
        {
            brojQATestova = b;
        }

        public override float bonus()
        {
            if (brojQATestova > 10)
                return (float)(0.1 * plata);
            else
                return (float)(0.05 * plata);
        }

        //getteri i setteri
        public int BrojQATestova
        {
            get { return brojQATestova; }
            set { brojQATestova=value;}
        }
        
        public override void prikaz()
        {
            Console.WriteLine("QA inzenjer: ");
            Console.WriteLine("Ime: " + ime + ", Prezime: " + prezime + ", Plata: " + plata + ", broj QA testova: " + brojQATestova);
        }

    }
}
