using Hiking.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hiking.Data.DataLayers
{
    public class HikeDataLayer
    {
        
        private HikingContext context;
        private readonly UserManager<IdentityUser> _userManager;

        public HikeDataLayer(HikingContext context, UserManager<IdentityUser> userManager)
        {
            this.context = context;
            _userManager = userManager;
        }

        public List<Hike> DisplayAll()
        {
            var query = from item in this.context.Hikes // va chercher toutes les données de la table
                        select item;
            
            return query.ToList();
        }

        public Hike PreFilledHike(int id)
        {
            
            return this.context.Hikes.FirstOrDefault(item => item.Id == id);
        }

        public void Add(Hike hike, string CurrentUsername)
        {
           
            
            Hike newhike = new Hike()
            {
                Name = hike.Name,
                Difficulty = hike.Difficulty,
                Distance = hike.Distance,
                Duration = hike.Duration,
                Height_difference = hike.Height_difference,
                Available = hike.Available,
                UserName = CurrentUsername
            };
           
            
            this.context.Hikes.Add(newhike);
            this.context.SaveChanges();
        }

        public void Update (Hike query,Hike hike)
        {
            query.Name = hike.Name;
            query.Duration = hike.Duration;
            query.Difficulty = hike.Difficulty;
            query.Available = hike.Available;
            query.Height_difference = hike.Height_difference;
            
            this.context.Hikes.Update(query);
            this.context.SaveChanges();
        }

        public void Delete(Hike hike)
        {
            this.context.Hikes.Remove(hike);
            this.context.SaveChanges();
        }
    }
}
