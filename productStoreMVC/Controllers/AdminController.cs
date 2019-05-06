using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using productStoreMVC.models;

namespace productStoreMVC.Controllers{

/***************************************************************************************************************************** 
Dette er kontrolleren for administrasjonssiden og denne tar for seg logikken rundt å opprette, slette og endre produkter
/******************************************************************************************************************************/
public class AdminController:Controller{
private readonly ProductContext _context;

[HttpGet]
public async Task<IActionResult> AllProducts(){
    List<Product> productList = await _context.Product.Include("Comments").ToListAsync();
    return View (productList);
}

[HttpPost]
public async Task<IActionResult> CreateProduct([Bind("Id", "Title","Desc","Price")]Product product, IFormFile file){
       if(ModelState.IsValid){
        string wwwroot = _hosting.WebRootPath;
        string absolute = Path.Combine(wwwroot, "images", file.FileName);

        using(var filestream = new FileStream(absolute, FileMode.Create))
        file.CopyTo(filestream);
        product.ImageSrc = file.FileName;
         _context.Product.Add(product);
         await _context.SaveChangesAsync();
        return RedirectToAction(nameof(AllProducts));
    }else{
        return View(product);
    }
    
    
}


[HttpGet]
        public IActionResult CreateProduct(){
            return View();
        }

 
[HttpPost]
public async Task<IActionResult> EditProduct(int? id,[Bind("Id, Title,Desc, Price")]Product product, IFormFile file){
    if (file != null) {
        string wwwroot = _hosting.WebRootPath;
        string absolute = Path.Combine(wwwroot, "images", file.FileName);

        using(var filestream = new FileStream(absolute, FileMode.Create))
        file.CopyTo(filestream);
        product.ImageSrc = file.FileName;
    }
    
    _context.Update(product);
    
    await _context.SaveChangesAsync();
    return RedirectToAction(nameof(AllProducts));
}

[HttpGet]
public async Task<IActionResult> EditProduct(int? id){
    Product product = await _context.Product.SingleOrDefaultAsync(_product => _product.Id == id);
    return View(product);
}

//Ved å inkludere comments i DeleteProductConfirm så slettes også de tilknyttede kommentarene til dette produktet

[HttpPost,ActionName("DeleteProduct")]
public async Task<IActionResult> DeleteProductConfirm(int? id){
    Product product = await _context.Product.Include("Comments").SingleOrDefaultAsync(_product => _product.Id == id);
    
     _context.Product.Remove(product);
    await _context.SaveChangesAsync();
    return RedirectToAction(nameof(AllProducts));
}


[HttpGet]
public async Task<IActionResult> DeleteProduct(int? id){
    Product product = await _context.Product.SingleOrDefaultAsync(_product => _product.Id == id);
    return View(product);
}

private readonly IHostingEnvironment _hosting;
        public AdminController(ProductContext context, IHostingEnvironment hosting){
            _context = context;
            _hosting = hosting;
        }        
}
}