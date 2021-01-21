using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    [TestFixture]
    public class SphereHandlerTests
    {
        private SphereHandler CreateDefaultSphereHandler()
        {
            return new GameObject().AddComponent<SphereHandler>();
        }

        [Test]
        public void HasSpeed_SpeedIsNotPositive_ReturnsFalse()
        {
            var sut = CreateDefaultSphereHandler();
            sut.RunTestingConstructor(0.0f);

            var result = sut.HasSpeed();

            Assert.That(result, Is.False);
        }

        [Test]
        public void HasSpeed_SpeedIsPositive_ReturnsTrue()
        {
            var sut = CreateDefaultSphereHandler();
            sut.RunTestingConstructor(float.Epsilon);

            var result = sut.HasSpeed();

            Assert.That(result, Is.True);
        }
    }
}
