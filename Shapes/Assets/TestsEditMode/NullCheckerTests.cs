﻿using System;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    [TestFixture]
    public class NullCheckerTests
    {
        private readonly GameObject _gameObject = new GameObject();

        [Test]
        public void TryGet_NullGameObject_ReturnsNull()
        {
            var result = NullChecker.TryGet<Rigidbody>(null);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void TryGet_GameObject_ReturnsComponent()
        {
            var result = NullChecker.TryGet<Rigidbody>(_gameObject);

            Assert.That(result, Is.TypeOf<Rigidbody>());
        }

        [Test]
        public void TryFind_NullTag_ReturnsComponent()
        {
            var result = (IGameController)NullChecker
                .TryFind<GameController>(null, _gameObject);

            Assert.That(result, Is.TypeOf<GameController>());
        }

        [Test]
        public void TryFind_NullOrEmptyTag_ReturnsComponent()
        {
            var result = (IGameController)NullChecker
                .TryFind<GameController>(string.Empty, _gameObject);

            LogAssert.Expect(LogType.Exception,
                "ArgumentException: Tag: tag name is null or empty.");

            Assert.That(result, Is.TypeOf<GameController>());
        }
    }
}
