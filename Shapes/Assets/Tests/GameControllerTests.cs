using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class GameControllerTests
    {
        [UnityTest]
        public IEnumerable IsRunnningProperty_HasDefaultValueOfTrue()
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
