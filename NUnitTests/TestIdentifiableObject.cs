using System;
using System.Collections.Generic;
using NUnit.Framework;
using SwinAdventure;

namespace NUnitTests
{
    [TestFixture]
    public class TestIdentifiableObject
    {
        private IdentifiableObject _testableIdentifiableObject;

        [SetUp]
        public void SetUp()
        {
            // Setup to reduce setting up repeatedly
            _testableIdentifiableObject = new IdentifiableObject(new string[] {"fred", "bob"});
        }

        [TestCase("fred")]
        [TestCase("bob")]
        public void TestAreYou(string name)
        {
            // Check that it responds "True" to the "Are You" message where
            // the request matches on of the object's identifier.

            // Changed: Remove the extra boolean variable
            Assert.IsTrue(_testableIdentifiableObject.AreYou(name));
        }

        [TestCase("wilma")]
        [TestCase("boby")]
        public void TestNotAreYou(string name)
        {
            // Check that it responds "False" to the "Are You" message where
            // the request matches one of the object's identifiers.

            // Changed: Remove the extra boolean variable
            Assert.IsFalse(_testableIdentifiableObject.AreYou(name));
        }

        [TestCase("FRED")]
        [TestCase("bOb")]
        public void TestCaseSensitive(string name)
        {
            // Check that it responds "True" to the "Are You" message where 
            // the request matches one of the object's identifiers where 
            // there is a mismatch in case.
            Assert.IsTrue(_testableIdentifiableObject.AreYou(name));
        }

        [Test]
        public void TestFirstId()
        {
            // Check that the first id returns the first identifier in the
            // list of identifier.
            Assert.That(_testableIdentifiableObject.FirstId, Is.EqualTo("fred"));
        }

        [Test]
        public void TestFirstIdWithNoIds()
        {
            // Check that an empty string is return if there are no 
            // identifiers in the list of identifiers
            _testableIdentifiableObject = new IdentifiableObject(new string[] {});
            Assert.That(_testableIdentifiableObject.FirstId, Is.EqualTo(String.Empty));
        }

        [Test]
        public void TestAddId()
        {
            // Check that you can add identifiers to the object
            _testableIdentifiableObject.AddIdentifier("wilma");
            Assert.IsTrue(_testableIdentifiableObject.AreYou("wilma"));
        }
    }
}