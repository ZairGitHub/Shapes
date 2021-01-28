using System.Collections;
using NSubstitute;
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

            Assert.That(result, Is.Zero);
        }
        
        [Test]
        public void SetDirection_SetsSpeedToPositiveValue()
        {
            var mock = Substitute.For<IConstants>();
            mock.HalfGameWidth.Returns(1.0f);
            mock.HalfGameHeight.Returns(1.0f);
            var sut = CreateDefaultCubeHandler();
            sut.RunTestingConstructor(mock);

            sut.SetDirection(0.0f, 0.0f);
            var result = sut.Speed;

            Assert.That(result, Is.Positive);
        }
    }
}
