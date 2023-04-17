using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using SwinAdventure;

namespace NUnitTests
{
    public class TestLookCommand
    {
        private Player? _testPlayer;
        private Item? _testItem;
        private Bag? _testBag;
        private LookCommand? _testLookCommand;

        [SetUp]
        public void Setup()
        {
            _testPlayer = new Player("player", "A new programmer learning OOP!");
            _testItem = new Item(new string[] {"gem"}, "a red gem", "A bright red shiny");
            _testBag = new Bag(new string[] {"bag", "b1"}, "bag", "a bag that can hold items");
            _testLookCommand = new LookCommand();
        }

        // Returns player description when looking at "inventory"
        [Test]
        public void TestLookAtMe()
        {
            Assert.That(_testLookCommand!.Execute(_testPlayer!, new string[]{"look", "at", "inventory"}), Is.EqualTo(_testPlayer!.FullDescription));
        }

        // Returns the gems description when looking at a gem
        // in the player's inventory.
        [Test]
        public void TestLookAtGem()
        {
            _testPlayer!.Inventory.Put(_testItem!);
            Assert.That(_testLookCommand!.Execute(_testPlayer, new string[]{"look", "at", "gem"}), Is.EqualTo(_testItem!.FullDescription));
        }

        // Returns "I can't find the gem" whe the player does not 
        // have  agem in their inventory
        [Test]
        public void TestLookAtUnknown()
        {
            Assert.That(_testLookCommand!.Execute(_testPlayer!, new string[]{"look", "at", "gem"}), Is.EqualTo($"I can't find the gem in the {_testPlayer!.Name}"));
        }

        // Returns the gem's description when looking at a gem in the 
        // player's inventory. "look at the gem in inventory"
        [Test]
        public void TestLookAtGemInMe()
        {
            _testPlayer!.Inventory.Put(_testItem!);
            Assert.That(_testLookCommand!.Execute(_testPlayer, new string[]{"look", "at", "gem", "in", "inventory"}), Is.EqualTo(_testItem!.FullDescription));
        }

        // Returns the gem's description when looking at a gem in a bag that
        // is in the player's inventory
        [Test]
        public void TestLookAtGemInBag()
        {
            _testBag!.Inventory.Put(_testItem!);
            _testPlayer!.Inventory.Put(_testBag);
            Assert.That(_testLookCommand!.Execute(_testPlayer!, new string[]{"look", "at", "gem", "in", "bag"}), Is.EqualTo(_testItem!.FullDescription));
        }

        // Returns "I can't find the bag" when the player does not have a 
        // a bag in their inventory
        [Test]
        public void TestLookAtGemInNoBag()
        {
            Assert.That(_testLookCommand!.Execute(_testPlayer!, new string[]{"look", "at", "gem", "in", "bag"}), Is.EqualTo("I can't find the bag"));
        }

        // Returns "I can't find the gem" when the bag does not have a gem in 
        // its inventory
        [Test]
        public void TestLookAtNoGemInBag()
        {
            _testPlayer!.Inventory.Put(_testBag!);
            Assert.That(_testLookCommand!.Execute(_testPlayer, new string[]{"look", "at", "gem", "in", "bag"}), Is.EqualTo("I can't find the gem in the bag"));
        }

        // Test look options to check all error conditions. For example:
        // "look around" or "hello", "look at a at b", etc.
        [Test]
        public void TestInvalidLook()
        {
            Assert.That(_testLookCommand!.Execute(_testPlayer!, new string[]{"look", "around"}), Is.EqualTo("I don't know how to look like that"));
            Assert.That(_testLookCommand!.Execute(_testPlayer!, new string[]{"hello", "look", "around"}), Is.EqualTo("Error in look input"));
            Assert.That(_testLookCommand!.Execute(_testPlayer!, new string[]{"look", "a", "gem"}), Is.EqualTo("What do you want to look at?"));
            Assert.That(_testLookCommand!.Execute(_testPlayer!, new string[]{"look", "at", "gem", "bag", "now"}), Is.EqualTo("What do you want to look in?"));
        }
    }
}