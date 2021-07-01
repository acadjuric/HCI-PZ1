using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;

namespace Projekat1
{
    [Serializable]
    public class Stadion
    {
        
        private string naziv;

        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; }
        }

        private string adresa;

        public string Adresa
        {
            get { return adresa; }
            set { adresa = value; }
        }

        private string putanja_do_slike;

        public string Putanja_Do_Slike
        {
            get { return putanja_do_slike; }
            set { putanja_do_slike = value; }
        }

        private int kapacitet;

        public int Kapacitet
        {
            get { return kapacitet; }
            set { kapacitet = value; }

        }
        private string datum;

        public string Datum
        {
            get { return datum; }
            set { datum = value; }
        }

       [XmlIgnore]
        private BitmapImage slika;

        [XmlIgnore]
        public BitmapImage Slika
        {
            get { return slika; }
            set { slika = value; }
        }

      
        private string opis_stadiona;

        public string Opis_Stadiona
        {
            get { return opis_stadiona; }
            set { opis_stadiona = value; }
        }



        public Stadion() {  }

        public Stadion(string naziv, string adresa, string putanja_slika, int kapacitet, string dan, string mesec, string godina, string opis_stadiona)
        {
            
            this.naziv = naziv;
            this.adresa = adresa;
            this.putanja_do_slike = putanja_slika;
            this.opis_stadiona = opis_stadiona;
            this.kapacitet = kapacitet;
            this.datum = dan + "-" + mesec + "-" + godina;

        }
        


    }
}
