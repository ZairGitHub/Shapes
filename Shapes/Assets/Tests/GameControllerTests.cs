using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class GameControllerTests
    {
        [UnityTest]
        public IEnumerable IsInDebugMode_DefaultValue_IsFalse()
        {
            var sut = new GameObject().AddComponent<GameController>();
            yield return null;

            var result = sut.IsInDebugMode;

            Assert.That(result, Is.False);
        }

        [UnityTest]
        public IEnumerable IsRunnning_DefaultValue_IsTrue()
        {
            var sut = new GameObject().AddComponent<GameController>();
            yield return null;

            var result = sut.IsRunning;

            Assert.That(result, Is.True);
        }

        [Test]
        public void Reset_SetsIsRunnningToFalse()
        {
            var sut = new GameObject().AddComponent<GameController>();
            
            sut.Reset();
            var result = sut.IsRunning;

            Assert.That(result, Is.False);
        }
    }
}
