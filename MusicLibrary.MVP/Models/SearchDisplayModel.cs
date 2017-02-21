using MusicLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.MVP.Models
{
    public class SearchDisplayModel
    {
        public IEnumerable<Band> Bands { get; set; }
    }
}
