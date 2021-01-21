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
            sut.runInEditMode = true;
            sut.RunTestingConstructor(Vector3.back);

            var result = sut.transform.position;

            Assert.That(result, Is.EqualTo(Vector3.back));
        }
    }
}
