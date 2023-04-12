using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using SwinAdventure;

namespace NUnitTests
{
    public class TestInventory
    {
        private Inventory? _testInventory;

        [SetUp]
        public void Setup()
        {
            _testInventory = new Inventory();
            _testInventory.Put(new Item (new string[] {"sword", "blade"}, "a bronze sword", "Starter weapon for players to use."));
            _testInventory.Put(new Item (new string[] {"shovel", "spade"}, "a shovel","This is a might fine ..."));
            _testInventory.Put(new Item (new string[] {"pc", "laptop"}, "a small pc", "A computer to power your ideas."));
        }

        // The Inventory has items that are put in it.
        [Test]
        public void TestFindItem()
        {
            Item snakeItem = new Item(new string[] {"snake", "serpent"}, "a small snake", "Has vicious fangs");
            _testInventory!.Put(snakeItem);
            Assert.That(_testInventory.HasItem("snake"), Is.True);
        }

        // The Inventory does not have items it does not contain.
        [Test]
        public void TestNoItemFind()
        {
            Assert.That(_testInventory!.HasItem("snake"), Is.False);
        }

        // Returns items it has and the item remains in the inventory.
        [Test]
        public void TestFetchItem()
        {
            Assert.That(_testInventory!.Fetch("shovel")!.Name, Is.EqualTo("a shovel"));
            Assert.That(_testInventory.HasItem("shovel"), Is.True);
        }

        // Returns items it has, and the item is no longet in the inventory.
        [Test]
        public void TakeItem()
        {
            Assert.That(_testInventory!.Take("shovel")!.Name, Is.EqualTo("a shovel"));
            Assert.That(_testInventory.HasItem("shovel"), Is.False);
        }

        // Returns a string containing multiple lines.
        // Each line contains a tab-indented short description of an item in 
        // the Inventory 
        [Test]
        public void TestItemList()
        {
            Assert.That(_testInventory!.ItemList, Is.EqualTo("\ta bronze sword (sword)\n\ta shovel (shovel)\n\ta small pc (pc)\n"));
        }
    }
}