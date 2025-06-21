using Microsoft.EntityFrameworkCore;
using RentACarAPI.Domain.Entities;

namespace RentACarAPI.Persistence.Context
{
    public class CarBookContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;
            Initial Catalog=CarBookDb;
            Integrated Security=True;Trust Server Certificate=True;");
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarDescription> CarDescriptions { get; set; }
        public DbSet<CarFeature> CarFeatures { get; set; }
        public DbSet<CarPricing> CarPricings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<FooterAddress> FooterAddresses { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Pricing> Pricings { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Blog>? Blogs { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CarRenting> CarRentings { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CarRentingDetail> CarRentingDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CarRentingDetail>()
                .HasOne(d => d.PickUpLocation)
                .WithMany()
                .HasForeignKey(d => d.PickUpLocationID)
                .OnDelete(DeleteBehavior.Restrict); // ❌ Prevent cascade delete here

            modelBuilder.Entity<CarRentingDetail>()
                .HasOne(d => d.DropOffLocation)
                .WithMany()
                .HasForeignKey(d => d.DropOffLocationID)
                .OnDelete(DeleteBehavior.Restrict); // ❌ Or here if you prefer
        }

    }
}
