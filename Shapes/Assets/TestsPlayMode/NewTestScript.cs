using System.Collections;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class NewTestScript
    {
        // A Test behaves as an ordinary method
        [UnityTest]
        public IEnumerator NewTestScriptSimplePasses()
        {
            var mock = Substitute.For<IUnityService>();
            mock.GetAxis("Horizontal").Returns(1f);

            var sut = new GameObject().AddComponent<PlayerController>();
            yield return null;
            sut.ContructorForTests(mock);

            yield return new WaitForFixedUpdate();
            var result = sut.GetComponent<Rigidbody>().velocity;

            Assert.That(result, Is.EqualTo(1));
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator NewTestScriptWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
