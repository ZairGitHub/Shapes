using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class CubeHandlerTests
    {
        private CubeHandler CreateDefaultCubeHandler()
        {
            return new GameObject().AddComponent<CubeHandler>();
        }

        [Test]
        public void HasSpeed_SpeedIsNotPositive_ReturnsFalse()
        {
            var sut = CreateDefaultCubeHandler();
            sut.RunTestingConstructor(0.0f);

            var result = sut.HasSpeed();

            Assert.That(result, Is.False);
        }

        [Test]
        public void HasSpeed_SpeedIsPositive_ReturnsTrue()
        {
            var sut = CreateDefaultCubeHandler();
            sut.RunTestingConstructor(float.Epsilon);

            var result = sut.HasSpeed();

            Assert.That(result, Is.True);
        }
    }
}
