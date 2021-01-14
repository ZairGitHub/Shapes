using NSubstitute;
using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class PlayerSpawnerTests
    {
        private PlayerSpawner CreateDefaultPlayerSpawner()
        {
            return new PlayerSpawner(Substitute.For<IConstants>());
        }

        private PlayerSpawner CreateDefaultPlayerSpawnerWithMock()
        {
            var mock = Substitute.For<IConstants>();
            mock.BoundaryHeight.Returns(2.0f);
            mock.BoundaryWidth.Returns(2.0f);

            return new PlayerSpawner(mock);
        }

        private Rigidbody CreateDefaultRigidbody()
        {
            return new GameObject().AddComponent<Rigidbody>();
        }

        [TestCase(0)]
        [TestCase(5)]
        public void SetSpawnPosition_PlayerIDIsOutsideOfRange_DoesNotMovePosition(int playerID)
        {
            var rigidbody = CreateDefaultRigidbody();
            var sut = CreateDefaultPlayerSpawner();

            sut.SetSpawnPosition(rigidbody, playerID);
            var result = rigidbody.position;

            Assert.That(result, Is.EqualTo(Vector3.zero));
        }

        [Test]
        public void SetSpawnPosition_Player1_MovesPositionToTopLeftArea()
        {
            var rigidbody = CreateDefaultRigidbody();
            var sut = CreateDefaultPlayerSpawnerWithMock();

            sut.SetSpawnPosition(rigidbody, 1);
            var result = rigidbody.position;

            Assert.That(result, Is.EqualTo(new Vector3(-1.0f, 1.0f, 0.0f)));
        }

        [Test]
        public void SetSpawnPosition_Player2_MovesPositionToTopRightArea()
        {
            var rigidbody = CreateDefaultRigidbody();
            var sut = CreateDefaultPlayerSpawnerWithMock();

            sut.SetSpawnPosition(rigidbody, 2);
            var result = rigidbody.position;
            
            Assert.That(result, Is.EqualTo(new Vector3(1.0f, 1.0f, 0.0f)));
        }

        [Test]
        public void SetSpawnPosition_Player3_MovesPositionToBottomLeftArea()
        {
            var rigidbody = CreateDefaultRigidbody();
            var sut = CreateDefaultPlayerSpawnerWithMock();

            sut.SetSpawnPosition(rigidbody, 3);
            var result = rigidbody.position;

            Assert.That(result, Is.EqualTo(new Vector3(-1.0f, -1.0f, 0.0f)));
        }

        [Test]
        public void SetSpawnPosition_Player4_MovesPositionToBottomRightArea()
        {
            var rigidbody = CreateDefaultRigidbody();
            var sut = CreateDefaultPlayerSpawnerWithMock();

            sut.SetSpawnPosition(rigidbody, 4);
            var result = rigidbody.position;

            Assert.That(result, Is.EqualTo(new Vector3(1.0f, -1.0f, 0.0f)));
        }

        [Test]
        public void SetSpawnPosition_SetsRigidbodyVelocityToVector3Zero()
        {
            var rigidbody = CreateDefaultRigidbody();
            var sut = CreateDefaultPlayerSpawner();

            sut.SetSpawnPosition(rigidbody);
            var result = rigidbody.velocity;

            Assert.That(result, Is.EqualTo(Vector3.zero));
        }
    }
}
