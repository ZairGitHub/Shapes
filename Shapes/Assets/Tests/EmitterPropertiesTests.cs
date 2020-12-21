using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class EmitterPropertiesTests
    {
        [Test]
        public void GetXDirection_NameContainsleft_ReturnsPositiveOne()
        {
            var sut = new GameObject().AddComponent<EmitterProperties>();
            sut.name += "left";

            var result = sut.GetXDirection();

            Assert.That(result, Is.EqualTo(1.0f));
        }

        [Test]
        public void GetXDirection_NameContainsright_ReturnsNegativeOne()
        {
            var sut = new GameObject().AddComponent<EmitterProperties>();
            sut.name += "right";

            var result = sut.GetXDirection();

            Assert.That(result, Is.EqualTo(-1.0f));
        }

        [Test]
        public void GetXDirection_NameDoesNotConatainleftOrright_ReturnsRandomBetweenNegativeAndPositiveOne()
        {
            var sut = new GameObject().AddComponent<EmitterProperties>();

            var result = sut.GetXDirection();

            Assert.That(result, Is.InRange(-1.0f, 1.0f));
        }
    }
}
