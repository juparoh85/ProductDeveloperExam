using ProductApp.Models;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ProductApp.Controllers
{
    public class ProductController : Controller
    {
        private ProductContext db = new ProductContext();

        // GET: Product
        public ActionResult Index()
        {
            try
            {
                return View(db.Products.ToList());
            }
            catch(Exception ex)
            {
                ViewBag.AlertMessage = ex.Message;
                return View();
            }
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)     
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Product product = db.Products.FirstOrDefault(x => x.Id == id);
            if(product == null)
                return HttpNotFound();
            return View(product);
        }

        // GET: Product/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    db.Products.Add(product);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Product product = db.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
                return HttpNotFound();    
            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        { 
            if(id==null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Product product=db.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
                return HttpNotFound();
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, string some = "")
        {
            try
            {
                Product product = new Product();
                // TODO: Add delete logic here
                if (ModelState.IsValid)
                {
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    product = db.Products.FirstOrDefault(x => x.Id == id);
                    if (product == null)
                        return HttpNotFound();
                    db.Products.Remove(product);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(product);
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/getProducts
        [HttpGet]
        public string getProducts()
        {
            return db.Products.ToList().ToString();
        }
    }
}
