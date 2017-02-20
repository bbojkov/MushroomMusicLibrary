namespace MusicLibrary.Models.Factories
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IBandFactory
    {
        Band CreateBandInstance();
    }
}
