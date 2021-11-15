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
    }
}
