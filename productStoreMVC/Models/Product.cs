using System.ComponentModel.DataAnnotations;


namespace productStoreMVC.Models{
public class Product{
    [Key]

    public int ID {get; set;}
    public string Title {get; set;}
    public double Price {get; set;}
}
}