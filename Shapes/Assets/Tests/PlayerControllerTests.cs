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
        public void Awake_HasNoRigidbodyComponent_AssignsNewRigidbodyComponent()
        {
            var sut = new GameObject().AddComponent<PlayerController>();
            sut.runInEditMode = true;

            var result = sut.GetComponent<Rigidbody>();

            Assert.That(result, Is.Not.Null.And.TypeOf<Rigidbody>());
        }

        [Test]
        public void Awake_HasARigidbodyComponent_AssignsExistingRigidbodyComponent()
        {
            var sut = new GameObject();
            sut.AddComponent<Rigidbody>();
            sut.AddComponent<PlayerController>().runInEditMode = true;

            var result = sut.GetComponent<Rigidbody>();

            Assert.That(result, Is.Not.Null.And.TypeOf<Rigidbody>());
        }
    }
}
