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
            GameObject.FindWithTag(Tags.Boundary).tag = Tags.Debug;
        }

        private void RestoreBoundaryTag()
        {
            GameObject.FindWithTag(Tags.Debug).tag = Tags.Boundary;
        }

        [Test]
        public void Awake_BoundaryDoesNotExist_SetsBoundaryWidthToZero()
        {
            RemoveBoundaryTag();
            var sut = CreateDefaultConstants();
            sut.runInEditMode = true;

            var result = sut.HalfBoundaryWidth;

            Assert.That(result, Is.Zero);
            RestoreBoundaryTag();
        }

        [Test]
        public void Awake_BoundaryDoesNotExist_SetsBoundaryHeightToZero()
        {
            RemoveBoundaryTag();
            var sut = CreateDefaultConstants();
            sut.runInEditMode = true;

            var result = sut.HalfBoundaryHeight;

            Assert.That(result, Is.Zero);
            RestoreBoundaryTag();
        }

        [Test]
        public void Awake_BoundaryExists_SetsBoundaryWidthToBoundaryChild()
        {
            var boundaryChild = GameObject.FindWithTag(Tags.Boundary)
                .transform.GetChild(1);
            var sut = CreateDefaultConstants();
            sut.runInEditMode = true;

            var result = sut.HalfBoundaryWidth;

            Assert.That(result, Is.EqualTo(boundaryChild.position.x));
        }

        [Test]
        public void Awake_BoundaryExists_SetsBoundaryHeightToBoundaryChild()
        {
            var boundaryChild = GameObject.FindWithTag(Tags.Boundary)
                .transform.GetChild(0);
            var sut = CreateDefaultConstants();
            sut.runInEditMode = true;

            var result = sut.HalfBoundaryHeight;

            Assert.That(result, Is.EqualTo(boundaryChild.position.y));
        }

        [Test]
        public void Awake_SetsGameWidthToBoundaryWidthMultipliedByTwo()
        {
            var sut = CreateDefaultConstants();
            sut.runInEditMode = true;

            var result = sut.GameWidth;

            Assert.That(result, Is.EqualTo(sut.HalfBoundaryWidth * 2.0f));
        }

        [Test]
        public void Awake_SetsGameHeightToBoundaryHeightMultipliedByTwo()
        {
            var sut = CreateDefaultConstants();
            sut.runInEditMode = true;

            var result = sut.GameHeight;

            Assert.That(result, Is.EqualTo(sut.HalfBoundaryHeight * 2.0f));
        }
    }
}
