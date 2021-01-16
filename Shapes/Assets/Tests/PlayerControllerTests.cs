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
        public void Awake_HasNoRigidbodyComponent_AssignsNewRigidbodyComponent()
        {
            var sut = CreateDefaultPlayerController();
            sut.runInEditMode = true;

            var result = sut.GetComponent<Rigidbody>();

            Assert.That(result, Is.TypeOf<Rigidbody>());
        }

        [Test]
        public void Awake_HasARigidbodyComponent_AssignsExistingRigidbodyComponent()
        {
            var sut = new GameObject();
            sut.AddComponent<Rigidbody>();
            sut.AddComponent<PlayerController>().runInEditMode = true;

            var result = sut.GetComponent<Rigidbody>();

            Assert.That(result, Is.TypeOf<Rigidbody>());
        }

        [UnityTest]
        public IEnumerator Start_HasNoConstantsComponent_AssignsNewConstantsComponent()
        {
            var sut = CreateDefaultPlayerController();
            sut.runInEditMode = true;
            yield return null;

            var result = sut.GetComponent<Constants>();

            Assert.That(result, Is.TypeOf<Constants>());
        }

        [UnityTest]
        public IEnumerator Start_HasAConstantsComponent_AssignsExistingConstantsComponent()
        {
            var sut = CreatePlayerControllerWithComponentAndRunInEditMode<Constants>();
            yield return null;

            var result = sut.GetComponent<Constants>();

            Assert.That(result, Is.TypeOf<Constants>());
        }

        [UnityTest]
        public IEnumerator Start_HasNoGameControllerComponent_AssignsNewGameControllerComponent()
        {
            var sut = CreateDefaultPlayerController();
            sut.runInEditMode = true;
            yield return null;

            var result = sut.GetComponent<GameController>();

            Assert.That(result, Is.TypeOf<GameController>());
        }

        [UnityTest]
        public IEnumerator Start_HasAGameControllerComponent_AssignsExistingGameControllerComponent()
        {
            var sut = new GameObject();
            sut.AddComponent<Constants>();
            sut.AddComponent<PlayerController>().runInEditMode = true;
            yield return null;

            var result = sut.GetComponent<GameController>();

            Assert.That(result, Is.TypeOf<GameController>());
        }
    }
}
