using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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

        [TestMethod]
        public void GetTotalPriceTest_一二三集各買了一本_價格應為270()
        {
            // Arrange
            var books = new List<Book>()
            {
                new Book { Name="Harry Potter", Series = 1, SellPrice = 100},
                new Book { Name="Harry Potter", Series = 2, SellPrice = 100},
                new Book { Name="Harry Potter", Series = 3, SellPrice = 100}
            };
            var expected = 270;
            var target = new ShoppingCart(books);

            // Act
            var actual = target.GetTotalPrice();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetTotalPriceTest_一二三四集各買了一本_價格應為320()
        {
            // Arrange
            var books = new List<Book>()
            {
                new Book { Name="Harry Potter", Series = 1, SellPrice = 100},
                new Book { Name="Harry Potter", Series = 2, SellPrice = 100},
                new Book { Name="Harry Potter", Series = 3, SellPrice = 100},
                new Book { Name="Harry Potter", Series = 4, SellPrice = 100}
            };
            var expected = 320;
            var target = new ShoppingCart(books);

            // Act
            var actual = target.GetTotalPrice();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetTotalPriceTest_一次買了整套_一二三四五集各買了一本_價格應為375()
        {
            // Arrange
            var books = new List<Book>()
            {
                new Book { Name="Harry Potter", Series = 1, SellPrice = 100},
                new Book { Name="Harry Potter", Series = 2, SellPrice = 100},
                new Book { Name="Harry Potter", Series = 3, SellPrice = 100},
                new Book { Name="Harry Potter", Series = 4, SellPrice = 100},
                new Book { Name="Harry Potter", Series = 5, SellPrice = 100}
            };
            var expected = 375;
            var target = new ShoppingCart(books);

            // Act
            var actual = target.GetTotalPrice();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetTotalPriceTest_一二集各買了一本_第三集買了兩本_價格應為370()
        {
            // Arrange
            var books = new List<Book>()
            {
                new Book { Name="Harry Potter", Series = 1, SellPrice = 100},
                new Book { Name="Harry Potter", Series = 2, SellPrice = 100},
                new Book { Name="Harry Potter", Series = 3, SellPrice = 100},
                new Book { Name="Harry Potter", Series = 3, SellPrice = 100}
            };
            var expected = 370;
            var target = new ShoppingCart(books);

            // Act
            var actual = target.GetTotalPrice();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}