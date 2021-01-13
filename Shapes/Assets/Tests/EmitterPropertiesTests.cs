using System.Collections;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class EmitterPropertiesTests
    {
        private EmitterProperties CreateDefaultEmitterProperties()
        {
            return new GameObject().AddComponent<EmitterProperties>();
        }

        private EmitterProperties CreateEmitterPropertiesWithCustomPosition(Vector3 position)
        {
            var gameObject = CreateDefaultEmitterProperties();
            gameObject.transform.position = position;
            return gameObject;
        }

        private void RunConstantsMonoBehaviours()
        {
            GameObject.FindGameObjectWithTag("Constants")
                .GetComponent<Constants>()
                .runInEditMode = true;
        }

        [UnityTest]
        public IEnumerator Start_TransformPositionXIsNegative_SetsXToLowerNegative()
        {
            RunConstantsMonoBehaviours();

            var initialPosition = Vector3.left;
            var sut = CreateEmitterPropertiesWithCustomPosition(initialPosition);
            sut.runInEditMode = true;
            yield return null;

            var result = sut.transform.position.x;
            
            Assert.That(result, Is.LessThan(initialPosition.x));
        }

        [UnityTest]
        public IEnumerator Start_TransformPositionXIsPositive_SetsXToHigherPositive()
        {
            RunConstantsMonoBehaviours();

            var initialPosition = Vector3.right;
            var sut = CreateEmitterPropertiesWithCustomPosition(initialPosition);
            sut.runInEditMode = true;
            yield return null;

            var result = sut.transform.position.x;

            Assert.That(result, Is.GreaterThan(initialPosition.x));
        }

        [UnityTest]
        public IEnumerator Start_TransformPositionXIsZero_SetsXToZero()
        {
            var sut = CreateDefaultEmitterProperties();
            sut.runInEditMode = true;
            yield return null;

            var result = sut.transform.position.x;

            Assert.That(result, Is.Zero);
        }

        [Test]
        public void GetXDirection_TransformPositionXIsNegative_ReturnsPositiveOne()
        {
            var sut = CreateDefaultEmitterProperties();
            
            sut.transform.position = Vector3.left;
            var result = sut.GetXDirection();

            Assert.That(result, Is.EqualTo(1.0f));
        }

        [Test]
        public void GetXDirection_TransformPositionXIsPositive_ReturnsNegativeOne()
        {
            var sut = CreateDefaultEmitterProperties();
            
            sut.transform.position = Vector3.right;
            var result = sut.GetXDirection();

            Assert.That(result, Is.EqualTo(-1.0f));
        }

        [Test]
        public void GetXDirection_TransformPositionXIsZero_ReturnsRandomBetweenNegativeAndPositiveOne()
        {
            var sut = CreateDefaultEmitterProperties();

            var result = sut.GetXDirection();

            Assert.That(result, Is.InRange(-1.0f, 1.0f));
        }

        [Test]
        public void GetYDirection_TransformPositionYIsNegative_ReturnsPositiveOne()
        {
            var sut = CreateDefaultEmitterProperties();

            sut.transform.position = Vector3.down;
            var result = sut.GetYDirection();

            Assert.That(result, Is.EqualTo(1.0f));
        }

        [Test]
        public void GetYDirection_TransformPositionYIsPositive_ReturnsNegativeOne()
        {
            var sut = CreateDefaultEmitterProperties();

            sut.transform.position = Vector3.up;
            var result = sut.GetYDirection();

            Assert.That(result, Is.EqualTo(-1.0f));
        }

        [Test]
        public void GetYDirection_TransformPositionYIsZero_ReturnsRandomBetweenNegativeAndPositiveOne()
        {
            var sut = CreateDefaultEmitterProperties();
            
            var result = sut.GetYDirection();

            Assert.That(result, Is.InRange(-1.0f, 1.0f));
        }
    }
}
