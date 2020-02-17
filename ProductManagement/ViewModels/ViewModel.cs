using ProductManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductManagement.ViewModels
{
    public class ViewModel
    {
        public Product product { get; set; }

        public Category category { get; set; }
    }
}