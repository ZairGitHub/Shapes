using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class ConstantsTests
    {
        [UnityTest]
        public IEnumerable Awake_SetsBoundaryWidthToCorrectValue()
        {
            var sut = new GameObject().AddComponent<Constants>();
            yield return null;

            var result = sut.BoundaryWidth;

            Assert.That(result, Is.EqualTo(20.0f));
        }

        [UnityTest]
        public IEnumerable Awake_SetsBoundaryHeightToCorrectValue()
        {
            var sut = new GameObject().AddComponent<Constants>();
            yield return null;

            var result = sut.BoundaryHeight;

            Assert.That(result, Is.EqualTo(10.0f));
        }
    }
}
