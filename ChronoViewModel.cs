using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using System.Windows.Threading;

namespace CplProgra_TT_APP_WPF
{
    public class ChronoViewModel : INotifyPropertyChanged
    {
        private ChronoModel _model;
        private DispatcherTimer _timer;
        private bool _isRunning;

        public double SecondsAngle => (_model.TotalSeconds % 60) * 6; // 6 degrés par seconde (360 / 60)
        public double MinutesAngle => (_model.TotalSeconds / 60.0) * 6;

        //boutons
        public ICommand StartCommand { get; }
        public ICommand StopCommand { get; }
        public ICommand ResetCommand { get; }

        public ChronoViewModel()
        {
            _model = new ChronoModel { TotalSeconds = 0 };

            //timer 1 tic / s
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += Timer_Tick;

            // Initialisation des RelayCommands 
            StartCommand = new RelayCommand(Start, CanStart);
            StopCommand = new RelayCommand(Stop, CanStop);
            ResetCommand = new RelayCommand(Reset, CanReset);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _model.TotalSeconds++;
            // notifier les changements de propriétés pour mettre à jour l'interface utilisateur
            OnPropertyChanged(nameof(SecondsAngle));
            OnPropertyChanged(nameof(MinutesAngle));
        }


        private void Start()
        {
            _timer.Start();
            _isRunning = true;
        }
        private bool CanStart() => !_isRunning; // Actif si non démarré

        private void Stop()
        {
            _timer.Stop();
            _isRunning = false;
        }
        private bool CanStop() => _isRunning; // Actif si démarré

        private void Reset()
        {
            _timer.Stop();
            _isRunning = false;
            _model.TotalSeconds = 0;
            OnPropertyChanged(nameof(SecondsAngle));
            OnPropertyChanged(nameof(MinutesAngle));
        }
        private bool CanReset() => _model.TotalSeconds > 0 || _isRunning;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
