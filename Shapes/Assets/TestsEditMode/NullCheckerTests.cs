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
        public void NullComponent_GameObject_ReturnsComponent()
        {
            var result = NullChecker.TryGet<Rigidbody>(_gameObject);

            Assert.That(result, Is.TypeOf<Rigidbody>());
        }
    }
}
