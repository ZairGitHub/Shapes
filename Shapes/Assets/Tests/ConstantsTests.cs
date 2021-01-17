using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    [TestFixture]
    public class ConstantsTests
    {
        private Constants CreateDefaultConstants()
        {
            return new GameObject().AddComponent<Constants>();
        }

        [Test]
        public void Awake_BoundaryEastDoesNotExist_SetsBoundaryWidthToZero()
        {
            GameObject.FindGameObjectWithTag("BoundaryEast").tag = "Debug";
            var sut = CreateDefaultConstants();
            sut.runInEditMode = true;

            var result = sut.BoundaryWidth;

            Assert.That(result, Is.Zero);

            GameObject.FindGameObjectWithTag("Debug").tag = "BoundaryEast";
        }

        [Test]
        public void Awake_BoundaryEastExists_SetsBoundaryWidthToBoundaryEastX()
        {
            var sut = CreateDefaultConstants();
            sut.runInEditMode = true;

            var boundaryEast = GameObject.FindGameObjectWithTag("BoundaryEast");
            var result = sut.BoundaryWidth;

            Assert.That(result, Is.EqualTo(boundaryEast.transform.position.x));
        }

        [Test]
        public void Awake_BoundaryNorthDoesNotExist_SetsBoundaryHeightToZero()
        {
            GameObject.FindGameObjectWithTag("BoundaryNorth").tag = "Debug";
            var sut = CreateDefaultConstants();
            sut.runInEditMode = true;

            var result = sut.BoundaryHeight;

            Assert.That(result, Is.Zero);

            GameObject.FindGameObjectWithTag("Debug").tag = "BoundaryNorth";
        }

        [Test]
        public void Awake_BoundaryNorthExists_SetsBoundaryHeightToBoundaryNorthY()
        {
            var sut = CreateDefaultConstants();
            sut.runInEditMode = true;

            var boundaryNorth = GameObject.FindGameObjectWithTag("BoundaryNorth");
            var result = sut.BoundaryHeight;

            Assert.That(result, Is.EqualTo(boundaryNorth.transform.position.y));
        }

        [Test]
        public void Awake_SetsGameWidthToBoundaryWidthMultipliedByTwo()
        {
            var sut = CreateDefaultConstants();
            sut.runInEditMode = true;

            var result = sut.GameWidth;

            Assert.That(result, Is.EqualTo(sut.BoundaryWidth * 2.0f));
        }

        [Test]
        public void Awake_SetsGameHeightToBoundaryHeightMultipliedByTwo()
        {
            var sut = CreateDefaultConstants();
            sut.runInEditMode = true;

            var result = sut.GameHeight;

            Assert.That(result, Is.EqualTo(sut.BoundaryHeight * 2.0f));
        }
    }
}
