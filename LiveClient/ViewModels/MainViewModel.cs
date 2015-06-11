using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveClient.ViewModels
{
    class MainViewModel : ReactiveObject
    {
        public MainViewModel()
        {
            //IObservable<bool> Initailized = this.WhenAnyValue(x => true);

            this.MuteCommand = ReactiveCommand.Create(null);
            this.MuteCommand.Subscribe(x => { this.IsMute = !this.IsMute; });
        }

        #region "Properties"

        private float _volume = -1f;

        /// <summary>
        /// 音量
        /// </summary>
        public float Volume
        {
            get { return _volume; }
            set { this.RaiseAndSetIfChanged(ref _volume, value); }
        }


        private bool _isMute;

        public bool IsMute
        {
            get { return _isMute; }
            set { this.RaiseAndSetIfChanged(ref _isMute, value); }
        }
        

        #endregion

        #region "Commands"

        public ReactiveCommand<object> MuteCommand { get; private set; }

        #endregion
    }
}
