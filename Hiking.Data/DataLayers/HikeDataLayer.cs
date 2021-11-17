using Hiking.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hiking.Data.DataLayers
{
    public class HikeDataLayer
    {
        
        private HikingContext context;

        public HikeDataLayer(HikingContext context)
        {
            this.context = context;
        }

        public List<Models.Hike> DisplayAll()
        {
            var query = from item in this.context.Hikes // va chercher toutes les données de la table
                        select item;
            
            return query.ToList();
        }

        public Hike PreFilledHike(int id)
        {
            
            return this.context.Hikes.FirstOrDefault(item => item.Id == id);
        }

        public void Add(Hike hike)
        {
            this.context.Hikes.Add(hike);
            this.context.SaveChanges();
        }

        public void Update (Hike hike)
        {
            this.context.Hikes.Update(hike);
            this.context.SaveChanges();
        }

        public void Delete(Hike hike)
        {
            this.context.Hikes.Remove(hike);
            this.context.SaveChanges();
        }
    }
}
