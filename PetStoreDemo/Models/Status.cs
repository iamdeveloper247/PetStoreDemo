using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetStoreDemo.Models
{
    public class Status
    {
        public int Id { get; set; }
        public string name { get; set; }

        public ICollection<Pet> Pets { get; set; }
    }
}