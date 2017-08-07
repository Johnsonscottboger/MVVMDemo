using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApplication2.Command;
using WpfApplication2.Model;

namespace WpfApplication2.ViewModel
{
    public class SongViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Song _song;
        public SongViewModel()
        {
            this._song = new Song() { ArtistName = "陈奕迅", SongTitle = "十年" };
        }

        public Song Song
        {
            get { return this._song; }
        }

        public string ArtistName
        {
            get { return this._song.ArtistName; }
            set
            {
                this._song.ArtistName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ArtistName"));
            }
        }

        #region 命令
        private async Task UpdateArtistNameExecuteAsync()
        {
            await Task.Delay(5000);
            this.ArtistName = "周杰伦";
        }

        private bool CanUpdateArtistNameExecute()
        {
            return this.ArtistName != "周杰伦";
        }

        public ICommand UpdateArtistNameCommand
        {
            get { return new RelayCommand(UpdateArtistNameExecuteAsync, CanUpdateArtistNameExecute); }
        }
        #endregion
    }
}
