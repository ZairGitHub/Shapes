using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    [TestFixture]
    public class NullCheckerTests
    {
        private readonly GameObject _gameObject = new GameObject();

        [Test]
        public void TryGet_NullGameObject_ReturnsNull()
        {
            var result = NullChecker.TryGet<Rigidbody>(null);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void TryGet_GameObject_ReturnsComponent()
        {
            var result = NullChecker.TryGet<Rigidbody>(_gameObject);

            Assert.That(result, Is.TypeOf<Rigidbody>());
        }

        [Test]
        public void TryFind_OneArgument_AlwaysReturnsComponent()
        {
            var result = (IGameController)NullChecker
                .TryFind<GameController>(null);

            Assert.That(result, Is.TypeOf<GameController>());
        }

        [Test]
        public void TryFind_TwoArguments_AlwaysReturnsComponent()
        {
            var result = (IGameController)NullChecker
                .TryFind<GameController>(null, null);

            Assert.That(result, Is.TypeOf<GameController>());
        }
    }
}
