using Group11.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace Group11.Models
{
    public class TailieuDBContext : DbContext
    {
        public DbSet<Tailieu> tailieus { get; set; }
        public DbSet<Genre> genres { get; set; }

        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public DbSet<Tintuc> tintucs { get; set; }
        public DbSet<Homepage> homepages { get; set; }
        
        public DbSet<KhoahocGT> KhoahocGTs { get; set; }

        public DbSet<KhoahocIelts> KhoahocIelts { get; set; }
        public DbSet<KhoahocToeic> KhoahocToeics { get; set; }
    }
}