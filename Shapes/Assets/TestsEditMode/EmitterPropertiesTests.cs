using NSubstitute;
using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    [TestFixture]
    public class EmitterPropertiesTests
    {
        private const float _mockValue = 10.0f;
        private const float _boundaryOffSet = 1.0f;

        private EmitterProperties CreateDefaultEmitterProperties()
        {
            return new EmitterProperties(Substitute.For<IConstants>());
        }

        private EmitterProperties CreateDefaultEmitterPropertiesWithMock()
        {
            var mock = Substitute.For<IConstants>();
            mock.HalfGameHeight.Returns(_mockValue);
            mock.HalfGameWidth.Returns(_mockValue);
            return new EmitterProperties(mock, _boundaryOffSet);
        }

        [Test]
        public void SetPosition_Vector3XIsNegative_SetsXToALowerValue()
        {
            var sut = CreateDefaultEmitterPropertiesWithMock();

            var result = sut.SetPosition(Vector3.left).x;
            
            Assert.That(result, Is.EqualTo(-_mockValue + _boundaryOffSet));
        }

        [Test]
        public void SetPosition_Vector3XIsPositive_SetsXToAHigherValue()
        {
            var sut = CreateDefaultEmitterPropertiesWithMock();

            var result = sut.SetPosition(Vector3.right).x;

            Assert.That(result, Is.EqualTo(_mockValue - _boundaryOffSet));
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

            Assert.That(result, Is.EqualTo(-_mockValue + _boundaryOffSet));
        }

        [Test]
        public void SetPosition_Vector3YIsPositive_SetsYToAHigherValue()
        {
            var sut = CreateDefaultEmitterPropertiesWithMock();

            var result = sut.SetPosition(Vector3.up).y;

            Assert.That(result, Is.EqualTo(_mockValue - _boundaryOffSet));
        }

        [Test]
        public void SetPosition_VectorYXIsZero_SetsYToZero()
        {
            var sut = CreateDefaultEmitterPropertiesWithMock();

            var result = sut.SetPosition(Vector3.zero).y;

            Assert.That(result, Is.Zero);
        }

        [Test, Repeat(100)]
        public void GetDirection_NegativeFloat_ReturnsRandomBetweenZeroAndPositiveOne()
        {
            var sut = CreateDefaultEmitterProperties();

            var result = sut.GetDirection(-1.0f);

            Assert.That(result, Is.InRange(0.0f, 1.0f));
        }

        [Test, Repeat(100)]
        public void GetDirection_PositiveFloat_ReturnsRandomBetweenNegativeOneAndZero()
        {
            var sut = CreateDefaultEmitterProperties();

            var result = sut.GetDirection(1.0f);

            Assert.That(result, Is.InRange(-1.0f, 0.0f));
        }

        [Test, Repeat(100)]
        public void GetDirection_FloatIsZero_ReturnsRandomBetweenNegativeAndPositiveOne()
        {
            var sut = CreateDefaultEmitterProperties();

            var result = sut.GetDirection(0.0f);

            Assert.That(result, Is.InRange(-1.0f, 1.0f));
        }
    }
}
