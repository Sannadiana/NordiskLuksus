using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NordiskLuksusMVC.Models{

    public class Product{

        [Key]
        public int Id { get; set; }       
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }

    }


}