using NUnit.Framework;
using UnityEngine;

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
        public void IsRunnning_DefaultValue_IsTrue()
        {
            var sut = CreateDefaultGameController();

            var result = sut.IsRunning;

            Assert.That(result, Is.True);
        }

        [Test]
        public void Stop_SetsIsRunnningToFalse()
        {
            var sut = CreateDefaultGameController();
            
            sut.Stop();
            var result = sut.IsRunning;

            Assert.That(result, Is.False);
        }
    }
}
