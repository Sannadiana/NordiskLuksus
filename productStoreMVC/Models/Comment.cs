using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using productStoreMVC.models;

namespace productStoreMVC.models{

    public class Comment{
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Text { get; set; }
        [ForeignKey("ProductID")]
        public int? ProductID { get; set; }

        public Product Product{ get; set; }

        public override string ToString(){
            return $"{Id} {UserName} {Text} {ProductID}";
        }

    }

}