using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    [TestFixture]
    public class NullCheckerTests
    {
        [Test]
        public void TryGet_NullComponent_ReturnsComponentOfGenericType()
        {
            var result = NullChecker.TryGet<Rigidbody>(null);

            Assert.That(result, Is.TypeOf<Rigidbody>());
        }

        [Test]
        public void TryGet_Component_ReturnsComponent()
        {
            var component = new GameObject().AddComponent<Rigidbody>();

            var result = NullChecker.TryGet(component);

            Assert.That(result, Is.TypeOf<Rigidbody>());
        }

        [Test]
        public void TryGet_NullArguments_ReturnsComponentOfGenericType()
        {
            var result = NullChecker.TryGet<Rigidbody>(null, null);

            Assert.That(result, Is.TypeOf<Rigidbody>());
        }

        [Test]
        public void TryGet_NullGameObject_ReturnsComponentOfGenericType()
        {
            var component = new GameObject().GetComponent<Rigidbody>();

            var result = NullChecker.TryGet<Rigidbody>(null, component);

            Assert.That(result, Is.TypeOf<Rigidbody>());
        }

        [Test]
        public void TryGet_NullComponentGameObejct_ReturnsComponentOfGenericType()
        {
            var result = NullChecker.TryGet<Rigidbody>(new GameObject(), null);

            Assert.That(result, Is.TypeOf<Rigidbody>());
        }

        [Test]
        public void TryGet_GameObjectAndComponent_ReturnsComponent()
        {
            var gameObject = new GameObject();

            var result = NullChecker
                .TryGet<Rigidbody>(gameObject, gameObject.GetComponent<Rigidbody>());

            Assert.That(result, Is.TypeOf<Rigidbody>());
        }
    }
}
