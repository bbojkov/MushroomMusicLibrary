using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.MVP.EventArguments
{
    public class SearchDisplayEventArgs : EventArgs
    {
        public SearchDisplayEventArgs(string queryParams)
        {
            this.QueryParams = queryParams;
        }

        public string QueryParams { get; private set; }
    }
}
