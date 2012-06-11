using System;
using NUnit.Framework;

namespace AbstractFactoryPattern
{
    // Abstract Factory     D-J Miller and Judith Bishop  Sept 2007
    // Uses generics to simplify the creation of factories

    interface IFactory<Brand>
        where Brand : IBrand
    {
        IBag CreateBag();
        IShoes CreateShoes();
    }

    // Concrete Factories (both in the same one)
    class Factory<Brand> : IFactory<Brand>
        where Brand : IBrand, new()
    {
        public IBag CreateBag()
        {
            return new Bag<Brand>();
        }

        public IShoes CreateShoes()
        {
            return new Shoes<Brand>();
        }
    }

    // Interface IProductA
    interface IBag
    {
        string Material { get; }
    }

    // Interface IProductB
    interface IShoes
    {
        int Price { get; }
    }

    // All concrete ProductA's
    class Bag<Brand> : IBag
        where Brand : IBrand, new()
    {
        Brand myBrand;

        public Bag()
        {
            myBrand = new Brand();
        }

        public string Material
        {
            get { return myBrand.Material; }
        }
    }

    // All concrete ProductB's
    class Shoes<Brand> : IShoes
        where Brand : IBrand, new()
    {
        Brand myBrand;

        public Shoes()
        {
            myBrand = new Brand();
        }

        public int Price
        {
            get { return myBrand.Price; }
        }
    }

    // An interface for all Brands
    interface IBrand
    {
        int Price { get; }
        string Material { get; }
    }

    class Gucci : IBrand
    {
        public int Price
        {
            get { return 1000; }
        }

        public string Material
        {
            get { return "Crocodile skin"; }
        }
    }

    class Poochy : IBrand
    {
        public int Price
        {
            get { return new Gucci().Price/3; }
        }

        public string Material
        {
            get { return "Plastic"; }
        }
    }

    class Groundcover : IBrand
    {
        public int Price
        {
            get { return 2000; }
        }

        public string Material
        {
            get { return "South african leather"; }
        }
    }

    class AbstractFactoryClient<Brand>
        where Brand : IBrand, new()
    {
        public void ClientMain() //IFactory<Brand> factory)
        {
            IFactory<Brand> factory = new Factory<Brand>();

            var bag = factory.CreateBag();
            var shoes = factory.CreateShoes();

            Console.WriteLine("I bought a Bag which is made from " +
                bag.Material
                );
            Console.WriteLine("I bought some shoes which cost " +
                shoes.Price
                );
        }
    }

    [TestFixture]
    public class AbstractFactoryTest
    {
        [Test]
        public void Main()
        {
            // Call Client twice
            new AbstractFactoryClient<Poochy>().ClientMain();
            new AbstractFactoryClient<Gucci>().ClientMain();
            new AbstractFactoryClient<Groundcover>().ClientMain();
        }
    }
}