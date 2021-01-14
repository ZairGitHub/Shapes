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
        public void SetPosition_Vector3XIsNegative_SetsXToALowerValue()
        {
            var sut = CreateDefaultEmitterPropertiesWithMock();

            var result = sut.SetPosition(Vector3.left).x;
            
            Assert.That(result, Is.EqualTo(-_mockValue));
        }

        [Test]
        public void SetPosition_Vector3XIsPositive_SetsXToAHigherValue()
        {
            var sut = CreateDefaultEmitterPropertiesWithMock();

            var result = sut.SetPosition(Vector3.right).x;

            Assert.That(result, Is.EqualTo(_mockValue));
        }

        [Test]
        public void SetPosition_Vector3XIsZero_SetsXToZero()
        {
            var sut = CreateDefaultEmitterPropertiesWithMock();

            var result = sut.SetPosition(Vector3.zero).x;
            
            Assert.That(result, Is.Zero);
        }

        [Test]
        public void SetPosition_Vector3YIsNegative_SetsYToALowerValue()
        {
            var sut = CreateDefaultEmitterPropertiesWithMock();

            var result = sut.SetPosition(Vector3.down).y;

            Assert.That(result, Is.EqualTo(-_mockValue));
        }

        [Test]
        public void SetPosition_Vector3YIsPositive_SetsYToAHigherValue()
        {
            var sut = CreateDefaultEmitterPropertiesWithMock();

            var result = sut.SetPosition(Vector3.up).y;

            Assert.That(result, Is.EqualTo(_mockValue));
        }

        [Test]
        public void SetPosition_VectorYXIsZero_SetsYToZero()
        {
            var sut = CreateDefaultEmitterPropertiesWithMock();

            var result = sut.SetPosition(Vector3.zero).y;

            Assert.That(result, Is.Zero);
        }

        /*
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
