using System.Collections;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class NullComponentCheckerTests
    {
        [Test]
        public void GetType_Nulls_Null()
        {
            var result = (Component)NullComponentChecker
                .TryGet<Transform>(null, null);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void GetType_NoGameObject_Null()
        {
            var result = (Component)NullComponentChecker
                .TryGet<Transform>(null, Arg.Any<Component>());

            Assert.That(result, Is.Null);
        }

        [Test]
        public void GetType_NoComponent_Null()
        {
            var result = (Component)NullComponentChecker
                .TryGet<Component>(new GameObject(), null);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void GetType_Component_Component()
        {
            var sut = new GameObject();

            var result = NullComponentChecker
                .TryGet<Rigidbody>(sut, sut.GetComponent<Rigidbody>());

            Assert.That(result, Is.InstanceOf<Component>().And.TypeOf<Rigidbody>());
        }
    }
}
