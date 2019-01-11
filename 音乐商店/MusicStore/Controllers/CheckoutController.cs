using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    public class CheckoutController : Controller
    {
        MusicStoreDB db = new MusicStoreDB();
        string PromoCode = "YouHui";
        public ActionResult AddressAndPayment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddressAndPayment(FormCollection values)
        {
            var order = new Order();
            TryUpdateModel(order);

            try
            {
                if(string.Equals(values["PromoCode"],PromoCode,StringComparison.OrdinalIgnoreCase) == false)
                {
                    return View(order);
                }
                else
                {
                    order.Username = User.Identity.Name;
                    order.OrderDate = DateTime.Now;

                    db.Orders.Add(order);
                    db.SaveChanges();
                }
            }
            catch(Exception e)
            {
                return View(order);
            }

            //return View();
            return RedirectToAction("Complete", new { id = order.OrderId });
        }
        public ActionResult Complete(int id)
        {
            bool isValid = db.Orders.Any(x => x.OrderId == id && x.Username == User.Identity.Name);
            if(isValid)
            {
                return View(id);
            }
            else
            {
                return View("Error");
            }
        }
        public ActionResult Index()
        {
            return View(db.Orders.ToList());
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }



    }
}