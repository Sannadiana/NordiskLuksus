using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using productStoreMVC.models;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace productStoreMVC.controllers{

    public class CustomerController:Controller{
   
        private readonly ProductContext _context;
        private readonly IHostingEnvironment _hosting;
        public CustomerController(ProductContext context, IHostingEnvironment hosting){
            _context = context;
            _hosting = hosting;
        }


public async Task<IActionResult> ShowAllProducts(){
    List<Product> productList = await _context.Product.Include("Comments").ToListAsync();
    return View (productList);
}



 
 [HttpGet]
        public IActionResult SetColor(){
            return View();
        }

        [HttpPost]
        public IActionResult SetColor([Bind("Color")] ColorChoice colorChoice){
            HttpContext.Session.SetString("Color", colorChoice.Color);
            return RedirectToAction(nameof(ShowAllProducts));
        } 
 

        public async Task<IActionResult> AllComments(){
            List<Product> commentList = await _context.Product.Include("Comments").ToListAsync();
            return View(commentList);
        }

        [HttpGet]
        public async Task<IActionResult> CommentProduct(int id){
            Product product = await _context.Product.SingleOrDefaultAsync( _product => _product.Id == id);
            ViewBag.Product = product;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CommentProduct([Bind("UserName", "Text", "ProductId")] Comment comment){
            _context.Comment.Add(comment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ShowAllProducts));
        }

    }

}