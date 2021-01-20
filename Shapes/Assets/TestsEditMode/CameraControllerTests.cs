using NSubstitute;
using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    [TestFixture]
    public class CameraControllerTests
    {
        [Test]
        public void Awake_SetsTransformPositionToCorrectVector3()
        {
            var sut = new GameObject().AddComponent<CameraController>();
            sut.RunTestingConstructor(Arg.Any<Vector3>());

            var result = sut.transform.position;

            Assert.That(result, Is.EqualTo(Arg.Any<Vector3>()));
        }
    }
}
