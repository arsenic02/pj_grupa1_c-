using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grupa1_csharp_pj
{
    public class DevOps:Zaposleni
    {
        DateTime datum;//datum kad je zadnji put pregledao kompove
        public DevOps(string i, string p, int plata,DateTime dat):base(i,p,plata)
        {
            datum = dat;
        }
        public DateTime Datum
        {
            get { return datum; }
            set { datum = value; }
        }
        public override void prikaz()
        {
            Console.WriteLine("DevOps inzenjer: ");
            Console.WriteLine("Ime: " + ime + ", Prezime: " + prezime + ", Plata: " + plata + ", datum poslednje popravke PC-a: " + datum);
        }
        
        public override float bonus()
        {
            TimeSpan razlika = (DateTime.Now - datum).Duration();
            if (razlika.TotalDays <= 7)
                return (float)(0.3 * plata);
            return (float)(0.15 * plata);         
        }
    }
}
