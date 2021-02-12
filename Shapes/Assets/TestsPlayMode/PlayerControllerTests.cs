using System.Collections;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    [TestFixture]
    public class PlayerControllerTests
    {
        private const float _modifer = 10.0f;
        // Breaks when running all at once with lower values
        private const float _speed = 1.0f * _modifer;

        private readonly WaitForFixedUpdate _fixedUpdateDelay = new WaitForFixedUpdate();

        private PlayerController CreateDefaultPlayerController()
        {
            return new GameObject().AddComponent<PlayerController>();
        }

        [UnityTest]
        public IEnumerator FixedUpdate_NegativeHorizontalAxis_SetsRigidbodyVelocityToVector3Left()
        {
            var mock = Substitute.For<IGetAxisService>();
            mock.GetAxis(UnityInput.Horizontal).Returns(-1.0f);
            var sut = CreateDefaultPlayerController();
            yield return null;
            sut.RunTestingConstructor(mock, _speed);
            yield return _fixedUpdateDelay;

            var result = sut.GetComponent<Rigidbody>().velocity;

            Assert.That(result, Is.EqualTo(Vector3.left * _modifer));
        }

        [UnityTest]
        public IEnumerator FixedUpdate_PositiveHorizontalAxis_SetsRigidbodyVelocityToVector3Right()
        {
            var mock = Substitute.For<IGetAxisService>();
            mock.GetAxis(UnityInput.Horizontal).Returns(1.0f);
            var sut = CreateDefaultPlayerController();
            yield return null;
            sut.RunTestingConstructor(mock, _speed);
            yield return _fixedUpdateDelay;

            var result = sut.GetComponent<Rigidbody>().velocity;

            Assert.That(result, Is.EqualTo(Vector3.right * _modifer));
        }

        [UnityTest]
        public IEnumerator FixedUpdate_NegativeVerticalAxis_SetsRigidbodyVelocityToVector3Down()
        {
            var mock = Substitute.For<IGetAxisService>();
            mock.GetAxis(UnityInput.Vertical).Returns(-1.0f);
            var sut = CreateDefaultPlayerController();
            yield return null;
            sut.RunTestingConstructor(mock, _speed);
            yield return _fixedUpdateDelay;

            var result = sut.GetComponent<Rigidbody>().velocity;

            Assert.That(result, Is.EqualTo(Vector3.down * _modifer));
        }

        [UnityTest]
        public IEnumerator FixedUpdate_NegativeVerticalAxis_SetsRigidbodyVelocityToVector3Up()
        {
            var mock = Substitute.For<IGetAxisService>();
            mock.GetAxis(UnityInput.Vertical).Returns(1.0f);
            var sut = CreateDefaultPlayerController();
            yield return null;
            sut.RunTestingConstructor(mock, _speed);
            yield return _fixedUpdateDelay;

            var result = sut.GetComponent<Rigidbody>().velocity;

            Assert.That(result, Is.EqualTo(Vector3.up * _modifer));
        }
    }
}
