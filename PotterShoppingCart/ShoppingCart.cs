using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            throw new NotImplementedException();
        }
    }
}
