using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class ConstantsTests
    {
        [Test]
        public void Awake_SetsBoundaryWidthToCorrectValue()
        {
            var sut = new GameObject().AddComponent<Constants>();
            sut.runInEditMode = true;

            var result = sut.BoundaryWidth;

            Assert.That(result, Is.EqualTo(20.0f));
        }

        [Test]
        public void Awake_SetsBoundaryHeightToCorrectValue()
        {
            var sut = new GameObject().AddComponent<Constants>();
            sut.runInEditMode = true;

            var result = sut.BoundaryHeight;

            Assert.That(result, Is.EqualTo(10.0f));
        }
    }
}
