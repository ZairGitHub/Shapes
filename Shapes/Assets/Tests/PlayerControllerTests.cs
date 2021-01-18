using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class PlayerControllerTests
    {
        private PlayerController CreateDefaultPlayerController()
        {
            return new GameObject().AddComponent<PlayerController>();
        }

        [Test]
        public void Awake_AssignsRigidbodyComponent()
        {
            var sut = CreateDefaultPlayerController();
            sut.runInEditMode = true;

            var result = sut.GetComponents<Rigidbody>();

            Assert.That(result, Has.Exactly(1).TypeOf<Rigidbody>());
        }
    }
}
