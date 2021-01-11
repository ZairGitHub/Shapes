using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class GameControllerTests
    {
        private GameController CreateGameController()
        {
            return new GameObject().AddComponent<GameController>();
        }

        [Test]
        public void IsInDebugMode_DefaultValue_IsFalse()
        {
            var sut = CreateGameController();

            var result = sut.IsInDebugMode;

            Assert.That(result, Is.False);
        }

        [Test]
        public void IsRunnning_DefaultValue_IsTrue()
        {
            var sut = CreateGameController();

            var result = sut.IsRunning;

            Assert.That(result, Is.True);
        }

        [Test]
        public void Stop_SetsIsRunnningToFalse()
        {
            var sut = CreateGameController();
            
            sut.Stop();
            var result = sut.IsRunning;

            Assert.That(result, Is.False);
        }
    }
}
