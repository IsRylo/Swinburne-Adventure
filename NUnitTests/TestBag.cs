using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using SwinAdventure;

namespace NUnitTests
{
    public class TestBag
    {
        private Bag? _testBag;
        private Item? _testItem;

        [SetUp]
        public void Setup()
        {
            _testBag = new Bag(new string[]{"b1"}, "TestBag", "Bag containing items");
            _testItem = new Item(new string[] {"snake", "blade"}, "a serpent", "has vicious fangs");
        }
        
        // You can add items to the Bag, and Locate the item in its inventory,
        // this returns item the bag has and the item remains in the bag's
        // inventory
        [Test]
        public void TestBagLocatesItems()
        {
            
            _testBag!.Inventory.Put(_testItem!);
            Assert.That(Is.ReferenceEquals(_testBag.Locate("snake"), _testItem));
            Assert.That(_testBag.Inventory.HasItem("snake"), Is.True);
        }

        // The bag returns itself if asked to locate one of its identifiers
        [Test]
        public void TestBagLocatesItself()
        {
            Assert.That(Is.ReferenceEquals(_testBag!.Locate("b1"), _testBag));
        }

        // The bag returns a null/nil object if asked to located something it does
        // not have.
        [Test]
        public void TestBagLocatesNothing()
        {
            Assert.That(_testBag!.Locate("something"), Is.Null);
        }

        // The bag's full description contains the text "In the <name> you can see:"
        // and the short description of the items the bag contains (from its 
        // inventory's item list)
        [Test]
        public void TestBagFullDescription()
        {
            _testBag!.Inventory.Put(_testItem!);
            Assert.That(_testBag!.FullDescription, Is.EqualTo("In the TestBag, you can see:\n\ta serpent (snake)\n"));
        }

        // Create two bag objects (b1, b2), put b2 in b1's inventory.
        // Test that b1 can locate b2. Test that b1 can locate other items in b2.
        // Test that b1 can not locate items in b2.
        [Test]
        public void TestBagInBag()
        {
            _testBag!.Inventory.Put(_testItem!);
            Bag _testBag2 = new Bag(new string[] {"b2", "bag2"}, "a second bag", "a bag in a bag");
            Item _testItem2 = new Item(new string[] {"glasses"}, "glasses","can be found in b2");
            _testBag2.Inventory.Put(_testItem2);
            _testBag.Inventory.Put(_testBag2);

            // Test that b1 can locate b2.
            Assert.That(Is.Equals(_testBag.Locate("b2"), _testBag2));
            // Test that b1 can locate other items in b1
            Assert.That(Is.ReferenceEquals(_testBag.Locate("snake"), _testItem));
            // Test that b1 can not locate items in b2.
            Assert.That(_testBag.Locate("glasses"), Is.Null);
        }
    }
}