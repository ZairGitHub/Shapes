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

        private void RemoveBoundaryGameTag()
        {
            GameObject.FindWithTag(Tags.BoundaryGame).tag = Tags.Debug;
        }

        private void RemoveBoundaryViewTag()
        {
            GameObject.FindWithTag(Tags.BoundaryView).tag = Tags.Debug;
        }

        private void RestoreBoundaryGameTag()
        {
            GameObject.FindWithTag(Tags.Debug).tag = Tags.BoundaryGame;
        }

        private void RestoreBoundaryViewTag()
        {
            GameObject.FindWithTag(Tags.Debug).tag = Tags.BoundaryView;
        }

        [Test]
        public void Awake_BoundaryGameDoesNotExist_SetsGameWidthToZero()
        {
            RemoveBoundaryGameTag();
            var sut = CreateDefaultConstants();
            sut.runInEditMode = true;

            var result = sut.GameWidth;

            Assert.That(result, Is.Zero);
            RestoreBoundaryGameTag();
        }

        [Test]
        public void Awake_BoundaryGameDoesNotExist_SetsGameHeightToZero()
        {
            RemoveBoundaryGameTag();
            var sut = CreateDefaultConstants();
            sut.runInEditMode = true;

            var result = sut.GameHeight;

            Assert.That(result, Is.Zero);
            RestoreBoundaryGameTag();
        }

        [Test]
        public void Awake_BoundaryGameExists_SetsGameWidthToBoundaryChildren()
        {
            var boundary = GameObject.FindWithTag(Tags.BoundaryGame);
            var boundaryChild1 = boundary.transform.GetChild(1).position.x;
            var boundaryChild2 = boundary.transform.GetChild(3).position.x;
            var sut = CreateDefaultConstants();
            sut.runInEditMode = true;

            var result = sut.GameWidth;

            Assert.That(result, Is.EqualTo(boundaryChild1 - boundaryChild2));
        }

        [Test]
        public void Awake_BoundaryGameExists_SetsGameHeightToBoundaryChildren()
        {
            var boundary = GameObject.FindWithTag(Tags.BoundaryGame);
            var boundaryChild1 = boundary.transform.GetChild(0).position.y;
            var boundaryChild2 = boundary.transform.GetChild(2).position.y;
            var sut = CreateDefaultConstants();
            sut.runInEditMode = true;

            var result = sut.GameHeight;

            Assert.That(result, Is.EqualTo(boundaryChild1 - boundaryChild2));
        }

        [Test]
        public void Awake_SetsHalfGameWidthToGameWidthDividedByTwo()
        {
            var sut = CreateDefaultConstants();
            sut.runInEditMode = true;

            var result = sut.HalfGameWidth;

            Assert.That(result, Is.EqualTo(sut.GameWidth / 2.0f));
        }

        [Test]
        public void Awake_SetsHalfGameHeightToGameHeightDividedByTwo()
        {
            var sut = CreateDefaultConstants();
            sut.runInEditMode = true;

            var result = sut.HalfGameHeight;

            Assert.That(result, Is.EqualTo(sut.GameHeight / 2.0f));
        }

        [Test]
        public void Awake_BoundaryViewDoesNotExist_SetsViewWidthToZero()
        {
            RemoveBoundaryViewTag();
            var sut = CreateDefaultConstants();
            sut.runInEditMode = true;

            var result = sut.ViewWidth;

            Assert.That(result, Is.Zero);
            RestoreBoundaryViewTag();
        }

        [Test]
        public void Awake_BoundaryViewDoesNotExist_SetsViewHeightToZero()
        {
            RemoveBoundaryViewTag();
            var sut = CreateDefaultConstants();
            sut.runInEditMode = true;

            var result = sut.ViewHeight;

            Assert.That(result, Is.Zero);
            RestoreBoundaryViewTag();
        }

        [Test]
        public void Awake_BoundaryViewExists_SetsViewWidthToBoundaryChildren()
        {
            var boundary = GameObject.FindWithTag(Tags.BoundaryView);
            var boundaryChild1 = boundary.transform.GetChild(1).position.x;
            var boundaryChild2 = boundary.transform.GetChild(3).position.x;
            var sut = CreateDefaultConstants();
            sut.runInEditMode = true;

            var result = sut.ViewWidth;

            Assert.That(result, Is.EqualTo(boundaryChild1 - boundaryChild2));
        }

        [Test]
        public void Awake_BoundaryViewExists_SetsViewHeightToBoundaryChildren()
        {
            var boundary = GameObject.FindWithTag(Tags.BoundaryView);
            var boundaryChild1 = boundary.transform.GetChild(0).position.y;
            var boundaryChild2 = boundary.transform.GetChild(2).position.y;
            var sut = CreateDefaultConstants();
            sut.runInEditMode = true;

            var result = sut.ViewHeight;

            Assert.That(result, Is.EqualTo(boundaryChild1 - boundaryChild2));
        }

        [Test]
        public void Awake_SetsHalfViewWidthToViewWidthDividedByTwo()
        {
            var sut = CreateDefaultConstants();
            sut.runInEditMode = true;

            var result = sut.HalfViewWidth;

            Assert.That(result, Is.EqualTo(sut.ViewWidth / 2.0f));
        }

        [Test]
        public void Awake_SetsHalfViewHeightToViewHeightDividedByTwo()
        {
            var sut = CreateDefaultConstants();
            sut.runInEditMode = true;

            var result = sut.HalfViewHeight;

            Assert.That(result, Is.EqualTo(sut.ViewHeight / 2.0f));
        }
    }
}
