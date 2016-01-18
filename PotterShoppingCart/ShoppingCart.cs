using System;
using System.Collections.Generic;
using System.Linq;

namespace PotterShoppingCart
{
    public class ShoppingCart
    {
        private List<Book> _books;

        public ShoppingCart(List<Book> books)
        {
            this._books = books;
        }

        public int GetTotalPrice()
        {
            var discountBookName = "Harry Potter";

            int normalPrice =
                _books.Where(x => x.Name != discountBookName).Select(x => x.SellPrice).Sum();

            int discountPrice =
                GetDiscountPrice(_books.Where(x => x.Name == discountBookName).ToList());

            return normalPrice + discountPrice;
        }

        private int GetDiscountPrice(List<Book> books)
        {
            var discountPriceSum = 0;
            var packageSize = 2;
            var packageRate = 0.95;

            var existSeries = GetSeries(books);
            while (existSeries.Count >= packageSize)
            {
                int packageOriginalPrice = 0;
                for (int i = 0; i < packageSize; i++)
                {
                    var book = books.Where(x => x.Series == existSeries[i]).First();
                    packageOriginalPrice += book.SellPrice;
                    books.Remove(book);
                }

                discountPriceSum += Convert.ToInt16(packageOriginalPrice * packageRate);
                existSeries = GetSeries(books);
            }

            return discountPriceSum + books.Select(x => x.SellPrice).Sum();
        }

        private List<int> GetSeries(List<Book> books)
        {
            return books.Select(x => x.Series).Distinct().ToList();
        }
    }
}