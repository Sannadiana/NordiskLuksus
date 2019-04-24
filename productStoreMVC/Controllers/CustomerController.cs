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


public async Task<IActionResult> AllProducts(){
    List<Product> productList = await _context.Product.ToListAsync();
    return View (productList);
}



 

        public async Task<IActionResult> AllComments(){
            List<Comment> commentList = await _context.Comment.ToListAsync();
            return View(commentList);
        }

        [HttpGet]
        public async Task<IActionResult> CommentProduct(int id){
            Product product = await _context.Product.SingleOrDefaultAsync( _product => _product.ID == id);
            ViewBag.Product = product;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CommentProduct([Bind("UserName", "Text", "MovieId")] Comment comment){
            _context.Comment.Add(comment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(AllProducts));
        }

    }

}