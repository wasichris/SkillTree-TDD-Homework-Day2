using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotterShoppingCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotterShoppingCart.Tests
{
    [TestClass]
    public class ShoppingCartTest
    {
        [TestMethod]
        public void GetTotalPriceTest_第一集買了一本_其他都沒買_價格應為100元()
        {
            // Arrange
            var books = new List<Book>()
            {
                new Book { Name="Harry Potter", Series = 1, SellPrice = 100}
            };
            var expected = 100;
            var target = new ShoppingCart(books);

            // Act
            var actual = target.GetTotalPrice();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetTotalPriceTest_第一集買了一本_第二集也買了一本_價格應為190()
        {
            // Arrange
            var books = new List<Book>()
            {
                new Book { Name="Harry Potter", Series = 1, SellPrice = 100},
                new Book { Name="Harry Potter", Series = 2, SellPrice = 100}
            };
            var expected = 190;
            var target = new ShoppingCart(books);

            // Act
            var actual = target.GetTotalPrice();

            // Assert
            Assert.AreEqual(expected, actual);

        }
    }
}