using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class CameraControllerTests
    {
        [Test]
        public void CameraControllerTestsSimplePasses()
        {
            var sut = new GameObject().AddComponent<CameraController>();
            sut.runInEditMode = true;

            var result = sut.transform.position;

            Assert.That(result, Is.EqualTo(new Vector3(0.0f, 0.0f, -10.0f)));
        }
    }
}
