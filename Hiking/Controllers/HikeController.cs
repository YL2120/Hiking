using Hiking.Data;
using Hiking.Data.DataLayers;
using Hiking.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hiking.Controllers
{
    [Authorize]
    public class HikeController : Controller
    {

        private readonly HikingContext context;
        private HikeDataLayer hikedatalayer;
        private readonly UserManager<IdentityUser> _userManager; // in order to get the id of the current user logged in


        public HikeController (HikingContext context, HikeDataLayer hikedatalayer, UserManager<IdentityUser> userManager)
        {
            this.context = context;
            this.hikedatalayer = hikedatalayer;
            _userManager = userManager;
        }
        
        //[Authorize] // you need to be an authorized user to see the list.
        public IActionResult Index()
        {
            
            return View(this.hikedatalayer.DisplayAll());
        }

        //CONFIRMATION'S MESSAGE

        public ActionResult SuccessOperationMessage()
        {
            return this.View();
        }

        public ActionResult EditOperationMessage()
        {
            return this.View();
        }

        public ActionResult DeleteOperationMessage()
        {
            return this.View();
        }

        // ADDING A NEW HIKE
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Create(Hike hike) // attribut de méthode : méthode appellée uniquement durant les requêtes post.
        {
            ActionResult result = this.View(hike); // vue de base

            if (this.ModelState.IsValid) // on vérifie que le modèle est bien valide
            {
                var id = _userManager.GetUserName(User); // get username currently logged in
                this.hikedatalayer.Add(hike,id);
                result = this.RedirectToAction("SuccessOperationMessage");
            }

            return result;
        }


        //EDITING AN EXISTING HIKE
        public ActionResult Edit(int id)
        {
            Hike hike = null;

            hike = this.hikedatalayer.PreFilledHike(id);

            return this.View(hike);
        }


        [HttpPost]
        public ActionResult Edit(Hike hike)
        {
            ActionResult result = this.View(hike); // vue de base

            if (this.ModelState.IsValid) // on vérifie que le modèle est bien valide
            {
                this.hikedatalayer.Update(hike);
                result = this.RedirectToAction("EditOperationMessage");
            }

            return result;


        }


        //DELETE HIKE
        public ActionResult Delete(int id)
        {

            Hike hike = null;
            hike = this.hikedatalayer.PreFilledHike(id);
            return this.View(hike);


        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Hike hike)
        {
            this.hikedatalayer.Delete(hike);

            return this.RedirectToAction("Index");


        }
    }
}
