using ProductManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProductManagement.ViewModels
{
    public class ProductViewModel2
    {       
        public int ID { get; set; }
      
        public string Name { get; set; }

        public string Description { get; set; }

        public int NumberInStock { get; set; }

        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

    }
}