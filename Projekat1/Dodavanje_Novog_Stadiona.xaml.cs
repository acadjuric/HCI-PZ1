using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Projekat1
{
    /// <summary>
    /// Interaction logic for Dodavanje_Novog_Stadiona.xaml
    /// </summary>
    public partial class Dodavanje_Novog_Stadiona : Window
    {
        private Stadion novi_stadion;
        public string putanja = "";
        public bool slika_ucitana = false;
        public Uri pomoc_putanja { get; set; }
        public  BitmapImage slika { get; set; }
        private int index;
        

        private uint kapacitet_stadiona;

        public Dodavanje_Novog_Stadiona()
        {
        
            InitializeComponent();
            ComoBoxDan.ItemsSource = Kalendar.dani;
            ComoBoxMesec.ItemsSource = Kalendar.meseci;
            ComoBoxGodina.ItemsSource = Kalendar.godine;

        }

       

        private void DugmeOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DugmeZavrsi_Click(object sender, RoutedEventArgs e)
        {
            if (provera())
            {
                
                novi_stadion = new Stadion(TextBoxNaziv.Text, TextBoxLokacija.Text, putanja,(int)kapacitet_stadiona,
                    ComoBoxDan.Text, ComoBoxMesec.Text, ComoBoxGodina.Text,TextBoxOpisStadiona.Text);
                novi_stadion.Slika = slika;
                
                
                
                
                    //ako postoji  samo azuriraj
                    if ( provera_za_dodavanje(novi_stadion) )
                    {
                        MainWindow.Stadioni.RemoveAt(index);

                        if (provera_za_dodavanje(novi_stadion))
                        {
                            MainWindow.Stadioni.RemoveAt(index);
                            MainWindow.Stadioni.Insert(index, novi_stadion);

                        }
                        else
                        {
                            MainWindow.Stadioni.Insert(index, novi_stadion);
                        }


                        
                    }
                    else
                    {
                        
                        
                        MainWindow.Stadioni.Add(novi_stadion);
                        
                    }
                this.Close();
            }
            else
            {
                MessageBox.Show("Podaci nisu dobro popunjeni.", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void DugmeZaSliku_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Izaberite sliku";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                pomoc_putanja = new Uri(op.FileName);
                slika = new BitmapImage(pomoc_putanja);
                PoljeZaSliku.Source = slika;

                putanja = PoljeZaSliku.Source.ToString();
                if (putanja != "")
                {
                    slika_ucitana = true;
                }
                
            }
            
            
        }


        private bool provera()
        {
            bool rez = true;
           
            

            //naziv
            if (TextBoxNaziv.Text.Equals(string.Empty))
            {
                rez = false;
                TextBoxNaziv.BorderBrush = Brushes.Red;
                TextBoxNaziv.BorderThickness = new Thickness(1);
            }
            else
            {
               
                

                    if (provera_za_unos_stringa(TextBoxNaziv.Text))
                    {
                        if (TextBoxNaziv.Text.Contains(','))
                        {
                            rez = false;
                            TextBoxNaziv.BorderBrush = Brushes.Red;
                            TextBoxNaziv.BorderThickness = new Thickness(1);
                        }
                        else
                        {
                            TextBoxNaziv.BorderBrush = Brushes.Green;
                            TextBoxNaziv.BorderThickness = new Thickness(1);
                        }
                        
                    }
                    else {
                        rez = false;
                        TextBoxNaziv.BorderBrush = Brushes.Red;
                        TextBoxNaziv.BorderThickness = new Thickness(1);
                    }

                    
                
                
            }
            //lokacija == adresa
            if (TextBoxLokacija.Text.Equals(string.Empty))
            {
                rez = false;
                TextBoxLokacija.BorderBrush = Brushes.Red;
                TextBoxLokacija.BorderThickness = new Thickness(1);
            }
            else
            {
                
                
                    if (provera_za_unos_stringa(TextBoxLokacija.Text))
                    {
                        if (TextBoxLokacija.Text.ElementAt(0).Equals(','))
                        {
                            rez = false;
                            TextBoxLokacija.BorderBrush = Brushes.Red;
                            TextBoxLokacija.BorderThickness = new Thickness(1);
                        }
                        else
                        {
                            TextBoxLokacija.BorderBrush = Brushes.Green;
                            TextBoxLokacija.BorderThickness = new Thickness(1);
                        }

                    }
                    else
                    {
                        rez = false;
                        TextBoxLokacija.BorderBrush = Brushes.Red;
                        TextBoxLokacija.BorderThickness = new Thickness(1);
                    }
                
            }
            // za kapacitet
            if (TextBoxKapacitet.Text.Equals(string.Empty))
            {
                rez = false;
                TextBoxKapacitet.BorderBrush = Brushes.Red;
                TextBoxKapacitet.BorderThickness = new Thickness(1);
            }
            else
            {
                try
                {
                    kapacitet_stadiona = UInt32.Parse(TextBoxKapacitet.Text);
                    TextBoxKapacitet.BorderBrush = Brushes.Green;
                    TextBoxKapacitet.BorderThickness = new Thickness(1);

                }
                catch (Exception e)
                {
                    rez = false;
                    TextBoxKapacitet.BorderBrush = Brushes.Red;
                    TextBoxKapacitet.BorderThickness = new Thickness(1);
                    MessageBox.Show("Molimo Vas unesite pozitivan broj kao kapacitet stadiona.", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            
            //provera za datum
            if (ComoBoxDan.Text.Equals(string.Empty))
            {
                rez = false;
                ComoBoxDan.BorderBrush = Brushes.Red;
                ComoBoxDan.BorderThickness = new Thickness(1);
            }
            else
            {
                ComoBoxDan.BorderBrush = Brushes.Green;
                ComoBoxDan.BorderThickness = new Thickness(1);
            }

            if (ComoBoxMesec.Text.Equals(string.Empty))
            {
                rez = false;
                ComoBoxMesec.BorderBrush = Brushes.Red;
                ComoBoxMesec.BorderThickness = new Thickness(1);

            }
            else
            {
                bool pronasao = false;
                bool crveno_zeleno = true;
                int temp = Int32.Parse(ComoBoxDan.Text);
                if (temp >30 )
                {
                    foreach(string s in Kalendar.meseci_koji_imaju_31_dan)
                    {
                        if (ComoBoxMesec.Text.Equals(s))
                        {
                            pronasao = true;
                        }
                    }

                    if (pronasao == false)
                    {
                        rez = false;
                        crveno_zeleno = false;
                        ComoBoxMesec.BorderBrush = Brushes.Red;
                        ComoBoxMesec.BorderThickness = new Thickness(1);
                        MessageBox.Show("Mesec koji ste izabrali nema 31 dan!", "Greška u datumu!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }

                if (ComoBoxMesec.Text.Equals("Februar"))
                {
                    if (temp == 30)
                    {
                        rez = false;
                        crveno_zeleno = false;
                        ComoBoxMesec.BorderBrush = Brushes.Red;
                        ComoBoxMesec.BorderThickness = new Thickness(1);
                        string str = "Mesec Februar nema " + ComoBoxDan.Text + " dana!";
                        MessageBox.Show(str,"Greška u datumu!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }

                if(crveno_zeleno != false)
                {
                    ComoBoxMesec.BorderBrush = Brushes.Green;
                    ComoBoxMesec.BorderThickness = new Thickness(1);
                }
                

            }
            if (ComoBoxGodina.Text.Equals(string.Empty))
            {
                rez = false;
                ComoBoxGodina.BorderBrush = Brushes.Red;
                ComoBoxGodina.BorderThickness = new Thickness(1);

            }
            else
            {
                ComoBoxGodina.BorderBrush = Brushes.Green;
                ComoBoxGodina.BorderThickness = new Thickness(1);
            }
            // provera za opis stadiona
            if (TextBoxOpisStadiona.Text.Equals(string.Empty))
            {
                rez = false;
                TextBoxOpisStadiona.BorderBrush = Brushes.Red;
                TextBoxOpisStadiona.BorderThickness = new Thickness(1);
            }
            else
            {
                try
                {
                    long  tem = long.Parse(TextBoxOpisStadiona.Text);
                    
                    rez = false;
                    TextBoxOpisStadiona.BorderBrush = Brushes.Red;
                    TextBoxOpisStadiona.BorderThickness = new Thickness(1);
                }
                catch (Exception e)
                {
                    if (provera_za_opis_stadiona(TextBoxOpisStadiona.Text))
                    {
                        if (TextBoxOpisStadiona.Text.Length < 15)
                        {
                            rez = false;
                            TextBoxOpisStadiona.BorderBrush = Brushes.Red;
                            TextBoxOpisStadiona.BorderThickness = new Thickness(1);
                            MessageBox.Show("Molimo Vas unesite duži opis.", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else {

                            TextBoxOpisStadiona.BorderBrush = Brushes.Green;
                            TextBoxOpisStadiona.BorderThickness = new Thickness(1);
                        }
                        
                    }
                    else
                    {
                        rez = false;
                        TextBoxOpisStadiona.BorderBrush = Brushes.Red;
                        TextBoxOpisStadiona.BorderThickness = new Thickness(1);
                    }
                }
            }

            //provera za sliku
            if (!slika_ucitana) 
            {
                rez = false;
                MessageBox.Show("Molimo Vas da učitate sliku.", "Slika nije učitana.", MessageBoxButton.OK, MessageBoxImage.Information);
                DugmeZaSliku.BorderBrush = Brushes.Red;
                DugmeZaSliku.BorderThickness = new Thickness(1);

            }
            else
            {
                DugmeZaSliku.BorderBrush = Brushes.Green;
                DugmeZaSliku.BorderThickness = new Thickness(1);
            }
            
            return rez;
        }

        private bool provera_za_dodavanje(Stadion s1) 
        {
            bool rez = false;

            foreach(Stadion s2 in MainWindow.Stadioni)
            {
                if (s1.Naziv.Equals(s2.Naziv)) { rez = true; index = MainWindow.Stadioni.IndexOf(s2); break; }
             //   else if (s1.Adresa.Equals(s2.Adresa)) { rez = true; index = MainWindow.Stadioni.IndexOf(s2); break; }
                else if (s1.Opis_Stadiona.Equals(s2.Opis_Stadiona)) { rez = true; index = MainWindow.Stadioni.IndexOf(s2); break; }
             //   else if (s1.Putanja_Do_Slike.Equals(s2.Putanja_Do_Slike)) { rez = true; index = MainWindow.Stadioni.IndexOf(s2); break; }
              
            }

            

            return rez;

        }

        private List<char> ono_sto_ne_treba = new List<char>() {'`', '~','!','@','#','$','%','^','&',
            '*','(',')','-','=','_','+','[',']','}','{', '|','"',';',':','?','/','.', '>','<','0','1','2','3','4','5','6','7','8','9'};
        //falee ' i \        

        private bool provera_za_unos_stringa(string a)
        {
            bool rez = true;
            
            foreach(char c in ono_sto_ne_treba)
            {
                if (a.Contains(c))
                {
                    rez = false;
                }
            }
            return rez;
        }

        private List<char> ono_sto_ne_treba_za_opis = new List<char>() { '`', '~','@','#','$','%','^','&',
            '*','=','_','+','[',']','}','{', '|',';','/','>','<','!','?'};
        private bool provera_za_opis_stadiona(string a)
        {
            bool rez = true;

            foreach (char c in ono_sto_ne_treba_za_opis)
            {
                if (a.Contains(c))
                {
                    rez = false;
                }
            }
            return rez;

        }
    }
}
