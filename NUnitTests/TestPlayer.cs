using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using SwinAdventure;

namespace NUnitTests
{
    public class TestPlayer
    {
        private Player _testPlayer; 
        private Item _testItem;

        [SetUp]
        public void Setup()
        {
            _testPlayer = new Player("Loysing", "A new programmer learning OOP!");
            _testItem = new Item(new string[] {"sword", "blade"}, "a bronze sword", "A starter weapon");
            _testPlayer.Inventory.Put(_testItem);
        }

        // The player responds correctly to "Are You" requests based on
        // its default identifiers (me and inventory)
        [TestCase("me", ExpectedResult = true)]
        [TestCase("inventory", ExpectedResult = true)]
        [TestCase("player", ExpectedResult = false)]
        public bool TestPlayerIsIdentifiable(string ident)
        {
            return _testPlayer!.AreYou(ident);
        }

        // The player can locate items in its invenotry, this returns items
        // the player has and the item remains in the player's inventory
        public void TestPlayerLocatesItems()
        {
            Assert.That(_testPlayer!.Locate("sword"), Is.EqualTo(_testItem));
            Assert.That(_testPlayer.Inventory.HasItem("sword"), Is.True);   
        }

        [TestCase("me")]
        [TestCase("inventory")]
        public void TestPlayerLocatesItself(string idents)
        {
            Assert.That(_testPlayer.Locate(idents), Is.EqualTo(_testPlayer));
        }

        // The player returns null/nil object if asked to locate something
        // it does not have
        public void TestPlayerLocatesNothing()
        {
            Assert.That(_testPlayer!.Locate("pc"), Is.Null);
        }

        // The player's full description contains the text
        // "You are (the player's name), (the player's description). You are carrying:"
        // and the short description of the items player has (from its inventory's item list).
        [Test]
        public void TestPlayerFullDescription()
        {
            Assert.That(_testPlayer!.FullDescription, 
                Is.EqualTo("You are Loysing, A new programmer learning OOP!.\nYou are carrying:\n\ta bronze sword (sword)\n"));
        }
    }
}