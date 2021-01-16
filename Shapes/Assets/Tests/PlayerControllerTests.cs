using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayerControllerTests
    {
        private PlayerController CreateDefaultPlayerController()
        {
            return new GameObject().AddComponent<PlayerController>();
        }

        private GameObject CreatePlayerControllerWithComponentAndRunInEditMode<T>() where T : Component
        {
            var gameObject = new GameObject();
            gameObject.AddComponent<T>();
            gameObject.AddComponent<PlayerController>().runInEditMode = true;
            return gameObject;
        }

        [Test]
        public void Awake_AssignsRigidbodyComponent()
        {
            var sut = CreateDefaultPlayerController();
            sut.runInEditMode = true;

            var result = sut.GetComponents<Rigidbody>();

            Assert.That(result, Has.Exactly(1).TypeOf<Rigidbody>());
        }

        [UnityTest]
        public IEnumerator Start_AssignsConstantsComponent()
        {
            var sut = CreateDefaultPlayerController();
            sut.runInEditMode = true;
            yield return null;

            var result = sut.GetComponents<Constants>();

            Assert.That(result, Has.Exactly(1).TypeOf<Constants>());
        }

        [UnityTest]
        public IEnumerator Start_AssignsGameControllerComponent()
        {
            var sut = CreateDefaultPlayerController();
            sut.runInEditMode = true;
            yield return null;

            var result = sut.GetComponents<GameController>();

            Assert.That(result, Has.Exactly(1).TypeOf<GameController>());
        }
    }
}
