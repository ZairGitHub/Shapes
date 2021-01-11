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
        public void Awake_SetsBoundaryWidthToBoundaryEastX()
        {
            var sut = new GameObject().AddComponent<Constants>();
            sut.runInEditMode = true;

            var result = sut.BoundaryWidth;

            Assert.That(result, Is.EqualTo(GetBoundaryEastX()));
        }

        [Test]
        public void Awake_SetsBoundaryHeightToBoundaryNorthY()
        {
            var sut = new GameObject().AddComponent<Constants>();
            sut.runInEditMode = true;

            var result = sut.BoundaryHeight;

            Assert.That(result, Is.EqualTo(GetBoundaryNorthY()));
        }

        [Test]
        public void Awake_SetsGameWidthToBoundaryWidthMultipliedBy2()
        {
            var sut = new GameObject().AddComponent<Constants>();
            sut.runInEditMode = true;

            var result = sut.GameWidth;

            Assert.That(result, Is.EqualTo(sut.BoundaryWidth * 2.0f));
        }

        [Test]
        public void Awake_SetsGameWidthToBoundaryHeightMultipliedBy2()
        {
            var sut = new GameObject().AddComponent<Constants>();
            sut.runInEditMode = true;

            var result = sut.GameHeight;

            Assert.That(result, Is.EqualTo(sut.BoundaryHeight * 2.0f));
        }
    }
}
