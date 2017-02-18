﻿using System;
using System.Collections.Generic;

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
