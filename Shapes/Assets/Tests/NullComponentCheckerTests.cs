using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class NullComponentCheckerTests
    {
        [Test]
        public void GetType_NullArguments_ReturnsNull()
        {
            var result = NullComponentChecker.TryGet<Rigidbody>(null, null);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void GetType_NullGameObject_ReturnsNull()
        {
            var result = NullComponentChecker
                .TryGet<Rigidbody>(null, new GameObject().GetComponent<Rigidbody>());

            Assert.That(result, Is.Null);
        }

        [Test]
        public void GetType_NullComponent_AddsComponentTypeToGameObject()
        {
            var result = NullComponentChecker
                .TryGet<Rigidbody>(new GameObject(), null);

            Assert.That(result, Is.InstanceOf<Component>().And.TypeOf<Rigidbody>());
        }

        [Test]
        public void GetType_Component_ReturnsComponent()
        {
            var gameObject = new GameObject();

            var result = NullComponentChecker
                .TryGet<Rigidbody>(gameObject, gameObject.GetComponent<Rigidbody>());

            Assert.That(result, Is.InstanceOf<Component>().And.TypeOf<Rigidbody>());
        }
    }
}
