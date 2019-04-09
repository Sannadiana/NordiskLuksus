using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using productStoreMVC.Models;

namespace productStoreMVC.Controllers{

public class TheProductsController:Controller{
private readonly ProductContext _context;

public TheProductsController(ProductContext context){
    _context = context;
}

public async Task<IActionResult> AllProducts(){
    List<Product> productList = await _context.Product.ToListAsync();
    return View (productList);
}


public async Task<IActionResult> EditProduct(int? id){
    Product product = await _context.Product.SingleOrDefaultAsync(_product => _product.ID == id);
    return View(product);
}

[HttpPost]

public async Task<IActionResult> EditProduct(int? id,[Bind("ID, Title, Price")]Product product){
    _context.Update(product);
    await _context.SaveChangesAsync();
    return RedirectToAction(nameof(AllProducts));
}


public async Task<IActionResult> DeleteProduct(int? id){
     Product product = await _context.Product.SingleOrDefaultAsync(_product => _product.ID == id);
    return View(product);
}

[HttpPost,ActionName("DeleteMovie")]


public async Task<IActionResult> DeleteProductConfirm(int? id){
    Product product = await _context.Product.SingleOrDefaultAsync(_product => _product.ID == id);
     _context.Product.Remove(product);
    await _context.SaveChangesAsync();
    return RedirectToAction(nameof(AllProducts));
}


public IActionResult CreateProduct(){
    return View();
}

[HttpPost]

public async Task<IActionResult> CreateProduct([Bind("ID, Title,Price")]Product product){
    _context.Add(product);
    await _context.SaveChangesAsync();
    return RedirectToAction(nameof(AllProducts));
}

}
}