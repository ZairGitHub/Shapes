using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    // Test class to be revisited
    public class NullCheckerTests
    {
        [Test]
        public void TryGet_NullArgument_ReturnsComponent()
        {
            var result = NullChecker.TryGet<Rigidbody>(null);

            Assert.That(result, Is.TypeOf<Rigidbody>());
        }

        [Test]
        public void TryGet_NullArguments_ReturnsComponent()
        {
            var result = NullChecker.TryGet<Rigidbody>(null, null);

            Assert.That(result, Is.TypeOf<Rigidbody>());
        }

        [Test]
        public void TryGet_NullGameObject_ReturnsComponent()
        {
            var result = NullChecker.TryGet<Rigidbody>
                (null, new GameObject().AddComponent<Rigidbody>());

            Assert.That(result, Is.TypeOf<Rigidbody>());
        }

        [Test]
        public void TryGet_NullComponent_ReturnsComponent()
        {
            var result = NullChecker.TryGet<Rigidbody>(new GameObject(), null);

            Assert.That(result, Is.TypeOf<Rigidbody>());
        }

        [Test]
        public void TryGet_GameObjectAndComponent_ReturnsComponent()
        {
            var result = NullChecker.TryGet<Rigidbody>(
                new GameObject(), new GameObject().AddComponent<Rigidbody>());

            Assert.That(result, Is.TypeOf<Rigidbody>());
        }
    }
}
