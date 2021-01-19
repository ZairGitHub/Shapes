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

        private void RemoveBoundaryTag()
        {
            GameObject.FindWithTag("Boundary").tag = "Debug";
        }

        private void RestoreBoundaryTag()
        {
            GameObject.FindWithTag("Debug").tag = "Boundary";
        }

        [Test]
        public void Awake_BoundaryDoesNotExist_SetsBoundaryWidthToZero()
        {
            RemoveBoundaryTag();
            var sut = CreateDefaultConstants();
            sut.runInEditMode = true;

            var result = sut.BoundaryWidth;

            Assert.That(result, Is.Zero);
            RestoreBoundaryTag();
        }

        [Test]
        public void Awake_BoundaryDoesNotExist_SetsBoundaryHeightToZero()
        {
            GameObject.FindWithTag("Boundary").tag = "Debug";
            var sut = CreateDefaultConstants();
            sut.runInEditMode = true;

            var result = sut.BoundaryHeight;

            Assert.That(result, Is.Zero);

            GameObject.FindWithTag("Debug").tag = "Boundary";
        }

        [Test]
        public void Awake_BoundaryExists_SetsBoundaryWidthToBoundaryChild()
        {
            var sut = CreateDefaultConstants();
            sut.runInEditMode = true;

            var boundaryEast = GameObject.FindWithTag("Boundary").transform.GetChild(1);
            var result = sut.BoundaryWidth;

            Assert.That(result, Is.EqualTo(boundaryEast.position.x));
        }

        [Test]
        public void Awake_BoundaryExists_SetsBoundaryHeightToBoundaryChild()
        {
            var sut = CreateDefaultConstants();
            sut.runInEditMode = true;

            var boundaryNorth = GameObject.FindWithTag("Boundary").transform.GetChild(0);
            var result = sut.BoundaryHeight;

            Assert.That(result, Is.EqualTo(boundaryNorth.position.y));
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
