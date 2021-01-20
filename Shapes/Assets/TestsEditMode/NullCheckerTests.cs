using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    [TestFixture]
    public class NullCheckerTests
    {
        private readonly GameObject _gameObject = new GameObject();
        private readonly Component _component = new GameObject().AddComponent<Rigidbody>();

        [Test]
        public void TryGet_NullGameObject_ReturnsNull()
        {
            var result = NullChecker.TryGet<Rigidbody>(null, _component);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void NullComponent_ReturnsComponent()
        {
            var result = NullChecker.TryGet<Rigidbody>(_gameObject, null);

            Assert.That(result, Is.TypeOf<Rigidbody>());
        }

        [Test]
        public void TryGet_GameObjectAndComponent_ReturnsComponent()
        {
            var result = NullChecker.TryGet<Rigidbody>(_gameObject, _component);

            Assert.That(result, Is.TypeOf<Rigidbody>());
        }
    }
}
