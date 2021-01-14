using NSubstitute;
using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class PlayerSpawnerTests
    {
        private const int _minPlayerID = 0;
        private const int _maxPlayerID = 4;

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

        [TestCase(_minPlayerID - 1)]
        [TestCase(_maxPlayerID + 1)]
        public void SetSpawnPosition_PlayerIDIsOutsideValidRange_DoesNotMovePosition(int playerID)
        {
            var rigidbody = CreateDefaultRigidbody();
            var sut = CreateDefaultPlayerSpawnerWithMock();

            sut.SetSpawnPosition(rigidbody, playerID);
            var result = rigidbody.position;

            Assert.That(result, Is.EqualTo(Vector3.zero));
        }

        [Test]
        public void SetSpawnPosition_PlayerIDIsInsideValidRange_MovesPosition(
            [NUnit.Framework.Range(_minPlayerID, _maxPlayerID)] int playerID)
        {
            var rigidbody = CreateDefaultRigidbody();
            var sut = CreateDefaultPlayerSpawnerWithMock();

            sut.SetSpawnPosition(rigidbody, playerID);
            var result = rigidbody.position;

            Assert.That(result, Is.Not.EqualTo(Vector3.zero));
        }

        [Test]
        public void SetSpawnPosition_PlayerIDIs1_MovesPositionToTopLeftArea()
        {
            var rigidbody = CreateDefaultRigidbody();
            var sut = CreateDefaultPlayerSpawnerWithMock();

            sut.SetSpawnPosition(rigidbody, 1);
            var result = rigidbody.position;

            Assert.That(result, Is.EqualTo(new Vector3(-1.0f, 1.0f, 0.0f)));
        }

        [Test]
        public void SetSpawnPosition_PlayerIDIs2_MovesPositionToTopRightArea()
        {
            var rigidbody = CreateDefaultRigidbody();
            var sut = CreateDefaultPlayerSpawnerWithMock();

            sut.SetSpawnPosition(rigidbody, 2);
            var result = rigidbody.position;
            
            Assert.That(result, Is.EqualTo(new Vector3(1.0f, 1.0f, 0.0f)));
        }

        [Test]
        public void SetSpawnPosition_PlayerIDIs3_MovesPositionToBottomLeftArea()
        {
            var rigidbody = CreateDefaultRigidbody();
            var sut = CreateDefaultPlayerSpawnerWithMock();

            sut.SetSpawnPosition(rigidbody, 3);
            var result = rigidbody.position;

            Assert.That(result, Is.EqualTo(new Vector3(-1.0f, -1.0f, 0.0f)));
        }

        [Test]
        public void SetSpawnPosition_PlayerIDIs4_MovesPositionToBottomRightArea()
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
            var sut = new PlayerSpawner(Substitute.For<IConstants>());

            sut.SetSpawnPosition(rigidbody);
            var result = rigidbody.velocity;

            Assert.That(result, Is.EqualTo(Vector3.zero));
        }
    }
}
