using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class NullComponentCheckerTests
    {
        [Test]
        public void TryGet_NullArguments_ReturnsNull()
        {
            var result = NullChecker.TryGet<Rigidbody>(null, null);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void TryGet_NullGameObject_ReturnsNull()
        {
            var result = NullChecker
                .TryGet<Rigidbody>(null, new GameObject().GetComponent<Rigidbody>());

            Assert.That(result, Is.Null);
        }

        [Test]
        public void TryGet_NullComponent_AddsComponentTypeToGameObject()
        {
            var result = NullChecker
                .TryGet<Rigidbody>(new GameObject(), null);

            Assert.That(result, Is.InstanceOf<Component>().And.TypeOf<Rigidbody>());
        }

        [Test]
        public void TryGet_Component_ReturnsComponent()
        {
            var gameObject = new GameObject();

            var result = NullChecker
                .TryGet<Rigidbody>(gameObject, gameObject.GetComponent<Rigidbody>());

            Assert.That(result, Is.InstanceOf<Component>().And.TypeOf<Rigidbody>());
        }
    }
}
