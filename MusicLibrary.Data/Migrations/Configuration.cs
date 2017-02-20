using MusicLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace MusicLibrary.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<MusicLibrary.Data.MusicLibraryContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MusicLibrary.Data.MusicLibraryContext context)
        {
            var countriesAsString =
                @"Andorra;United Arab Emirates;Afghanistan;Antigua and Barbuda;Anguilla;Albania;Armenia;Angola;Antarctica;Argentina;    
                    American Samoa;Austria;Australia;Aruba;Åland Islands;Azerbaijan;Bosnia and Herzegovina;Barbados;Bangladesh;Belgium;
                    Burkina Faso;Bulgaria;Bahrain;Burundi;Benin;Saint Barthélemy;Bermuda;Brunei Darussalam;Bolivia;Caribbean Netherlands;
                    Brazil;Bahamas;Bhutan;Bouvet Island;Botswana;Belarus;Belize;Canada;Cocos (Keeling) Islands;Congo, Democratic Republic of;
                    Central African Republic;Congo;Switzerland;Côte d'Ivoire;Cook Islands;Chile;Cameroon;China;Colombia;Costa Rica;Cuba;Cape Verde;
                    Curaçao;Christmas Island;Cyprus;Czech Republic;Germany;Djibouti;Denmark;Dominica;Dominican Republic;Algeria;Ecuador;Estonia;Egypt;
                    Western Sahara;Eritrea;Spain;Ethiopia;Finland;Fiji;Falkland Islands;Micronesia, Federated States of;Faroe Islands;France;Gabon;
                    United Kingdom;Grenada;Georgia;French Guiana;Guernsey;Ghana;Gibraltar;Greenland;Gambia;Guinea;Guadeloupe;Equatorial Guinea;Greece;
                    South Georgia and the South Sandwich Islands;Guatemala;Guam;Guinea-Bissau;Guyana;Hong Kong;Heard and McDonald Islands;Honduras;Croatia;
                    Haiti;Hungary;Indonesia;Ireland;Israel;Isle of Man;India;British Indian Ocean Territory;Iraq;Iran;Iceland;Italy;Jersey;Jamaica;Jordan;Japan;
                    Kenya;Kyrgyzstan;Cambodia;Kiribati;Comoros;Saint Kitts and Nevis;North Korea;South Korea;Kuwait;Cayman Islands;Kazakhstan;Lao People's Democratic Republic;
                    Lebanon;Saint Lucia;Liechtenstein;Sri Lanka;Liberia;Lesotho;Lithuania;Luxembourg;Latvia;Libya;Morocco;Monaco;Moldova;Montenegro;Saint-Martin (France);
                    Madagascar;Marshall Islands;Macedonia;Mali;Myanmar;Mongolia;Macau;Northern Mariana Islands;Martinique;Mauritania;Montserrat;Malta;Mauritius;Maldives;
                    Malawi;Mexico;Malaysia;Mozambique;Namibia;New Caledonia;Niger;Norfolk Island;Nigeria;Nicaragua;The Netherlands;Norway;Nepal;Nauru;Niue;New Zealand;Oman;
                    Panama;Peru;French Polynesia;Papua New Guinea;Philippines;Pakistan;Poland;St. Pierre and Miquelon;Pitcairn;Puerto Rico;Palestine, State of;Portugal;Palau;
                    Paraguay;Qatar;Réunion;Romania;Serbia;Russian Federation;Rwanda;Saudi Arabia;Solomon Islands;Seychelles;Sudan;Sweden;Singapore;Saint Helena;Slovenia;
                    Svalbard and Jan Mayen Islands;Slovakia;Sierra Leone;San Marino;Senegal;Somalia;Suriname;South Sudan;Sao Tome and Principe;El Salvador;Sint Maarten (Dutch part);
                    Syria;Swaziland;Turks and Caicos Islands;Chad;French Southern Territories;Togo;Thailand;Tajikistan;Tokelau;Timor-Leste;Turkmenistan;Tunisia;Tonga;Turkey;
                    Trinidad and Tobago;Tuvalu;Taiwan;Tanzania;Ukraine;Uganda;United States Minor Outlying Islands;United States;Uruguay;Uzbekistan;Vatican;Saint Vincent and the Grenadines;
                    Venezuela;Virgin Islands (British);Virgin Islands (U.S.);Vietnam;Vanuatu;Wallis and Futuna Islands;Samoa;Yemen;Mayotte;South Africa;Zambia;Zimbabwe"
                    .Split(new char[] { ';' });

            IList<Country> countries = new List<Country>();

            for (int i = 0; i < countriesAsString.Length; i++)
            {
                countries.Add(new Country() { Id = Guid.NewGuid(), CountryName = countriesAsString[i].Trim() });
            }
            context.Countries.AddOrUpdate(countries.ToArray());


            IList<Genre> genres = new List<Genre>()
            {
                new Genre() { Id = Guid.NewGuid(), GenreName = "Metal" },
                new Genre() { Id = Guid.NewGuid(), GenreName = "Grindcore" },
                new Genre() { Id = Guid.NewGuid(), GenreName = "Pop" }
            };


            IList<Band> bands = new List<Band>()
            {
                new Band() {Id = Guid.NewGuid(), BandName = "A day to remember", Country = countries[0], Genre = genres[0] },
                new Band() {Id = Guid.NewGuid(), BandName = "Aerosmith", Country = countries[0], Genre = genres[1] },
                new Band() {Id = Guid.NewGuid(), BandName = "Behemoth", Country = countries[33], Genre = genres[0] },
                new Band() {Id = Guid.NewGuid(), BandName = "Demon Hunter", Country = countries[6], Genre = genres[2] },
                new Band() {Id = Guid.NewGuid(), BandName = "Faith No More", Country = countries[6], Genre = genres[0] },
            };

            context.Bands.AddOrUpdate(bands.ToArray());
        }
    }
}
