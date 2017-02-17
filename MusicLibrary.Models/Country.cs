using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Models
{
    public class Country
    {
        public Country()
        {
            this.Bands = new HashSet<Band>();
        }

        public Guid Id { get; set; }

        public string CountryName { get; set; }

        public virtual ICollection<Band> Bands { get; set; }
    }
}
