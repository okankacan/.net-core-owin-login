using CoreOwin.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreOwin.IdentityCore
{
    public class testDBContext : IdentityDbContext<ApplicationUser>
    {
        public testDBContext( DbContextOptions<testDBContext> options)
            :base (options)
        {

        }
    }
}
