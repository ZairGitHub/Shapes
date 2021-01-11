using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class TimeControllerTests
    {
        private TimeController CreateDefaultTimeController()
        {
            return new GameObject().AddComponent<TimeController>();
        }

        [TearDown]
        public void TearDown() => Time.timeScale = 1.0f;

        [Test]
        public void ResetTime_SetsTimeScaleToPositiveOne()
        {
            var sut = CreateDefaultTimeController();

            sut.ResetTime();
            var result = Time.timeScale;

            Assert.That(result, Is.EqualTo(1.0f));
        }

        [Test]
        public void SlowDownTime_TimeScaleMinusTimeFactorIsGreaterThanMinTime_RemovesTimeFactorFromTimeScale()
        {
            var sut = CreateDefaultTimeController();

            sut.SlowDownTime();
            var result = Time.timeScale;

            Assert.That(result, Is.EqualTo(0.95f));
        }

        [Test]
        public void SlowDownTime_TimeScaleMinusTimeFactorIsLessThanMinTime_SetsTimeScaleToMinTime()
        {
            var sut = CreateDefaultTimeController();
            Time.timeScale = 0.0f;

            sut.SlowDownTime();
            var result = Time.timeScale;

            Assert.That(result, Is.EqualTo(0.05f));
        }

        [Test]
        public void SpeedUpTime_TimeScalePlusTimeFactorIsLessThanMaxTime_AddsTimeFactorToTimeScale()
        {
            var sut = CreateDefaultTimeController();

            sut.SpeedUpTime();
            var result = Time.timeScale;

            Assert.That(result, Is.EqualTo(1.05f));
        }

        [Test]
        public void SpeedUpTime_TimeScalePlusTimeFactorIsGreaterThanMaxTime_SetsTimeScaleToMaxTime()
        {
            var sut = CreateDefaultTimeController();
            Time.timeScale = 10.0f;

            sut.SpeedUpTime();
            var result = Time.timeScale;

            Assert.That(result, Is.EqualTo(10.0f));
        }
    }
}
