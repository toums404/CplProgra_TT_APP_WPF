using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.Mail;

namespace CplProgra_TT_APP_WPF
{
    /// <summary>
    /// Logique d'interaction pour Mail.xaml
    /// </summary>
    public partial class Mail : Page
    {
        public Mail()
        {
            InitializeComponent();
        }

        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // 1. Récupération des données encodées par l'utilisateur
                string senderEmail = txtSenderEmail.Text;
                string senderPassword = txtSenderPassword.Password;
                string recipientEmail = txtRecipientEmail.Text;
                string subject = txtSubject.Text;
                string body = txtBody.Text;


                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);


                MailMessage mailMessage = new MailMessage(senderEmail, recipientEmail, subject, body);

                smtpClient.Send(mailMessage);

                MessageBox.Show("Le mail a été envoyé avec succès !", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (SmtpException smtpEx)
            {

                MessageBox.Show($"Erreur de serveur ou d'authentification : {smtpEx.Message}", "Erreur d'envoi", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Une erreur est survenue : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
