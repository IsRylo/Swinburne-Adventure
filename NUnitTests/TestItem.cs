using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using SwinAdventure;

namespace NUnitTests
{
    [TestFixture]
    public class TestItem
    {
        private Item _testItem;
        [SetUp]
        public void Setup()
        {
            _testItem = new Item (new string[] {"sword", "blade"}, "a bronze sword", "Starter weapon for players to use.");
        }

        // Item responds correctly to "Are You" requests based on the
        // idenfiers it is created with
        [TestCase("sword", ExpectedResult=true)]
        [TestCase("blade", ExpectedResult=true)]
        [TestCase("me", ExpectedResult=false)]
        public bool TestItemIsIdentifiable(string ident)
        {
            return _testItem!.AreYou(ident);            
        }

        // The game object's short description returns 
        // the string "a name (first id)"
        [Test]
        public void TestShortDescription()
        {
            Assert.That(_testItem!.ShortDescription, Is.EqualTo("a bronze sword (sword)"));
        }

        [Test]
        public void TestFullDescription()
        {
            Assert.That(_testItem!.FullDescription, Is.EqualTo("Starter weapon for players to use."));
        }
    }
}