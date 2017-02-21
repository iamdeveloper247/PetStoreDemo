using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetStoreDemo.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }

        public string imgname { get; set; }
        public byte[] img { get; set; }

        public int statusId { get; set; }
        [ForeignKey("statusId")]
        public Status status { get; set; }
    

    }
}