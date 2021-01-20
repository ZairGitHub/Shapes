using System.Collections;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayerMovementTests
    {
        private const float _speed = 1.0f;

        private readonly WaitForFixedUpdate _fixedUpdateDelay = new WaitForFixedUpdate();

        [UnityTest]
        public IEnumerator FixedUpdate_NegativeHorizontalAxis_ReturnsLeftVector3()
        {
            var mock = Substitute.For<IUnityService>();
            mock.GetAxis("Horizontal").Returns(-1.0f);
            var sut = new GameObject().AddComponent<PlayerController>();
            yield return null;
            sut.RunTestingConstructor(mock, _speed);
            yield return _fixedUpdateDelay;

            var result = sut.GetComponent<Rigidbody>().velocity;

            Assert.That(result, Is.EqualTo(Vector3.left));
        }
    }
}
