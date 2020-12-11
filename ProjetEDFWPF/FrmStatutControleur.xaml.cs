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
    /// Logique d'interaction pour FrmStatutControleur.xaml
    /// </summary>
    public partial class FrmStatutControleur : Window
    {
        edfEntities gst;
        public FrmStatutControleur(edfEntities unGst)
        {
            InitializeComponent();
            gst = unGst;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            gst = new edfEntities();

            lstClients.ItemsSource = gst.controleur.ToList();
        }

        private void lstClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnInsertReleve_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
