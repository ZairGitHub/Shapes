using System.Collections;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    [TestFixture]
    public class EmitterPropertiesTests
    {
        private const float _mockValue = 10.0f;

        private EmitterProperties CreateDefaultEmitterPropertiesWithMock()
        {
            var mock = Substitute.For<IConstants>();
            mock.BoundaryHeight.Returns(_mockValue);
            mock.BoundaryWidth.Returns(_mockValue);
            return new EmitterProperties(mock);
        }
        [Test]
        public void SetPosition_TransformPositionXIsNegative_SetsXToALowerValue()
        {
            var gameObject = new GameObject().transform.position = Vector3.left;
            var sut = CreateDefaultEmitterPropertiesWithMock();

            var result = sut.SetPosition(gameObject.x, gameObject.y).x;
            
            Assert.That(result, Is.EqualTo(-_mockValue));
        }
        /*
        [UnityTest]
        public IEnumerator Start_TransformPositionXIsPositive_SetsXToHigherValue()
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
            var sut = CreateDefaultEmitterPropertiesWithMocks();
            sut.runInEditMode = true;
            yield return null;

            var result = sut.transform.position.x;

            Assert.That(result, Is.Zero);
        }

        [UnityTest]
        public IEnumerator Start_TransformPositionYIsNegative_SetsYToLowerValue()
        {
            RunConstantsMonoBehaviours();

            var initialPosition = Vector3.down;
            var sut = CreateEmitterPropertiesWithCustomPosition(initialPosition);
            sut.runInEditMode = true;
            yield return null;

            var result = sut.transform.position.y;

            Assert.That(result, Is.LessThan(initialPosition.y));
        }

        [UnityTest]
        public IEnumerator Start_TransformPositionYIsPositive_SetsYToHigherValue()
        {
            RunConstantsMonoBehaviours();

            var initialPosition = Vector3.up;
            var sut = CreateEmitterPropertiesWithCustomPosition(initialPosition);
            sut.runInEditMode = true;
            yield return null;

            var result = sut.transform.position.y;

            Assert.That(result, Is.GreaterThan(initialPosition.y));
        }

        [UnityTest]
        public IEnumerator Start_TransformPositionYIsZero_SetsYToZero()
        {
            var sut = CreateDefaultEmitterPropertiesWithMocks();
            sut.runInEditMode = true;
            yield return null;

            var result = sut.transform.position.y;

            Assert.That(result, Is.Zero);
        }

        [Test]
        public void GetXDirection_TransformPositionXIsNegative_ReturnsPositiveOne()
        {
            var sut = CreateDefaultEmitterPropertiesWithMocks();
            
            sut.transform.position = Vector3.left;
            var result = sut.GetXDirection();

            Assert.That(result, Is.EqualTo(1.0f));
        }

        [Test]
        public void GetXDirection_TransformPositionXIsPositive_ReturnsNegativeOne()
        {
            var sut = CreateDefaultEmitterPropertiesWithMocks();
            
            sut.transform.position = Vector3.right;
            var result = sut.GetDirection();

            Assert.That(result, Is.EqualTo(-1.0f));
        }

        [Test]
        public void GetXDirection_TransformPositionXIsZero_ReturnsRandomBetweenNegativeAndPositiveOne()
        {
            var sut = CreateDefaultEmitterPropertiesWithMocks();

            var result = sut.GetDirection();

            Assert.That(result, Is.InRange(-1.0f, 1.0f));
        }

        [Test]
        public void GetYDirection_TransformPositionYIsNegative_ReturnsPositiveOne()
        {
            var sut = CreateDefaultEmitterPropertiesWithMocks();

            sut.transform.position = Vector3.down;
            var result = sut.GetYDirection();

            Assert.That(result, Is.EqualTo(1.0f));
        }

        [Test]
        public void GetYDirection_TransformPositionYIsPositive_ReturnsNegativeOne()
        {
            var sut = CreateDefaultEmitterPropertiesWithMocks();

            sut.transform.position = Vector3.up;
            var result = sut.GetDirection();

            Assert.That(result, Is.EqualTo(-1.0f));
        }

        [Test]
        public void GetYDirection_TransformPositionYIsZero_ReturnsRandomBetweenNegativeAndPositiveOne()
        {
            var sut = CreateDefaultEmitterPropertiesWithMocks();
            
            var result = sut.GetDirection();

            Assert.That(result, Is.InRange(-1.0f, 1.0f));
        }
        */
    }
}
