using System.ComponentModel.DataAnnotations;


namespace productStoreMVC.Models{
public class Product{
    [Key]

    public int ID {get; set;}

    public string ImageSrc {get; set;}

    [Required(ErrorMessage="Produktet må ha en tittel")]
    public string Title {get; set;}

    public string Desc {get; set;}

     [Required(ErrorMessage="Produktet må ha en pris")] //(ErrorMessage="Produktet må ha en pris")
     [DataType(DataType.Currency)]
    public double Price {get; set;}
}
}