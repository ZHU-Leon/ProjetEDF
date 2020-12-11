using System;
using System.Collections.Generic;
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

namespace ProjetEDFWPF
{
    /// <summary>
    /// Logique d'interaction pour FrmStatutAdmin.xaml
    /// </summary>
    public partial class FrmStatutAdmin : Window
    {
        edfEntities gst;
        public FrmStatutAdmin(edfEntities unGst)
        {
            InitializeComponent();
            gst = unGst;
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            gst = new edfEntities();
            lstControleurs.ItemsSource = gst.controleur.ToList();
        }

        private void lstControleurs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstControleurs.SelectedItem !=null)
            {

                int idControleur = (lstControleurs.SelectedItem as controleur).id;
                lstClients.ItemsSource = gst.client.ToList().FindAll(cl => cl.idcontroleur == idControleur);
            }
        }

        private void lstClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnInsertControleur_Click(object sender, RoutedEventArgs e)
        {
            if (txtNomControleur == null)
            {
                MessageBox.Show("Veuillez saisir le nom du controleur", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (txtPrenomControleur == null)
            {
                MessageBox.Show("Veuillez saisir le prenom du controleur", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                controleur ctrl = new controleur()
                {
                    nom = (lstControleurs.SelectedItem as controleur).nom,
                    prenom = (lstControleurs.SelectedItem as controleur).prenom,


                };
                gst.controleur.Add(ctrl);
                gst.SaveChanges();
                MessageBox.Show("Le nouveau controleur a bien été inséré", "Insertion", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void BtnInsertClient_Click(object sender, RoutedEventArgs e)
        {

            if (txtNomClient == null)
            {
                MessageBox.Show("Veuillez saisir le nom du client", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (txtPrenomClient == null)
            {
                MessageBox.Show("Veuillez saisir le prenom du client", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                client cli = new client()
                {
                    nom = (lstClients.SelectedItem as client).nom,
                };
                 gst.client.Add(cli);
                 gst.SaveChanges();
                 MessageBox.Show("Le nouveau client a bien été inséré", "Insertion", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        
    }
}
