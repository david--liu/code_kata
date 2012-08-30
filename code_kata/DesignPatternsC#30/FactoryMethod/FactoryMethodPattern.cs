using System;
using NUnit.Framework;

[TestFixture]
public class FactoryMethodPattern
{
    // Factory Method Pattern           Judith Bishop  2006

    interface IProduct
    {
        string ShipFrom();
    }

    class ProductA : IProduct
    {
        public String ShipFrom()
        {
            return " from South Africa";
        }
    }

    class ProductB : IProduct
    {
        public String ShipFrom()
        {
            return "from Spain";
        }
    }

    class DefaultProduct : IProduct
    {
        public String ShipFrom()
        {
            return "not available";
        }
    }

    class Creator
    {
        public IProduct FactoryMethod(int month)
        {
            if (month >= 4 && month <= 11)
                return new ProductA();
            else if (month == 1 || month == 2 || month == 12)
                return new ProductB();
            else return new DefaultProduct();
        }
    }

    [Test]
    public void Main()
    {
        var c = new Creator();
        IProduct product;

        for (var i = 1; i <= 12; i++)
        {
            product = c.FactoryMethod(i);
            Console.WriteLine("Avocados " + product.ShipFrom());
        }
    }
}

/* Output
53  Avocados from Spain
54  Avocados from Spain
55  Avocados not available
56  Avocados  from South Africa
57  Avocados  from South Africa
58  Avocados  from South Africa
59  Avocados  from South Africa
60  Avocados  from South Africa
61  Avocados  from South Africa
62  Avocados  from South Africa
63  Avocados  from South Africa
64  Avocados from Spain
65  */