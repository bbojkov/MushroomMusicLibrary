using MusicLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.MVP.EventArguments
{
    public class SingleBandEventArgs : EventArgs
    {
        public SingleBandEventArgs(string userId, Guid bandId)
        {
            this.UserId = userId;
            this.BandId = bandId;
        }

        public string UserId { get; private set; }

        public Guid BandId { get; private set; }
    }
}
