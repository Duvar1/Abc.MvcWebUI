using Abc.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Abc.MvcWebUI.Entity
{
    public class DataInitializer:DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var categories = new List<Category>()
            {
                new Category(){Name="Kamera", Description="Kamera ürünleri"},
                new Category(){Name="Bilgisayar", Description="Bilgisayar ürünleri"},
                new Category(){Name="Elektronik", Description="Elektronik ürünler"},
                new Category(){Name="Telefon", Description="Telefon ürünleri"},
                new Category(){Name="Beyaz Eşya", Description="Beyaz Eşya ürünleri"},
                new Category(){Name="Ev Tekstili", Description="Ev Tekstili ürünleri"}
            };

            foreach (var category in categories)
            {
                context.Categories.Add(category);
            }
            context.SaveChanges();

            var products = new List<Product>()
            {
                new Product(){Name="Canon",Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap  Kamera",Price=1000,Stock=50,IsApproved=true,CategoryId=1,IsHome=true,Image="1.jpg"},
                new Product(){Name="B Kamera",Description="B eap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",Price=1300,Stock=35,IsApproved=true,CategoryId=1,Image="2.jpg"},
                new Product(){Name="D Kamera",Description="D It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using '",Price=1700,Stock=47,IsApproved=true,CategoryId=1,Image="3.jpg"},
                
                new Product(){Name="Asus",Description="Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, cons Notebook",Price=11000,Stock=50,IsApproved=true,CategoryId=2,Image="4.jpg"},
                new Product(){Name="Huawei",Description="Huawei Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, cons",Price=14000,Stock=47,IsApproved=true,CategoryId=2,IsHome=true, Image = "5.jpg"},
                new Product(){Name="Monster",Description="Monster Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as thei",Price=42000,Stock=35,IsApproved=true,CategoryId=2, Image = "6.jpg"},
                
                new Product(){Name="Kulaklık",Description="Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as thei Kulaklık",Price=110,Stock=50,IsApproved=true,CategoryId=3, Image = "7.jpg"},
                new Product(){Name="Mause",Description="It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using ' Mause",Price=250,Stock=35,IsApproved=true,CategoryId=3,IsHome=true, Image = "8.jpg"},
                new Product(){Name="Klavye",Description="Ultra Hassas It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using '",Price=300,Stock=47,IsApproved=true,CategoryId=3, Image = "9.jpg"},
                
                new Product(){Name="IPhone 13 Pro",Description="IPhone Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as thei Pro 256 gb",Price=30000,Stock=50,IsApproved=true,CategoryId=4, Image = "10.jpg"},
                new Product(){Name="One Plus 9 Pro",Description="One Plus Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, cons Pro 512 gb",Price=25000,Stock=35,IsApproved=true,CategoryId=4, Image = "11.jpg"},
                new Product(){Name="Xiaomi Filan Model",Description="It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using ' Filan Model 128gb",Price=7000,Stock=47,IsApproved=true,CategoryId=4,IsHome=true, Image = "12.jpg"},
                
                new Product(){Name="AMarka Buzdolabı",Description="It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using ' Buzdolabı",Price=9000,Stock=35,IsApproved=true,CategoryId=5,IsHome=true, Image = "13.jpg"},
                new Product(){Name="BMarka Mikrodalga",Description="Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as thei",Price=5500,Stock=50,IsApproved=true,CategoryId=5, Image = "14.jpg"},
                new Product(){Name="CMarka Kurutma Makinası",Description="CMarka Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, cons Makinası",Price=17000,Stock=47,IsApproved=true,CategoryId=5, Image = "15.jpg"},
                
                new Product(){Name="Bellona Çift Kişilik Ranforst Nevresim",Description="Bellona Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as thei Kişilik Ranforst Nevresim",Price=400,Stock=47,IsApproved=true,CategoryId=6,IsHome=true, Image = "16.jpg"},
                new Product(){Name="AMarka 4'lü Havlu Seti",Description="AMContent here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as theivlu Seti",Price=199,Stock=35,IsApproved=true,CategoryId=6,Image="17.jpg"},
                new Product(){Name="BMarka Bornoz Seti",Description="BMarka It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using ' Seti",Price=700,Stock=50,IsApproved=true,CategoryId=6,IsHome=true,Image="18.jpg"},

            };

            foreach (var product in products)
            {
                context.Products.Add(product);
            }
            context.SaveChanges();

            base.Seed(context);
        }
    }
}