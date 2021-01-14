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

        private Rigidbody CreateDefaultRigidbody()
        {
            return new GameObject().AddComponent<Rigidbody>();
        }

        [Test]
        public void SetSpawnPosition_SetsRigidbodyVelocityToVector3Zero()
        {
            var constants = CreateDefaultConstants();
            constants.runInEditMode = true;
            var rigidbody = CreateDefaultRigidbody();
            var sut = new PlayerSpawner(constants);

            sut.SetSpawnPosition(rigidbody);
            var result = rigidbody.velocity;

            Assert.That(result, Is.EqualTo(Vector3.zero));
        }

        [Test]
        public void SetSpawnPosition_PlayerIDIsOutsideOfRange_DoesNotMovePosition()
        {
            var constants = CreateDefaultConstants();
            constants.runInEditMode = true;
            var rigidbody = CreateDefaultRigidbody();
            var sut = new PlayerSpawner(constants);

            sut.SetSpawnPosition(rigidbody, -1);
            var result = rigidbody.position;

            Assert.That(result, Is.EqualTo(Vector3.zero));
        }

        [Test]
        public void SetSpawnPosition_Player1_MovesPositionToTopLeftArea()
        {
            var constants = CreateDefaultConstants();
            constants.runInEditMode = true;
            var rigidbody = CreateDefaultRigidbody();
            var sut = new PlayerSpawner(constants);

            sut.SetSpawnPosition(rigidbody, 1);
            var result = rigidbody.position;

            Assert.That(result, Is.EqualTo(new Vector3(-10f, 5f, 0f)));
        }

        [Test]
        public void SetSpawnPosition_Player2_MovesPositionToTopRightArea()
        {
            var constants = CreateDefaultConstants();
            constants.runInEditMode = true;
            var rigidbody = CreateDefaultRigidbody();
            var sut = new PlayerSpawner(constants);

            sut.SetSpawnPosition(rigidbody, 2);
            var result = rigidbody.position;

            Assert.That(result, Is.EqualTo(new Vector3(10f, 5f, 0f)));
        }

        [Test]
        public void SetSpawnPosition_Player3_MovesPositionToBottomLeftArea()
        {
            var constants = CreateDefaultConstants();
            constants.runInEditMode = true;
            var rigidbody = CreateDefaultRigidbody();
            var sut = new PlayerSpawner(constants);

            sut.SetSpawnPosition(rigidbody, 3);
            var result = rigidbody.position;

            Assert.That(result, Is.EqualTo(new Vector3(-10f, -5f, 0f)));
        }

        [Test]
        public void SetSpawnPosition_Player4_MovesPositionToBottomRightArea()
        {
            var constants = CreateDefaultConstants();
            constants.runInEditMode = true;
            var rigidbody = CreateDefaultRigidbody();
            var sut = new PlayerSpawner(constants);

            sut.SetSpawnPosition(rigidbody, 4);
            var result = rigidbody.position;

            Assert.That(result, Is.EqualTo(new Vector3(10f, -5f, 0f)));
        }
    }
}
