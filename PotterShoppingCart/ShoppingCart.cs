using System;
using System.Collections.Generic;
using System.Linq;

namespace PotterShoppingCart
{
    public class ShoppingCart
    {
        private List<Book> _books;

        private List<DiscountPackage> _discountPackages;


        public ShoppingCart(List<Book> books)
        {
            this._books = books;
            this._discountPackages = new List<DiscountPackage>
            {
                new DiscountPackage{BookName="Harry Potter", PackageSize = 2, PackageRate = 0.95},
                new DiscountPackage{BookName="Harry Potter", PackageSize = 3, PackageRate = 0.9},
                new DiscountPackage{BookName="Harry Potter", PackageSize = 4, PackageRate = 0.8},
                new DiscountPackage{BookName="Harry Potter", PackageSize = 5, PackageRate = 0.75}
            };
        }


        public IEnumerable<string> DiscountBookNames 
        {
            get
            {
                return _discountPackages.Select(x => x.BookName).Distinct();
            } 
        }


        public int GetTotalPrice()
        {
            int normalPrice =
                _books.Where(x => !DiscountBookNames.Contains(x.Name)).Select(x => x.SellPrice).Sum();

            int discountPrice =
                GetDiscountPrice(_books.Where(x => DiscountBookNames.Contains(x.Name)).ToList());

            return normalPrice + discountPrice;
        }

        private int GetDiscountPrice(List<Book> books)
        {
            var discountPriceSum = 0;

            foreach (var discountBookName in DiscountBookNames)
            {
                // loop each discount book name
                var discountPackages = _discountPackages.Where(x => x.BookName == discountBookName);
                var discountBooks = books.Where(x => x.Name == discountBookName).ToList();
                foreach (var package in discountPackages.OrderByDescending(x => x.PackageSize))
                {
                    // loop each discount package
                    discountPriceSum += GetPackagePrice(discountBooks, package.PackageSize, package.PackageRate);
                }

                discountPriceSum += discountBooks.Select(x => x.SellPrice).Sum();
            }

            return discountPriceSum;
        }

        private int GetPackagePrice(List<Book> books, int packageSize, double packageRate)
        {
            var priceSum = 0;
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

                priceSum += Convert.ToInt16(packageOriginalPrice * packageRate);
                existSeries = GetSeries(books);
            }
            return priceSum;
        }

        private List<int> GetSeries(List<Book> books)
        {
            return books.Select(x => x.Series).Distinct().ToList();
        }
    }
}