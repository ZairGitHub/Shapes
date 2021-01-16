using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayerControllerTests
    {
        [Test]
        public void PlayerControllerTestsSimplePasses()
        {
            var sut = new GameObject().AddComponent<PlayerController>();
            sut.runInEditMode = true;

            var result = sut.GetComponent<Rigidbody>();

            Assert.That(result, Is.Null);
        }
    }
}
