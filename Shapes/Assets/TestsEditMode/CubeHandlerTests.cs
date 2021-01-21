using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    [TestFixture]
    public class CubeHandlerTests
    {
        private CubeHandler CreateDefaultCubeHandler()
        {
            return new GameObject().AddComponent<CubeHandler>();
        }

        [UnityTest]
        public IEnumerator Initialisation_DoesNotSetSpeed()
        {
            var sut = CreateDefaultCubeHandler();
            sut.runInEditMode = true;
            yield return null;

            var result = sut.Speed;

            Assert.That(result, Is.Positive);
        }
        /*
        [Test]
        public void HasSpeed_SpeedIsPositive_ReturnsTrue()
        {
            var sut = CreateDefaultCubeHandler();
            sut.RunTestingConstructor(float.Epsilon);

            var result = sut.HasSpeed();

            Assert.That(result, Is.True);
        }

        [Test]
        public void SetDirection_SetsSpeedToAPositiveValue()
        {
            var sut = CreateDefaultCubeHandler();

            sut.SetDirection(0.0f, 0.0f);
            var result = sut.HasSpeed();

            Assert.That(result, Is.True);
        }
        */
    }
}
