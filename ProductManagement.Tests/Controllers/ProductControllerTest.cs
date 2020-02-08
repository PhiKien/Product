using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductManagement.Controllers;
using ProductManagement.Repository.Implement;
using ProductManagement.ViewModels;
using System.Collections;
using System.Web.Mvc;

namespace ProductManagement.Tests.Controllers
{
    [TestClass]
    public class ProductControllerTest
    {
        private ProductController controller = new ProductController();
        private ProductRepository repository = new ProductRepository();

        [TestMethod]
        public void FindProductByCategoryID()
        {
            //IEnumerable<ProductViewModel> list = controller.FindProductByCategoryID(1, 1);
            //Assert.IsNotNull(viewResult);
        }
    }
}
