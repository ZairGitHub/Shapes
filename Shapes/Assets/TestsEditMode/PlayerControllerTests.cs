using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    [TestFixture]
    public class PlayerControllerTests
    {
        [Test]
        public void Awake_AssignsRigidbodyComponent()
        {
            var sut = new GameObject().AddComponent<PlayerController>();
            sut.runInEditMode = true;

            var result = sut.GetComponents<Rigidbody>();

            Assert.That(result, Has.Exactly(1).TypeOf<Rigidbody>());
        }
    }
}
