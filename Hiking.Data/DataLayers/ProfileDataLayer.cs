using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hiking.Data.DataLayers
{
    
    
    public class ProfileDataLayer
    {
        private HikingContext _context;

        public ProfileDataLayer(HikingContext context)
        {
            _context = context;
        }

        public IdentityUser ProfileDetails(string id)
        {

            return this._context.Users.FirstOrDefault(item => item.Id == id);
        }

    }
}
