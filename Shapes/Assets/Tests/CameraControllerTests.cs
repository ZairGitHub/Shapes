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

            var result = sut.transform.position;

            Assert.That(result, Is.EqualTo(new Vector3(0.0f, 0.0f, -10.0f)));
        }
    }
}
