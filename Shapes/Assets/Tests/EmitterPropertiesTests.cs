using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class EmitterPropertiesTests
    {
        private GameObject CreateEmitterPropertiesWithRunInEditMode()
        {
            var gameObject = new GameObject();
            gameObject.AddComponent<EmitterProperties>();
            gameObject.AddComponent<MeshRenderer>();
            gameObject.GetComponent<EmitterProperties>().runInEditMode = true;
            return gameObject;
        }

        [UnityTest]
        public IEnumerator Start_SetsNameToLowercase()
        {
            var sut = CreateEmitterPropertiesWithRunInEditMode();
            sut.name = "GameObject";
            yield return null;
            
            var result = sut.name;
            
            Assert.That(result, Is.EqualTo("gameobject"));
        }

        [UnityTest]
        public IEnumerator GetXDirection_NameContainsLeft_ReturnsPositiveOne()
        {
            var sut = CreateEmitterPropertiesWithRunInEditMode();
            sut.name += "LEFT";
            yield return null;

            var result = sut.GetComponent<EmitterProperties>().GetXDirection();

            Assert.That(result, Is.EqualTo(1.0f));
        }

        [UnityTest]
        public IEnumerator GetXDirection_NameContainsRight_ReturnsNegativeOne()
        {
            var sut = CreateEmitterPropertiesWithRunInEditMode();
            sut.name += "RIGHT";
            yield return null;

            var result = sut.GetComponent<EmitterProperties>().GetXDirection();

            Assert.That(result, Is.EqualTo(-1.0f));
        }

        [UnityTest]
        public IEnumerator GetXDirection_NameDoesNotContainLeftOrRight_ReturnsRandomBetweenNegativeAndPositiveOne()
        {
            var sut = CreateEmitterPropertiesWithRunInEditMode();
            yield return null;

            var result = sut.AddComponent<EmitterProperties>().GetXDirection();

            Assert.That(result, Is.InRange(-1.0f, 1.0f));
        }

        [UnityTest]
        public IEnumerator GetYDirection_NameContainsTop_ReturnsNegativeOne()
        {
            var sut = CreateEmitterPropertiesWithRunInEditMode();
            sut.name += "TOP";
            yield return null;

            var result = sut.AddComponent<EmitterProperties>().GetYDirection();

            Assert.That(result, Is.EqualTo(-1.0f));
        }

        [UnityTest]
        public IEnumerator GetYDirection_NameContainsBottom_ReturnsPositiveOne()
        {
            var sut = CreateEmitterPropertiesWithRunInEditMode();
            sut.name += "BOTTOM";
            yield return null;

            var result = sut.AddComponent<EmitterProperties>().GetYDirection();

            Assert.That(result, Is.EqualTo(1.0f));
        }

        [UnityTest]
        public IEnumerator GetYDirection_NameDoesNotContainTopOrBottom_ReturnsRandomBetweenNegativeAndPositiveOne()
        {
            var sut = CreateEmitterPropertiesWithRunInEditMode();
            yield return null;
            
            var result = sut.AddComponent<EmitterProperties>().GetYDirection();

            Assert.That(result, Is.InRange(-1.0f, 1.0f));
        }

        [UnityTest]
        public IEnumerator GetPosition_NameContainsLeft_ReturnsNegativeVector3XValue()
        {
            var sut = CreateEmitterPropertiesWithRunInEditMode();
            sut.name += "LEFT";
            yield return null;

            var result = sut.AddComponent<EmitterProperties>().GetPosition().x;

            Assert.That(result, Is.Negative);
        }

        [UnityTest]
        public IEnumerator GetPosition_NameContainsRight_ReturnsPositiveVector3XValue()
        {
            var sut = CreateEmitterPropertiesWithRunInEditMode();
            sut.name += "RIGHT";
            yield return null;

            var result = sut.AddComponent<EmitterProperties>().GetPosition().x;

            Assert.That(result, Is.Positive);
        }

        [UnityTest]
        public IEnumerator GetPosition_NameDoesNotContainLeftOrRight_ReturnsZeroVector3XValue()
        {
            var sut = CreateEmitterPropertiesWithRunInEditMode();
            yield return null;
            
            var result = sut.AddComponent<EmitterProperties>().GetPosition().x;

            Assert.That(result, Is.Zero);
        }

        [UnityTest]
        public IEnumerator GetPosition_NameContainsTop_ReturnsPositiveVector3YValue()
        {
            var sut = CreateEmitterPropertiesWithRunInEditMode();
            sut.name += "TOP";
            yield return null;

            var result = sut.AddComponent<EmitterProperties>().GetPosition().y;

            Assert.That(result, Is.Positive);
        }

        [UnityTest]
        public IEnumerator GetPosition_NameContainsBottom_ReturnsNegativeVector3YValue()
        {
            var sut = new GameObject().AddComponent<EmitterProperties>();
            sut.name += "BOTTOM";
            yield return null;

            var result = sut.GetPosition().y;

            Assert.That(result, Is.Negative);
        }

        [UnityTest]
        public IEnumerator GetPosition_NameDoesNotContainTopOrBottom_ReturnsZeroVector3YValue()
        {
            var sut = CreateEmitterPropertiesWithRunInEditMode();
            yield return null;

            var result = sut.AddComponent<EmitterProperties>().GetPosition().y;

            Assert.That(result, Is.Zero);
        }
    }
}
