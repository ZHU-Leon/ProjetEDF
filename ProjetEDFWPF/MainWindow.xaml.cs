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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjetEDFWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        edfEntities gst;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            gst = new edfEntities();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            controleur leCtrl = gst.controleur.ToList().Find(ctrl => ctrl.login == txtLogin.Text && ctrl.mdp == txtMDP.Text);
           
            if (txtLogin.Text == "")
            {
                txtErreur.Text = "Saisir votre login";
            }
            else if (txtMDP.Text == "")
            {
                txtErreur.Text = "Saisir votre mot de passe";
            }
            else
             if (leCtrl == null)
            {
                //MessageBox.Show("Votre compte n'existe pas", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtErreur.Text = "Votre compte n'existe pas";
            }
            else
            {
                if (leCtrl.statut == "admin")
                {
                    FrmStatutAdmin frm = new FrmStatutAdmin(gst);
                    frm.Show();
                }
                else
                {
                    FrmStatutControleur frm = new FrmStatutControleur(gst);
                    frm.Show();
                }
            }
        }
    }
}
