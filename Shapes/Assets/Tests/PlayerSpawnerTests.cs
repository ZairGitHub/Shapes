using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayerSpawnerTests
    {
        [Test]
        public void PlayerSpawnerTestsSimplePasses()
        {
            var c = GameObject.FindGameObjectWithTag("Constants").GetComponent<Constants>();
            c.runInEditMode = true;
            var sut = new PlayerSpawner(c);

            var rb = new GameObject().AddComponent<Rigidbody>();
            sut.SetSpawnPosition(rb, 1);

            Assert.That(rb.position, Is.EqualTo(new Vector3(-10f, 5f, 0f)));
        }
    }
}
