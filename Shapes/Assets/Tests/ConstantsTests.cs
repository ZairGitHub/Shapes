using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class ConstantsTests
    {
        private float GetBoundaryEastX()
        {
            return GameObject.FindGameObjectWithTag("BoundaryEast")
                .transform.position.x;
        }

        private float GetBoundaryNorthY()
        {
            return GameObject.FindGameObjectWithTag("BoundaryNorth")
                .transform.position.y;
        }

        [Test]
        public void Awake_SetsBoundaryWidthToCorrectValue()
        {
            var sut = new GameObject().AddComponent<Constants>();
            sut.runInEditMode = true;

            var result = sut.BoundaryWidth;

            Assert.That(result, Is.EqualTo(GetBoundaryEastX()));
        }

        [Test]
        public void Awake_SetsBoundaryHeightToCorrectValue()
        {
            var sut = new GameObject().AddComponent<Constants>();
            sut.runInEditMode = true;

            var result = sut.BoundaryHeight;

            Assert.That(result, Is.EqualTo(GetBoundaryNorthY()));
        }
    }
}
