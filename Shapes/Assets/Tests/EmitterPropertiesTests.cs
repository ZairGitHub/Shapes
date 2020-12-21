using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class EmitterPropertiesTests
    {
        [UnityTest]
        public IEnumerable GetXDirection_NameToLowerContainsLeft_ReturnsPositiveOne()
        {
            var sut = new GameObject().AddComponent<EmitterProperties>();
            sut.name += "LEFT";
            yield return null;

            var result = sut.GetXDirection();

            Assert.That(result, Is.EqualTo(1.0f));
        }

        [UnityTest]
        public IEnumerable GetXDirection_NameToLowerContainsRight_ReturnsNegativeOne()
        {
            var sut = new GameObject().AddComponent<EmitterProperties>();
            sut.name += "RIGHT";
            yield return null;

            var result = sut.GetXDirection();

            Assert.That(result, Is.EqualTo(-1.0f));
        }

        [Test]
        public void GetXDirection_NameToLowerDoesNotConatainLeftOrRight_ReturnsRandomBetweenNegativeAndPositiveOne()
        {
            var sut = new GameObject().AddComponent<EmitterProperties>();

            var result = sut.GetXDirection();

            Assert.That(result, Is.InRange(-1.0f, 1.0f));
        }

        [UnityTest]
        public IEnumerable GetYDirection_NameToLowerContainsTop_ReturnsNegativeOne()
        {
            var sut = new GameObject().AddComponent<EmitterProperties>();
            sut.name += "TOP";
            yield return null;

            var result = sut.GetYDirection();

            Assert.That(result, Is.EqualTo(-1.0f));
        }

        [UnityTest]
        public IEnumerable GetYDirection_NameToLowerContainsBottom_ReturnsNegativeOne()
        {
            var sut = new GameObject().AddComponent<EmitterProperties>();
            sut.name += "BOTTOM";
            yield return null;

            var result = sut.GetYDirection();

            Assert.That(result, Is.EqualTo(1.0f));
        }

        [Test]
        public void GetYDirection_NameToLowerDoesNotConatainTopOrBottom_ReturnsRandomBetweenNegativeAndPositiveOne()
        {
            var sut = new GameObject().AddComponent<EmitterProperties>();
            
            var result = sut.GetYDirection();

            Assert.That(result, Is.InRange(-1.0f, 1.0f));
        }
    }
}
