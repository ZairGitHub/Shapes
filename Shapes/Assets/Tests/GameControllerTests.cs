using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class GameControllerTests
    {
        [Test]
        public void IsInDebugMode_DefaultValue_IsFalse()
        {
            var sut = new GameObject().AddComponent<GameController>();

            var result = sut.IsInDebugMode;

            Assert.That(result, Is.False);
        }

        [Test]
        public void IsRunnning_DefaultValue_IsTrue()
        {
            var sut = new GameObject().AddComponent<GameController>();

            var result = sut.IsRunning;

            Assert.That(result, Is.True);
        }

        [Test]
        public void Stop_SetsIsRunnningToFalse()
        {
            var sut = new GameObject().AddComponent<GameController>();
            
            sut.Stop();
            var result = sut.IsRunning;

            Assert.That(result, Is.False);
        }
    }
}
