using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class CubeHandlerTests
    {
        [Test]
        public void HasSpeed_SpeedIsNotPositive_ReturnsFalse()
        {
            var sut = new GameObject().AddComponent<CubeHandler>();
            sut.runInEditMode = true;
            sut.RunTestingConstructor(0.0f);

            var result = sut.HasSpeed();

            Assert.That(result, Is.False);
        }
    }
}
