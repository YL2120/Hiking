using Hiking.Data;
using Hiking.Data.DataLayers;
using Hiking.Data.Models;
using Hiking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Hiking.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HikingContext context;
        private HikeDataLayer hikedatalayer;

        public HomeController(ILogger<HomeController> logger, HikingContext context, HikeDataLayer hikedatalayer)
        {
            _logger = logger;
            this.context = context;
            this.hikedatalayer = hikedatalayer;
        }

       

        public IActionResult Index()
        {
           
            return View(this.hikedatalayer.DisplayAll());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult SuccessOperationMessage()
        {
            return this.View();
        }

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
                this.context.Hikes.Add(hike);
                this.context.SaveChanges();

                result = this.RedirectToAction("SuccessOperationMessage");            
             }

            return result;
        }

        public ActionResult Edit(int id)
        {
            Hike hike = null;

            hike = this.hikedatalayer.EditItem(id);

            return this.View(hike);
        }


        [HttpPost]
        public ActionResult Edit(Hike hike)
        {
            //1ère méthode de modification totale(classique)
            this.context.Hikes.Update(hike);
            this.context.SaveChanges();

            //2ème méthode : entites traque les changements et ne modifie que des champs précis.
            //this._context.Attach<Paragraphe>(paragraphe);
            //this._context.Entry(paragraphe).Property(item => item.Title).IsModified = true; //ORM regarde les changements présents dans le cache. Entities ne modifie que ce champ là.

            //this._context.SaveChanges();

            return this.View(hike);
        }
    }
}
