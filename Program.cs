using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grupa1_csharp_pj
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Kolekcija<Zaposleni> k = new Kolekcija<Zaposleni>();
                Kompanija kompanija = new Kompanija();
                Zaposleni z1 = new WebDeveloper("Pera", "Peric", 30000, "java,c#", 2);
                Zaposleni z2 = new QAInzenjer("Ana", "Ilic", 40000, 6);
                Zaposleni z3 = new DevOps("Iva", "Ivic", 37585, new DateTime(2023, 5, 13));
                kompanija = kompanija + z1;//stack overflow
                kompanija.Zaposleni = kompanija.Zaposleni + z1;//stack overflow
                kompanija.upisBin("binfajl.bin");
                kompanija.CitanjeBin("binfajl.bin");
            }
            catch(PrevelikiBonus e)
            {
                Console.WriteLine(e.StackTrace);
            }
            catch(IOException ioe)
            {
                Console.WriteLine(ioe.StackTrace);
            }
            
            
            

        }
    }
}
