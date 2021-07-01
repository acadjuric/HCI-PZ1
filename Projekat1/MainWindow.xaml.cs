using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projekat1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static BindingList<Stadion> Stadioni { get; set; }
        private DataIO serializer = new DataIO();
        
        public MainWindow()
        {
            Stadioni = serializer.DeSerializeObject<BindingList<Stadion>>("stadioni.xml");
            if (Stadioni == null)
            {
                Stadioni = new BindingList<Stadion>();
            }
            DataContext = this;
            InitializeComponent();
            
            
            
        }

        private void DugmeIzlaz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DugmeZaDodavanje_Click(object sender, RoutedEventArgs e)
        {
            Dodavanje_Novog_Stadiona novi_stadion = new Dodavanje_Novog_Stadiona();
            novi_stadion.ShowDialog();
            
        }

        private void Sacuvaj_podatke(object sender, CancelEventArgs e)
        {
            serializer.SerializeObject<BindingList<Stadion>>(Stadioni, "stadioni.xml");
        }

        private void DugmeProcitaj_Click(object sender, RoutedEventArgs e)
        {
            Stadion model = (sender as Button).DataContext as Stadion;
            Prikaz_Sadrzaja sadrzaj = new Prikaz_Sadrzaja();
            if (model != null)
            {
                sadrzaj.SadrzajAdresa.Content = model.Adresa;
                sadrzaj.SadrzajNaziv.Content = model.Naziv;
                sadrzaj.TextBoxOpisStadiona.Text = model.Opis_Stadiona;

                Uri uri = new Uri(model.Putanja_Do_Slike);
                BitmapImage image = new BitmapImage(uri);
                sadrzaj.SadrzajSlika.Source = image;
                sadrzaj.ShowDialog();
            }
            else
            {
                MessageBox.Show("Greška kod čitanja", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }



        }

        private void DugmeIzbrisi_Click(object sender, RoutedEventArgs e)
        {
            Stadion model = (sender as Button).DataContext as Stadion;
            if (model != null)
            {

                if(
                 MessageBox.Show("Da li zaista želite da obrišete stadion?", "Pitanje", MessageBoxButton.YesNo,
                 MessageBoxImage.Question) == MessageBoxResult.Yes)
                { Stadioni.Remove(model); }
                
                
                
            }
            else
            {
                MessageBox.Show("Brisanje nije moguće!", "Greška", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            
        }

        private void DugmeIzmeni_Click(object sender, RoutedEventArgs e)
        {
            Stadion model = (sender as Button).DataContext as Stadion;
            
            if (model != null)
            {
                Dodavanje_Novog_Stadiona novi = new Dodavanje_Novog_Stadiona();
                

                novi.TextBoxNaziv.Text = model.Naziv;
                novi.TextBoxLokacija.Text = model.Adresa;
                novi.TextBoxKapacitet.Text = model.Kapacitet.ToString();
                novi.TextBoxOpisStadiona.Text = model.Opis_Stadiona;


                Uri uri = new Uri(model.Putanja_Do_Slike);
                BitmapImage image = new BitmapImage(uri);
                novi.PoljeZaSliku.Source = image;
                novi.slika = image;
                novi.putanja = model.Putanja_Do_Slike;

                string[] delovi_datuma = model.Datum.Split('-');
                novi.ComoBoxDan.Text = delovi_datuma[0];
                novi.ComoBoxMesec.Text = delovi_datuma[1];
                novi.ComoBoxGodina.Text = delovi_datuma[2];
                novi.slika_ucitana = true;
                
                
                novi.ShowDialog();
                


            }
            else
            {
                MessageBox.Show("Greška kod izmene!","Greška",MessageBoxButton.OK,MessageBoxImage.Error);
            }



            
        }

        
    }
}
