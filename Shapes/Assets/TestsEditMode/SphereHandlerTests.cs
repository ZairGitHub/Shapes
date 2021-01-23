using System.Collections;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    [TestFixture]
    public class SphereHandlerTests
    {
        private SphereHandler CreateDefaultSphereHandler()
        {
            return new GameObject().AddComponent<SphereHandler>();
        }

        [UnityTest]
        public IEnumerator Initialisation_DoesNotSetSpeed()
        {
            var sut = CreateDefaultSphereHandler();
            sut.runInEditMode = true;
            yield return null;

            var result = sut.Speed;

            Assert.That(result, Is.Zero);
        }

        [Test]
        public void SetDirection_SetsSpeedToPositiveValue()
        {
            var mock = Substitute.For<IConstants>();
            mock.HalfBoundaryWidth.Returns(1.0f);
            mock.HalfBoundaryHeight.Returns(1.0f);
            var sut = CreateDefaultSphereHandler();
            sut.RunTestingConstructor(mock);

            sut.SetDirection();
            var result = sut.Speed;

            Assert.That(result, Is.Positive);
        }
    }
}
