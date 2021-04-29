using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trabalho.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho.DAL.Tests
{
    [TestClass()]
    public class CidadeDALTests
    {
        [TestMethod()]
        public void ObterPorUFTest()
        {
            CidadeDAL c = new CidadeDAL();
            var lista = c.ObterPorUF("SP");
            Assert.AreNotEqual(null, lista);
        }

        [TestMethod()]
        public void ContaPorUFTest()
        {
            CidadeDAL c = new CidadeDAL();
            var qtde = c.ContarPorUF("SP");
            Assert.AreNotEqual(qtde, 0);
        }
    }
}