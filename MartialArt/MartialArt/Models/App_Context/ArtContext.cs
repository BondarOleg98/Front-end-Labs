using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MartialArt.Models.App_Context
{
    public class ArtContext : DbContext
    {
        public DbSet<Art> Arts { get; set; }

    }
}