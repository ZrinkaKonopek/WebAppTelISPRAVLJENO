using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAppTel.Models;

namespace WebAppTel.Models
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Mobitel> Mobitel { get; set; }
        public DbSet<Marka> Marka { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Mobitel>().Property(m => m.Cijena).HasPrecision(10, 2);

            builder.Entity<Marka>().HasData(
                new Marka() { Id = 1, Naziv = "Samsung" },
                new Marka() { Id = 2, Naziv = "Apple" },
                new Marka() { Id = 3, Naziv = "Xaomi" },
                new Marka() { Id = 4, Naziv = "Nokia" },
                new Marka() { Id = 5, Naziv = "Huawei" }
                );


            builder.Entity<Mobitel>().HasData(
                new Mobitel() { Id = 1, Naziv = "Samsung Galaxy S23", GodinaProizvodnje = 2023, Cijena = 900, SlikaUrl = "https://images.samsung.com/hr/smartphones/galaxy-s23/buy/02_Image_Carousel/02-1_Group_KV_Basic_Color/S23Plus-group_kv_MO.jpg", MarkaId = 1 },
                new Mobitel() { Id = 2, Naziv = "Redmi Note 9", GodinaProizvodnje = 2020, Cijena = 150, SlikaUrl = "https://mi.hr/images/thumbs/0005478_redmi-note-9_750.jpeg", MarkaId = 3 },
                new Mobitel() { Id = 3, Naziv = "iPhone 12", GodinaProizvodnje = 2020, Cijena = 500, SlikaUrl = "https://istyle.hr/media/catalog/product/i/p/iphone_12__p_red_pdp_image_position-2__en-us_1_10.jpg", MarkaId = 2 },
                new Mobitel() { Id = 4, Naziv = "Honor 20 Pro", GodinaProizvodnje = 2019, Cijena = 190, SlikaUrl = "https://fdn2.gsmarena.com/vv/bigpic/huawei-honor-20-pro-r.jpg", MarkaId = 5 },
                new Mobitel() { Id = 5, Naziv = "Nokia 1 Plus", GodinaProizvodnje = 2019, Cijena = 100, SlikaUrl = "https://www.racunalo.com/usporedilica/slike/nokia/nokia-1-plus.jpg", MarkaId = 4 }
                );
        }
    }
}
