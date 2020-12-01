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

namespace Acquisti_
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtUtente.Focus();
            txtPrezzo.IsEnabled = false;
            txtQuantita.IsEnabled = false;
            cmbProdotto.IsEnabled = false;
            btnPulisci.IsEnabled = false;
            btnStampa.IsEnabled = false;
            btnRimuoviSelezione.IsEnabled = false;
        }
        private const string PASS = "QuartaAI";
        private string utente;

        private void BtnAccedi_Click(object sender, RoutedEventArgs e)
        {
            if(txtUtente.Text!=""&& txtPassword.Text!="")
            {
                if(txtPassword.Text==PASS)
                {
                    string utente = txtUtente.Text;

                    txtUtente.IsEnabled = false;
                    txtPassword.IsEnabled = false;
                    btnAccedi.IsEnabled = false;

                    txtPrezzo.IsEnabled = true;
                    txtQuantita.IsEnabled = true;
                    cmbProdotto.IsEnabled = true;
                    btnStampa.IsEnabled = true;
                    btnPulisci.IsEnabled = true;
                    btnRimuoviSelezione.IsEnabled = true;
                    lstSelezione.IsEnabled = true;
                }
                else
                {
                    MessageBox.Show("PASSWORD ERRATA");
                }
            }
        }

        private void BtnPulisci_Click(object sender, RoutedEventArgs e)
        {
            cmbProdotto.SelectedItem = null;
            txtPrezzo.Text = null;
            txtQuantita.Text = null;
        }

        private void BtnRimuoviSelezione_Click(object sender, RoutedEventArgs e)
        {
            lstSelezione.Items.RemoveAt(lstSelezione.SelectedIndex);
        }

        private void BtnStampa_Click(object sender, RoutedEventArgs e)
        {
            string item;
            string prodotto = ((ComboBoxItem)cmbProdotto.SelectedItem).Content.ToString();
            double prezzo_prodotto = double.Parse(txtPrezzo.Text);
            int quantita = int.Parse(txtQuantita.Text);
            double prezzo = prezzo_prodotto * quantita;
            item = $"l'utente {utente} ha acquistato {quantita} {prodotto} al prezzo di {prezzo}€";
            lstSelezione.Items.Add(item);
        }
    }
}
