using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayerSpawnerTests
    {
        private Constants CreateDefaultConstants()
        {
            return new GameObject().AddComponent<Constants>();
        }


        [Test]
        public void SetSpawnPosition_PlayerIDIsOutsideOfRange_DoesNotMovePosition()
        {
            var constants = CreateDefaultConstants();
            constants.runInEditMode = true;
            var sut = new PlayerSpawner(constants);

            var rigidbody = new GameObject().AddComponent<Rigidbody>();
            sut.SetSpawnPosition(rigidbody, -1);

            Assert.That(rigidbody.position, Is.EqualTo(Vector3.zero));
        }

        [Test]
        public void SetSpawnPosition_Player1_MovesPositionToTopLeftArea()
        {
            var constants = CreateDefaultConstants();
            constants.runInEditMode = true;
            var sut = new PlayerSpawner(constants);
            
            var rigidbody = new GameObject().AddComponent<Rigidbody>();
            sut.SetSpawnPosition(rigidbody, 1);

            Assert.That(rigidbody.position, Is.EqualTo(new Vector3(-10f, 5f, 0f)));
        }

        [Test]
        public void SetSpawnPosition_Player2_MovesPositionToTopRightArea()
        {
            var constants = CreateDefaultConstants();
            constants.runInEditMode = true;
            var sut = new PlayerSpawner(constants);

            var rigidbody = new GameObject().AddComponent<Rigidbody>();
            sut.SetSpawnPosition(rigidbody, 2);

            Assert.That(rigidbody.position, Is.EqualTo(new Vector3(10f, 5f, 0f)));
        }

        [Test]
        public void SetSpawnPosition_Player3_MovesPositionToBottomLeftArea()
        {
            var constants = CreateDefaultConstants();
            constants.runInEditMode = true;
            var sut = new PlayerSpawner(constants);

            var rigidbody = new GameObject().AddComponent<Rigidbody>();
            sut.SetSpawnPosition(rigidbody, 3);

            Assert.That(rigidbody.position, Is.EqualTo(new Vector3(-10f, -5f, 0f)));
        }

        [Test]
        public void SetSpawnPosition_Player4_MovesPositionToBottomRightArea()
        {
            var constants = CreateDefaultConstants();
            constants.runInEditMode = true;
            var sut = new PlayerSpawner(constants);

            var rigidbody = new GameObject().AddComponent<Rigidbody>();
            sut.SetSpawnPosition(rigidbody, 4);

            Assert.That(rigidbody.position, Is.EqualTo(new Vector3(10f, -5f, 0f)));
        }
    }
}
