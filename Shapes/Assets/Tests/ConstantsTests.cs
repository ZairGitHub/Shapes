using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class ConstantsTests
    {
        [Test]
        public void Awake_SetsBoundaryWidthToBoundaryEastX()
        {
            var sut = new GameObject().AddComponent<Constants>();
            sut.runInEditMode = true;

            var boundaryEast = GameObject.FindGameObjectWithTag("BoundaryEast");
            var result = sut.BoundaryWidth;

            Assert.That(result, Is.EqualTo(boundaryEast.transform.position.x));
        }

        [Test]
        public void Awake_SetsBoundaryHeightToBoundaryNorthY()
        {
            var sut = new GameObject().AddComponent<Constants>();
            sut.runInEditMode = true;

            var boundaryHeight = GameObject.FindGameObjectWithTag("BoundaryNorth");
            var result = sut.BoundaryHeight;

            Assert.That(result, Is.EqualTo(boundaryHeight.transform.position.y));
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
