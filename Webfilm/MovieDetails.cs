using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webfilm
{
    public class MovieDetails
    {
        public string Title { get; set; }           // Tytuł filmu
        public string Overview { get; set; }        // Opis filmu
        public string ReleaseDate { get; set; }     // Data premiery
        public double Rating { get; set; }          // Ocena filmu (vote_average)
        public string PosterUrl { get; set; }       // Pełny URL do plakatu
    }
}
