using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class EmitterPropertiesTests
    {
        private EmitterProperties CreateDefaultEmitterProperties()
        {
            return new GameObject().AddComponent<EmitterProperties>();
        }

        private EmitterProperties CreateEmitterPropertiesWithCustomName(string name)
        {
            var g = new GameObject()
            {
                name = name
            }.AddComponent<EmitterProperties>();
            return g;
        }

        [Test]
        public void Awake_SetsNameToLowercase()
        {
            var sut = CreateEmitterPropertiesWithCustomName("GameObject");
            sut.runInEditMode = true;

            var result = sut.name;
            
            Assert.That(result, Is.EqualTo("gameobject"));
        }

        [Test]
        public void GetXDirection_NameContainsLeft_ReturnsPositiveOne()
        {
            var sut = CreateEmitterPropertiesWithCustomName("LEFT");
            sut.runInEditMode = true;

            var result = sut.GetXDirection();

            Assert.That(result, Is.EqualTo(1.0f));
        }

        [Test]
        public void GetXDirection_NameContainsRight_ReturnsNegativeOne()
        {
            var sut = CreateEmitterPropertiesWithCustomName("RIGHT");
            sut.runInEditMode = true;

            var result = sut.GetXDirection();

            Assert.That(result, Is.EqualTo(-1.0f));
        }

        [Test]
        public void GetXDirection_NameDoesNotContainLeftOrRight_ReturnsRandomBetweenNegativeAndPositiveOne()
        {
            var sut = CreateDefaultEmitterProperties();

            var result = sut.GetXDirection();

            Assert.That(result, Is.InRange(-1.0f, 1.0f));
        }

        [Test]
        public void GetYDirection_NameContainsTop_ReturnsNegativeOne()
        {
            var sut = CreateEmitterPropertiesWithCustomName("TOP");
            sut.runInEditMode = true;

            var result = sut.GetYDirection();

            Assert.That(result, Is.EqualTo(-1.0f));
        }

        [Test]
        public void GetYDirection_NameContainsBottom_ReturnsPositiveOne()
        {
            var sut = CreateEmitterPropertiesWithCustomName("BOTTOM");
            sut.runInEditMode = true;

            var result = sut.GetYDirection();

            Assert.That(result, Is.EqualTo(1.0f));
        }

        [Test]
        public void GetYDirection_NameDoesNotContainTopOrBottom_ReturnsRandomBetweenNegativeAndPositiveOne()
        {
            var sut = CreateDefaultEmitterProperties();
            
            var result = sut.GetYDirection();

            Assert.That(result, Is.InRange(-1.0f, 1.0f));
        }
    }
}
