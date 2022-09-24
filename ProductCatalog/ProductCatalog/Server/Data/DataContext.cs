

namespace ProductCatalog.Server.Data
{
    public class DataContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        DbSet<ProductCategoryMapping> Product_Category_Mapping { get; set; }
        public DbSet<ProductAttribute> Product_Attributes { get; set; }
        public DbSet<ProductAttributeMapping> Product_Attribute_Mapping { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        DbSet<Review> Reviews { get; set; }


        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //create one to many relation ship between Product and ProductCategoryMapping
            modelBuilder.Entity<ProductCategoryMapping>()
            .HasOne<Product>(pcm => pcm.Product)
            .WithMany(p => p.productCategoryMapping)
            .HasForeignKey(pcm => pcm.ProductId);

            //create one to many relation ship between Category and ProductCategoryMapping
            modelBuilder.Entity<ProductCategoryMapping>()
            .HasOne<Category>(pcm => pcm.Category)
            .WithMany(c => c.productCategoryMapping)
            .HasForeignKey(pcm => pcm.CategoryId);

            //create one to many relation ship between ProductAttribute and ProductAttributeMapping
            modelBuilder.Entity<ProductAttributeMapping>()
            .HasOne<ProductAttribute>(pam => pam.productAttribute)
            .WithMany(pa=> pa.productAttributeMapping)
            .HasForeignKey(pam => pam.AttributeId);

            //create one to many relation ship between Product and ProductAttributeMapping
            modelBuilder.Entity<ProductAttributeMapping>()
            .HasOne<Product>(pam => pam.Product)
            .WithMany(p => p.productAttributeMapping)
            .HasForeignKey(pcm => pcm.ProductId);

            //create one to many relation ship between Product and Review
            modelBuilder.Entity<Review>()
            .HasOne<Product>(r => r.Product)
            .WithMany(p => p.Reviews)
            .HasForeignKey(r => r.ProductId);

            //create one to many relation ship between Product and Review
            modelBuilder.Entity<Picture>()
            .HasOne<Product>(p => p.Product)
            .WithMany(p => p.Pictures)
            .HasForeignKey(p => p.ProductId);
   

            //insert default data to tables

            //insert categories
            //1
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id=1,
                Name = "electronic",
                Description = "this category have all electronic devices",


            });

            //2
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id=2,
                Name = "computers",
                Description = "this category have all descktop devices",


            });
            
            //3
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id=3,
                Name = "laptops",
                Description = "this category have all laptops devices",


            });
            //4
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id=4,
                Name = "mobiles",
                Description = "this category have all mobiles devices",

            });

            //insert attribute
            //1
            modelBuilder.Entity<ProductAttribute>().HasData(new ProductAttribute
            {
                Id=1,
                Name = "ram",
                Description = "this attribute descripte ram memory in computers and mobile and ..."                


            });

            //2
            modelBuilder.Entity<ProductAttribute>().HasData(new ProductAttribute
            {
                Id=2,
                Name = "processor",
                Description = "this attribute descripte processor  in computers and mobile and ..."                


            });

            //3
            modelBuilder.Entity<ProductAttribute>().HasData(new ProductAttribute
            {
                Id=3,
                Name = "hard",
                Description = "this attribute descripte hard memory in computers and mobile and ..."                

            });

            //insert product
            //1
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id=1,
                Name = "Asus laptop",
                Description = "new laptop for engineer",
                forSearchByCategory=".1.3",
            });

            
            //2
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id=2,
                Name = "Asus computer",
                Description = "new computer from asus",
                forSearchByCategory=".1.2",

            });

            modelBuilder.Entity<ProductCategoryMapping>().HasData(new ProductCategoryMapping
            {
                    Id=1,
                    ProductId=1,
                    CategoryId=1
            });

            modelBuilder.Entity<ProductCategoryMapping>().HasData(new ProductCategoryMapping
            {
                    Id=2,
                    ProductId=1,
                    CategoryId=3
            });

            modelBuilder.Entity<ProductCategoryMapping>().HasData(new ProductCategoryMapping
            {
                    Id=3,
                    ProductId=2,
                    CategoryId=1
            });

            modelBuilder.Entity<ProductCategoryMapping>().HasData(new ProductCategoryMapping
            {
                    Id=4,
                    ProductId=2,
                    CategoryId=2
            });

            modelBuilder.Entity<ProductAttributeMapping>().HasData(new ProductAttributeMapping
            {
                        Id=1,
                        ProductId=1,
                        AttributeId=1,
                        Value="4 GB"
            });

         modelBuilder.Entity<ProductAttributeMapping>().HasData(new ProductAttributeMapping
            {
                        Id=2,
                        ProductId=1,
                        AttributeId=2,
                        Value="intel core i3"
            });

                     modelBuilder.Entity<ProductAttributeMapping>().HasData(new ProductAttributeMapping
            {
                        Id=3,
                        ProductId=2,
                        AttributeId=1,
                        Value="4 GB"
            });

            
                     modelBuilder.Entity<ProductAttributeMapping>().HasData(new ProductAttributeMapping
            {
                        Id=4,
                        ProductId=2,
                        AttributeId=2,
                        Value="intel core i7"
            });
        }
    }
}
