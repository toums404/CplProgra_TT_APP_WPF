using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace CplProgra_TT_APP_WPF
{
    public class TaskItem : INotifyPropertyChanged
    {
        private string title;
        private bool isDone;

        public string Title
        {
            get { return title; }
            set { title = value; OnPropertyChanged(); }
        }

        public bool IsDone
        {
            get { return isDone; }
            set { isDone = value; OnPropertyChanged(); }
        }

        // previent l'ui qu'une propriété a changé
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
