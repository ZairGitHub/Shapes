using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class EmitterPropertiesTests
    {
        [UnityTest]
        public IEnumerable Start_SetsNameToLowercase()
        {
            var sut = new GameObject().AddComponent<EmitterProperties>();
            sut.name = "GameObject";
            yield return null;

            var result = sut.name;

            Assert.That(result, Is.EqualTo("gameobject"));
        }

        [UnityTest]
        public IEnumerable GetXDirection_NameContainsLeft_ReturnsPositiveOne()
        {
            var sut = new GameObject().AddComponent<EmitterProperties>();
            sut.name += "LEFT";
            yield return null;

            var result = sut.GetXDirection();

            Assert.That(result, Is.EqualTo(1.0f));
        }

        [UnityTest]
        public IEnumerable GetXDirection_NameContainsRight_ReturnsNegativeOne()
        {
            var sut = new GameObject().AddComponent<EmitterProperties>();
            sut.name += "RIGHT";
            yield return null;

            var result = sut.GetXDirection();

            Assert.That(result, Is.EqualTo(-1.0f));
        }

        [Test]
        public void GetXDirection_NameDoesNotContainLeftOrRight_ReturnsRandomBetweenNegativeAndPositiveOne()
        {
            var sut = new GameObject().AddComponent<EmitterProperties>();

            var result = sut.GetXDirection();

            Assert.That(result, Is.InRange(-1.0f, 1.0f));
        }

        [UnityTest]
        public IEnumerable GetYDirection_NameContainsTop_ReturnsNegativeOne()
        {
            var sut = new GameObject().AddComponent<EmitterProperties>();
            sut.name += "TOP";
            yield return null;

            var result = sut.GetYDirection();

            Assert.That(result, Is.EqualTo(-1.0f));
        }

        [UnityTest]
        public IEnumerable GetYDirection_NameContainsBottom_ReturnsNegativeOne()
        {
            var sut = new GameObject().AddComponent<EmitterProperties>();
            sut.name += "BOTTOM";
            yield return null;

            var result = sut.GetYDirection();

            Assert.That(result, Is.EqualTo(1.0f));
        }

        [Test]
        public void GetYDirection_NameDoesNotContainTopOrBottom_ReturnsRandomBetweenNegativeAndPositiveOne()
        {
            var sut = new GameObject().AddComponent<EmitterProperties>();
            
            var result = sut.GetYDirection();

            Assert.That(result, Is.InRange(-1.0f, 1.0f));
        }
    }
}
