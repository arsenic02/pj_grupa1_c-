using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace grupa1_csharp_pj
{
    public class Kompanija
    {
        const float maxBonus = 0.2F;//double je podrazumevani za decimale
        

        //private int brZaposlenih;
        private Kolekcija<Zaposleni> zaposleni;//{ get; set; }//public??

        public Kolekcija<Zaposleni> Zaposleni
        {
            get { return zaposleni; }
            set { zaposleni = value; }
        }
        public Kompanija()
        {
            //brZaposlenih = 0;
            zaposleni = new Kolekcija<Zaposleni>();
        }
        public static Kompanija operator +(Kompanija kompanija, Zaposleni radnik)//Kompanija kompanija, 
        {
            //proveraBonusa();
            //kompanija.Zaposleni.Add(radnik);
            kompanija.Zaposleni.Lista.Add(radnik);
            return kompanija;
        }

        public void upisBin(string nazivFajla)
        {
            try
            {
                using (BinaryWriter bw = new BinaryWriter(new FileStream(nazivFajla, FileMode.Create)))
                {
                    foreach (Zaposleni zaposleni in Zaposleni.Lista)
                    {
                        // bw.Write(Zaposleni.Lista.ForEach(lista)
                        bw.Write(zaposleni.Ime);//svi zaposleni imaju ovo
                        bw.Write(zaposleni.Prezime);
                        bw.Write(zaposleni.Plata);
                        if (zaposleni is WebDeveloper)
                        {
                            WebDeveloper wd = (WebDeveloper)zaposleni;
                            bw.Write(wd.BrojTehnologija);//bw.Write(wd.Tehnologije.Length);
                                                         //bw.Write(wd.Tehnologije);
                            //foreach (string tehnologija in wd.Tehnologije)
                            //{
                                bw.Write(wd.Tehnologije);
                            //}
                        }
                       else if(zaposleni is DevOps)
                        {
                            //bw.Write(zaposleni.Datum);
                            DevOps dev= (DevOps)zaposleni;
                            bw.Write(dev.Datum.ToBinary());
                        }
                        else
                        {
                            QAInzenjer qa = (QAInzenjer)zaposleni;
                            bw.Write(qa.BrojQATestova);
                        }
                    }
                }
                //automatsko zatvaranje fajla
            }
            catch(IOException ioe)
            {
                Console.WriteLine(ioe.Message);
            }
        }
        public void CitanjeBin(string nazivFajla)
        {
            BinaryReader br = null;
            try
            {
                br = new BinaryReader(new FileStream(nazivFajla, FileMode.Open));
                foreach(Zaposleni zaposleni in Zaposleni.Lista)
                {
                    zaposleni.Ime=br.ReadString();//ime
                    zaposleni.Prezime=br.ReadString();//prezime
                    zaposleni.Plata=br.ReadInt32();//plata
                    Console.Write("Ime: " + zaposleni.Ime + ", Prezime: " + zaposleni.Prezime + ", Plata: " + zaposleni.Plata);
                    if (zaposleni is WebDeveloper)
                    {
                        WebDeveloper wd = (WebDeveloper)zaposleni;
                        wd.BrojTehnologija=br.ReadInt32();//bw.Write(wd.Tehnologije.Length);
                                                          //bw.Write(wd.Tehnologije);
                        Console.Write(", Radno mesto: WebDeveloper, Broj tehnologija: "+wd.BrojTehnologija+", Tehnologije: ");
                        //foreach (string tehnologija in wd.Tehnologije)
                        //{
                           // int i = 0;
                            wd.Tehnologije = br.ReadString();
                            Console.Write(wd.Tehnologije + ", ");
                        //}
                        Console.WriteLine();
                    }
                    else if (zaposleni is DevOps)
                    {
                        DevOps dev = (DevOps)zaposleni;
                        string datumString = br.ReadString();
                        DateTime datum;
                        if(DateTime.TryParse(datumString,out datum))
                        {
                            dev.Datum = datum;
                            Console.WriteLine("Datum: " + dev.Datum);
                        }
                        else
                        {
                            Console.WriteLine("Neuspesna konverzija stringa u datum!");
                        }
                    }
                    else
                    {
                        QAInzenjer qa = (QAInzenjer)zaposleni;
                        qa.BrojQATestova = br.ReadInt32();
                        Console.WriteLine("Broj testova: " + qa.BrojQATestova);
                    }

                }
            }
            catch(IOException ioe)
            {
                Console.WriteLine(ioe.Message);
            }
        }
        public void proveraBonusa()
        {
            try
            {
                foreach (Zaposleni zaposleni in Zaposleni.Lista)
                {
                    float pom;
                    pom = zaposleni.bonus();
                    pom /= zaposleni.Plata;
                    if (pom > maxBonus)
                        throw new PrevelikiBonus("Prekoracen max bonus!");
                }
            }
            catch(PrevelikiBonus e)
            {
                //Console.WriteLine("Ups!");
            }
            
        }
    }
}
