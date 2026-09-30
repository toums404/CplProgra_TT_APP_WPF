using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

namespace CplProgra_TT_APP_WPF
{
    /// <summary>
    /// Logique d'interaction pour TodoPage.xaml
    /// </summary>
    public partial class TodoPage : Page
    {
        private ObservableCollection<TaskItem> myTasks;

        // chemin pour fichier de save dans le repertoire du projet
        private string saveFilePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "todolist.txt");

        public TodoPage()
        {
            InitializeComponent();
            myTasks = new ObservableCollection<TaskItem>();

            //liaison de notre liste a la lsb
            lstTasks.ItemsSource = myTasks;

            //on charge les taches sauvegardées si elles existent
            LoadTasks();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNewTask.Text))
            {
                myTasks.Add(new TaskItem { Title = txtNewTask.Text, IsDone = false });
                txtNewTask.Clear();
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
   
            if (lstTasks.SelectedItem is TaskItem selectedTask)
            {
                myTasks.Remove(selectedTask);
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //ecriture des taches fichier txt
                using (StreamWriter writer = new StreamWriter(saveFilePath))
                {
                    foreach (var task in myTasks)
                    {
                        writer.WriteLine($"{task.IsDone}|{task.Title}");
                    }
                }
                MessageBox.Show("To-Do list enregistrée avec succès !", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'enregistrement : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadTasks()
        {
            if (File.Exists(saveFilePath))
            {
                try
                {
                    string[] lines = File.ReadAllLines(saveFilePath);
                    foreach (string line in lines)
                    {
                        //decoupe la ligne au format "IsDone|Title"
                        string[] parts = line.Split('|');
                        if (parts.Length == 2)
                        {
                            bool isDone = bool.Parse(parts[0]);
                            string title = parts[1];
                            myTasks.Add(new TaskItem { IsDone = isDone, Title = title });
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Erreur lors du chargement de la sauvegarde précédente.");
                }
            }
        }
    }
}
