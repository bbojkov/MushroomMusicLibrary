using MusicLibrary.MVP.EventArguments;
using MusicLibrary.MVP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace MusicLibrary.MVP.Views
{
    public interface ISearchDisplayView : IView<SearchDisplayModel>
    {
        event EventHandler<SearchDisplayEventArgs> OnSearchDisplayBands;
    }
}
