using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NETCore.Data.Entites
{
    public class AppRole : IdentityRole<Guid>
    {
        public string Description { get; set; }
    }
}
