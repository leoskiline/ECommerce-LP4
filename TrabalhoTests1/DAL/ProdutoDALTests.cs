using Microsoft.VisualStudio.TestTools.UnitTesting;
using ecommerce.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.DAL.Tests
{
    [TestClass()]
    public class ProdutoDALTests
    {
        [TestMethod()]
        public void ObterTodosTest()
        {
            ProdutoDAL dal = new ProdutoDAL();
            dal.ObterTodos();
            Assert.IsNotNull(dal);
        }
    }
}