using System.Collections;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayerControllerTests
    {
        private const float _speed = 1.0f;

        private readonly WaitForFixedUpdate _fixedUpdateDelay = new WaitForFixedUpdate();

        private PlayerController CreateDefaultPlayerController()
        {
            return new GameObject().AddComponent<PlayerController>();
        }

        [UnityTest]
        public IEnumerator FixedUpdate_NegativeHorizontalAxis_ReturnsVector3Left()
        {
            var mock = Substitute.For<IGetAxisService>();
            mock.GetAxis("Horizontal").Returns(-1.0f);
            var sut = CreateDefaultPlayerController();
            yield return null;
            sut.RunTestingConstructor(mock, _speed);
            yield return _fixedUpdateDelay;

            var result = sut.GetComponent<Rigidbody>().velocity;

            Assert.That(result, Is.EqualTo(Vector3.left));
        }

        [UnityTest]
        public IEnumerator FixedUpdate_PositiveHorizontalAxis_ReturnsVector3Right()
        {
            var mock = Substitute.For<IGetAxisService>();
            mock.GetAxis("Horizontal").Returns(1.0f);
            var sut = CreateDefaultPlayerController();
            yield return null;
            sut.RunTestingConstructor(mock, _speed);
            yield return _fixedUpdateDelay;

            var result = sut.GetComponent<Rigidbody>().velocity;

            Assert.That(result, Is.EqualTo(Vector3.right));
        }

        [UnityTest]
        public IEnumerator FixedUpdate_NegativeVerticalAxis_ReturnsVector3Down()
        {
            var mock = Substitute.For<IGetAxisService>();
            mock.GetAxis("Vertical").Returns(-1.0f);
            var sut = CreateDefaultPlayerController();
            yield return null;
            sut.RunTestingConstructor(mock, _speed);
            yield return _fixedUpdateDelay;

            var result = sut.GetComponent<Rigidbody>().velocity;

            Assert.That(result, Is.EqualTo(Vector3.down));
        }

        [UnityTest]
        public IEnumerator FixedUpdate_NegativeVerticalAxis_ReturnsVector3Up()
        {
            var mock = Substitute.For<IGetAxisService>();
            mock.GetAxis("Vertical").Returns(1.0f);
            var sut = CreateDefaultPlayerController();
            yield return null;
            sut.RunTestingConstructor(mock, _speed);
            yield return _fixedUpdateDelay;

            var result = sut.GetComponent<Rigidbody>().velocity;

            Assert.That(result, Is.EqualTo(Vector3.up));
        }
    }
}
