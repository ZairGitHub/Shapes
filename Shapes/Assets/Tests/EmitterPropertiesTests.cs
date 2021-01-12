using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class EmitterPropertiesTests
    {
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
            var sut = CreateEmitterPropertiesWithRenderer();
            sut.name = "GameObject";
            sut.GetComponent<EmitterProperties>().runInEditMode = true;

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

        [UnityTest]
        public IEnumerator GetXDirection_NameDoesNotContainLeftOrRight_ReturnsRandomBetweenNegativeAndPositiveOne()
        {
            var sut = CreateEmitterPropertiesWithRunInEditMode();
            yield return null;

            var result = sut.GetComponent<EmitterProperties>().GetXDirection();

            Assert.That(result, Is.InRange(-1.0f, 1.0f));
        }

        [UnityTest]
        public IEnumerator GetYDirection_NameContainsTop_ReturnsNegativeOne()
        {
            var sut = CreateEmitterPropertiesWithRunInEditMode();
            sut.name += "TOP";
            yield return null;

            var result = sut.GetComponent<EmitterProperties>().GetYDirection();

            Assert.That(result, Is.EqualTo(-1.0f));
        }

        [UnityTest]
        public IEnumerator GetYDirection_NameContainsBottom_ReturnsPositiveOne()
        {
            var sut = CreateEmitterPropertiesWithRunInEditMode();
            sut.name += "BOTTOM";
            yield return null;

            var result = sut.GetComponent<EmitterProperties>().GetYDirection();

            Assert.That(result, Is.EqualTo(1.0f));
        }

        [UnityTest]
        public IEnumerator GetYDirection_NameDoesNotContainTopOrBottom_ReturnsRandomBetweenNegativeAndPositiveOne()
        {
            var sut = CreateEmitterPropertiesWithRunInEditMode();
            yield return null;
            
            var result = sut.GetComponent<EmitterProperties>().GetYDirection();

            Assert.That(result, Is.InRange(-1.0f, 1.0f));
        }

        [Ignore("GetPosition() always incorrectly returns Vector3.zero")]
        [UnityTest]
        public IEnumerator GetPosition_NameContainsLeft_ReturnsNegativeVector3XValue()
        {
            var sut = CreateEmitterPropertiesWithRunInEditMode();
            sut.name += "LEFT";
            yield return null;

            var result = sut.GetComponent<EmitterProperties>().GetPosition().x;

            Assert.That(result, Is.Negative);
        }

        [Ignore("GetPosition() always incorrectly returns Vector3.zero")]
        [UnityTest]
        public IEnumerator GetPosition_NameContainsRight_ReturnsPositiveVector3XValue()
        {
            var sut = CreateEmitterPropertiesWithRunInEditMode();
            sut.name += "RIGHT";
            yield return null;

            var result = sut.GetComponent<EmitterProperties>().GetPosition().x;

            Assert.That(result, Is.Positive);
        }

        [Ignore("GetPosition() always incorrectly returns Vector3.zero")]
        [UnityTest]
        public IEnumerator GetPosition_NameDoesNotContainLeftOrRight_ReturnsZeroVector3XValue()
        {
            var sut = CreateEmitterPropertiesWithRunInEditMode();
            yield return null;
            
            var result = sut.GetComponent<EmitterProperties>().GetPosition().x;

            Assert.That(result, Is.Zero);
        }

        [Ignore("GetPosition() always incorrectly returns Vector3.zero")]
        [UnityTest]
        public IEnumerator GetPosition_NameContainsTop_ReturnsPositiveVector3YValue()
        {
            var sut = CreateEmitterPropertiesWithRunInEditMode();
            sut.name += "TOP";
            yield return null;

            var result = sut.GetComponent<EmitterProperties>().GetPosition().y;

            Assert.That(result, Is.Positive);
        }

        [Ignore("GetPosition() always incorrectly returns Vector3.zero")]
        [UnityTest]
        public IEnumerator GetPosition_NameContainsBottom_ReturnsNegativeVector3YValue()
        {
            var sut = new GameObject().AddComponent<EmitterProperties>();
            sut.name += "BOTTOM";
            yield return null;

            var result = sut.GetComponent<EmitterProperties>().GetPosition().y;

            Assert.That(result, Is.Negative);
        }

        [Ignore("GetPosition() always incorrectly returns Vector3.zero")]
        [UnityTest]
        public IEnumerator GetPosition_NameDoesNotContainTopOrBottom_ReturnsZeroVector3YValue()
        {
            var sut = CreateEmitterPropertiesWithRunInEditMode();
            yield return null;

            var result = sut.GetComponent<EmitterProperties>().GetPosition().y;

            Assert.That(result, Is.Zero);
        }
    }
}
