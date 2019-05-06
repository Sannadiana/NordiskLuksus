using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using productStoreMVC.models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace productStoreMVC.controllers{
/***************************************************************************************************************************** 
Dette er kontrolleren for kundesiden og den tar for seg logikken rundt å 
illustrere produkter, gi dem kommentarer og personalisere fargetemaet til kundesiden. 
/******************************************************************************************************************************/
public class CustomerController:Controller{
   
 private readonly ProductContext _context;
       

public async Task<IActionResult> ShowAllProducts(){
    List<Product> productList = await _context.Product.Include("Comments").ToListAsync();
    return View (productList);
}

[HttpPost]
        public async Task<IActionResult> CommentProduct([Bind("UserName", "Text", "ProductId")] Comment comment){
            _context.Comment.Add(comment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ShowAllProducts));
        }

[HttpGet]
        public async Task<IActionResult> CommentProduct(int id){
            Product product = await _context.Product.SingleOrDefaultAsync( _product => _product.Id == id);
            ViewBag.Product = product;
            return View();
        }

        public async Task<IActionResult> AllComments(){
            List<Product> commentList = await _context.Product.Include("Comments").ToListAsync();
            return View(commentList);
        }
    
[HttpPost]
        public IActionResult SetColor([Bind("Color")] ColorChoice colorChoice){
            HttpContext.Session.SetString("Color", colorChoice.Color);
            return RedirectToAction(nameof(ShowAllProducts));
        } 

 [HttpGet]
        public IActionResult SetColor(){
            return View();
        }

 
  private readonly IHostingEnvironment _hosting;
        public CustomerController(ProductContext context, IHostingEnvironment hosting){
            _context = context;
            _hosting = hosting;
        }

    }

}