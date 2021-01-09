﻿using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class TimeControllerTests
    {
        [TearDown]
        public void Setup()
        {
            Time.timeScale = 1.0f;
        }

        [Test]
        public void ResetTime_SetsTimeScaleToPositiveOne()
        {
            var sut = new GameObject().AddComponent<TimeController>();

            sut.ResetTime();
            var result = Time.timeScale;

            Assert.That(result, Is.EqualTo(1.0f));
        }

        [Test]
        public void SlowDownTime_TimeScaleMinusTimeFactorIsGreaterThanMinTime_RemovesTimeFactorFromTimeScale()
        {
            var sut = new GameObject().AddComponent<TimeController>();
            
            sut.SlowDownTime();
            var result = Time.timeScale;

            Assert.That(result, Is.EqualTo(0.95f));
        }

        [Test]
        public void SlowDownTime_TimeScaleMinusTimeFactorIsLessThanMinTime_SetsTimeScaleToMinTime()
        {
            var sut = new GameObject().AddComponent<TimeController>();
            Time.timeScale = 0.0f;

            sut.SlowDownTime();
            var result = Time.timeScale;

            Assert.That(result, Is.EqualTo(0.05f));
        }

        [Test]
        public void SpeedUpTime_TimeScalePlusTimeFactorIsLessThanMaxTime_AddsTimeFactorToTimeScale()
        {
            var sut = new GameObject().AddComponent<TimeController>();
            
            sut.SpeedUpTime();
            var result = Time.timeScale;

            Assert.That(result, Is.EqualTo(1.05f));
        }

        [Test]
        public void SpeedUpTime_TimeScalePlusTimeFactorIsGreaterThanMaxTime_SetsTimeScaleToMaxTime()
        {
            var sut = new GameObject().AddComponent<TimeController>();
            Time.timeScale = 10.0f;

            sut.SpeedUpTime();
            var result = Time.timeScale;

            Assert.That(result, Is.EqualTo(10.0f));
        }
    }
}