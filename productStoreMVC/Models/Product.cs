using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace productStoreMVC.models{
public class Product{
    [Key]
    public int Id {get; set;}
   
    [Required(ErrorMessage="Last opp bilde")]
    public string ImageSrc {get; set;}

    [Required(ErrorMessage="Produktet må ha en tittel")]
    public string Title {get; set;}

    [Required(ErrorMessage="Produktet må ha en beskrivelse")]
    public string Desc {get; set;}
    
    [Required(ErrorMessage="Produktet må ha en pris")]
    
    public double Price {get; set;}

    [ForeignKey("ProductId")]
    public ICollection<Comment> Comments { get; set; }

    
}
}