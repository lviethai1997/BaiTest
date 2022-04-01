using Data.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
               new Product() {  },
               new Product() { ID = 1,Name= "Ram Kingston 8G",CategoryID=2,Quantity=15,Description="ok",CreateTime=DateTime.Now,UpdatedDate=DateTime.Now,Status=0,ImagePath= "/user-content/fbc4ad81-9d8d-475b-a849-fb0e37e0fa38.png" },
               new Product() { ID = 2,Name= "RAM APACER 8GB PANTHER DDR4 BUS 3200", CategoryID=2,Quantity=15,Description="ok",CreateTime=DateTime.Now,UpdatedDate=DateTime.Now,Status=0,ImagePath= "/user-content/fbc4ad81-9d8d-475b-a849-fb0e37e0fa38.png" },
               new Product() { ID = 3,Name= "Ram Fury ", CategoryID=2,Quantity=15,Description="ok",CreateTime=DateTime.Now,UpdatedDate=DateTime.Now,Status=0,ImagePath= "/user-content/fbc4ad81-9d8d-475b-a849-fb0e37e0fa38.png" },
               new Product() { ID = 4,Name= "Ram Gskill", CategoryID=2,Quantity=15,Description="ok",CreateTime=DateTime.Now,UpdatedDate=DateTime.Now,Status=0,ImagePath= "/user-content/fbc4ad81-9d8d-475b-a849-fb0e37e0fa38.png" },
               new Product() { ID = 5,Name= "CPU Core i5 12400f", CategoryID=2,Quantity=15,Description="ok",CreateTime=DateTime.Now,UpdatedDate=DateTime.Now,Status=0,ImagePath= "/user-content/fbc4ad81-9d8d-475b-a849-fb0e37e0fa38.png" },
               new Product() { ID = 6,Name= "CPU Intel Core I7-12700 12C/20T 25MB Cache 2.70 GHz Up to 4.9 GHz", CategoryID=2,Quantity=15,Description="ok",CreateTime=DateTime.Now,UpdatedDate=DateTime.Now,Status=0,ImagePath= "/user-content/fbc4ad81-9d8d-475b-a849-fb0e37e0fa38.png" },
               new Product() { ID = 7,Name= "Mainboard Gigabyte B660M-DS3H DDR4 Socket LGA 1700", CategoryID=2,Quantity=15,Description="ok",CreateTime=DateTime.Now,UpdatedDate=DateTime.Now,Status=0,ImagePath= "/user-content/fbc4ad81-9d8d-475b-a849-fb0e37e0fa38.png" },
               new Product() { ID = 8,Name= "Mainboard Gigabyte B660M Aorus Pro DDR4 Socket LGA 1700", CategoryID=2,Quantity=15,Description="ok",CreateTime=DateTime.Now,UpdatedDate=DateTime.Now,Status=0,ImagePath= "/user-content/fbc4ad81-9d8d-475b-a849-fb0e37e0fa38.png" },
               new Product() { ID = 9,Name= "Nguồn Cooler Master Elite P400 V3 300W", CategoryID=2,Quantity=15,Description="ok",CreateTime=DateTime.Now,UpdatedDate=DateTime.Now,Status=0,ImagePath= "/user-content/fbc4ad81-9d8d-475b-a849-fb0e37e0fa38.png" },
               new Product() { ID = 10,Name= "Nguồn Cooler Master MWE 650 BRONZE V2 230V 650W 80PLUS BRONZE", CategoryID=2,Quantity=15,Description="ok",CreateTime=DateTime.Now,UpdatedDate=DateTime.Now,Status=0,ImagePath= "/user-content/fbc4ad81-9d8d-475b-a849-fb0e37e0fa38.png" }
               );
        }
    }
}
