using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Models
{
    public class Apprentice
    {
        public int id { get; set; }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

    }
}