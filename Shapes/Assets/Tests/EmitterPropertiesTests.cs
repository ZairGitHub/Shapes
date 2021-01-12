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
            return new GameObject()
            {
                name = name
            }.AddComponent<EmitterProperties>();
        }

        private GameObject CreateEmitterPropertiesWithRenderer()
        {
            var gameObject = new GameObject();
            gameObject.AddComponent<EmitterProperties>();
            gameObject.AddComponent<MeshRenderer>();
            return gameObject;
        }

        private GameObject CreateEmitterPropertiesWithRunInEditMode()
        {
            var gameObject = new GameObject();
            gameObject.AddComponent<EmitterProperties>();
            gameObject.AddComponent<MeshRenderer>();
            gameObject.GetComponent<EmitterProperties>().runInEditMode = true;
            return gameObject;
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
            var sut = CreateEmitterPropertiesWithRenderer();
            sut.name += "LEFT";
            sut.GetComponent<EmitterProperties>().runInEditMode = true;

            var result = sut.GetComponent<EmitterProperties>().GetXDirection();

            Assert.That(result, Is.EqualTo(1.0f));
        }

        [Test]
        public void GetXDirection_NameContainsRight_ReturnsNegativeOne()
        {
            var sut = CreateEmitterPropertiesWithRenderer();
            sut.name += "RIGHT";
            sut.GetComponent<EmitterProperties>().runInEditMode = true;

            var result = sut.GetComponent<EmitterProperties>().GetXDirection();

            Assert.That(result, Is.EqualTo(-1.0f));
        }

        [Test]
        public void GetXDirection_NameDoesNotContainLeftOrRight_ReturnsRandomBetweenNegativeAndPositiveOne()
        {
            var sut = CreateEmitterPropertiesWithRunInEditMode();

            var result = sut.GetComponent<EmitterProperties>().GetXDirection();

            Assert.That(result, Is.InRange(-1.0f, 1.0f));
        }

        [Test]
        public void GetYDirection_NameContainsTop_ReturnsNegativeOne()
        {
            var sut = CreateEmitterPropertiesWithRenderer();
            sut.name += "TOP";
            sut.GetComponent<EmitterProperties>().runInEditMode = true;

            var result = sut.GetComponent<EmitterProperties>().GetYDirection();

            Assert.That(result, Is.EqualTo(-1.0f));
        }

        [Test]
        public void GetYDirection_NameContainsBottom_ReturnsPositiveOne()
        {
            var sut = CreateEmitterPropertiesWithRenderer();
            sut.name += "BOTTOM";
            sut.GetComponent<EmitterProperties>().runInEditMode = true;

            var result = sut.GetComponent<EmitterProperties>().GetYDirection();

            Assert.That(result, Is.EqualTo(1.0f));
        }

        [Test]
        public void GetYDirection_NameDoesNotContainTopOrBottom_ReturnsRandomBetweenNegativeAndPositiveOne()
        {
            var sut = CreateEmitterPropertiesWithRunInEditMode();
            
            var result = sut.GetComponent<EmitterProperties>().GetYDirection();

            Assert.That(result, Is.InRange(-1.0f, 1.0f));
        }
    }
}
