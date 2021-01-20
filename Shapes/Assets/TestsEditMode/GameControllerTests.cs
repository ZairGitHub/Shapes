using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    [TestFixture]
    public class GameControllerTests
    {
        private GameController CreateDefaultGameController()
        {
            return new GameObject().AddComponent<GameController>();
        }

        [Test]
        public void IsInDebugMode_DefaultValue_IsFalse()
        {
            var sut = CreateDefaultGameController();

            var result = sut.IsInDebugMode;

            Assert.That(result, Is.False);
        }

        [Test]
        public void IsRunnning_DefaultValue_IsFalse()
        {
            var sut = CreateDefaultGameController();

            var result = sut.IsRunning;

            Assert.That(result, Is.False);
        }

        [UnityTest]
        public IEnumerator Start_SetsIsRunningToTrue()
        {
            var sut = CreateDefaultGameController();
            sut.runInEditMode = true;
            yield return null;

            var result = sut.IsRunning;

            Assert.That(result, Is.True);
        }

        [Test]
        public void StopRunning_SetsIsRunnningToFalse()
        {
            var sut = CreateDefaultGameController();
            
            sut.StopRunning();
            var result = sut.IsRunning;

            Assert.That(result, Is.False);
        }
    }
}
