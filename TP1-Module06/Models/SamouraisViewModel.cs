using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TP1_Module06.Models
{
    public class SamouraisViewModel
    {
        public Samourai Samourai { get; set; }

        public int? IdArme { get; set; }

        public List<SelectListItem> Armes { get; set; } = new List<SelectListItem>();

        public List<SelectListItem> ArtMartials { get; set; } = new List<SelectListItem>();

        public List<int> IdArtMartials { get; set; } = new List<int>();
    }
}