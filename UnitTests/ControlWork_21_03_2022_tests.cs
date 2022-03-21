using Microsoft.VisualStudio.TestTools.UnitTesting;
using Programming;
using DeeULib;
using System.Collections;
using System;
using System.Linq;
namespace UnitTests
{
    [TestClass]
    public class ControlWork_21_03_2022_tests
    {
        [TestMethod]
        public void SizeTest()
        {

            var queue = new ControlWork_21_03_2022.CustomQueue<int>();
            var node = new ControlWork_21_03_2022.Node<int>(1);
            var node1 = new ControlWork_21_03_2022.Node<int>(2);
            var node2 = new ControlWork_21_03_2022.Node<int>(3);
            var node3 = new ControlWork_21_03_2022.Node<int>(4);
            var node4 = new ControlWork_21_03_2022.Node<int>(46);
            var node5 = new ControlWork_21_03_2022.Node<int>(46);

            var nodes = new[] {node1,node2,node3,node4,node5};

            queue.Enqueue(node);
            queue.Enqueue(node1);
            queue.Enqueue(node2);
            queue.Enqueue(node3);
            queue.Enqueue(node4);
         

            Assert.AreEqual(nodes.Length, queue.Size());

            queue.Enqueue(node5);
            Assert.AreNotEqual(nodes.Length, queue.Size());
        }
        [TestMethod]
        public void IsEmptyTest()
        {
            var queue = new ControlWork_21_03_2022.CustomQueue<int>();
            var node = new ControlWork_21_03_2022.Node<int>(1);
            var node1 = new ControlWork_21_03_2022.Node<int>(2);
            var node2 = new ControlWork_21_03_2022.Node<int>(3);
            var node3 = new ControlWork_21_03_2022.Node<int>(4);
            var node4 = new ControlWork_21_03_2022.Node<int>(46);
            var node5 = new ControlWork_21_03_2022.Node<int>(46);

            var nodes = new[] { node1, node2, node3, node4, node5 };

            queue.Enqueue(node);
            queue.Enqueue(node1);
            queue.Enqueue(node2);
            queue.Enqueue(node3);
            queue.Enqueue(node4);
            queue.Enqueue(node5);

            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();

            Assert.AreEqual(nodes.Length > 0, queue.IsEmpty());
            Assert.IsTrue(queue.IsEmpty());
        }
        [TestMethod]
        public void RemoveThirdTest()
        {
            var queue = new ControlWork_21_03_2022.CustomQueue<int>();
            var node = new ControlWork_21_03_2022.Node<int>(1);
            var node1 = new ControlWork_21_03_2022.Node<int>(2);
            var node2 = new ControlWork_21_03_2022.Node<int>(3);
            var node3 = new ControlWork_21_03_2022.Node<int>(4);
            var node4 = new ControlWork_21_03_2022.Node<int>(46);
            var node5 = new ControlWork_21_03_2022.Node<int>(46);

            var nodes = new[] { node1, node2, node3, node4, node5 };

            queue.Enqueue(node);
            queue.Enqueue(node1);
            queue.Enqueue(node2);
            queue.Enqueue(node3);
            queue.Enqueue(node4);
            queue.Enqueue(node5);

            Assert.AreNotEqual(nodes[2], queue.list.ToArray()[2]);
            Assert.AreEqual(nodes[2], queue.list.ToArray()[3]);
        }

        [TestMethod]
        public void AddTest()
        {
            var queue = new ControlWork_21_03_2022.CustomQueue<int>();
            var node = new ControlWork_21_03_2022.Node<int>(1);
            var node1 = new ControlWork_21_03_2022.Node<int>(2);
            var node2 = new ControlWork_21_03_2022.Node<int>(3);
            var node3 = new ControlWork_21_03_2022.Node<int>(4);
            var node4 = new ControlWork_21_03_2022.Node<int>(46);
            var node5 = new ControlWork_21_03_2022.Node<int>(46);

            var nodes = new[] { node1, node2, node3, node4, node5 };

            queue.Enqueue(node);
            Assert.AreEqual(queue.ToList()[0], node);
            queue.Enqueue(node1);
            Assert.AreEqual(queue.ToList()[1], node1);
            queue.Enqueue(node2);
            Assert.AreEqual(queue.ToList()[2], node2);
            queue.Enqueue(node3);
            Assert.AreEqual(queue.ToList()[3], node3);
            queue.Enqueue(node4);
            Assert.AreEqual(queue.ToList()[4], node4);
            queue.Enqueue(node5);
            Assert.AreEqual(queue.ToList()[5], node5);
       
        }

        [TestMethod]
        public void RemoveTest()
        {
            var queue = new ControlWork_21_03_2022.CustomQueue<int>();
            var node = new ControlWork_21_03_2022.Node<int>(1);
            var node1 = new ControlWork_21_03_2022.Node<int>(2);
            var node2 = new ControlWork_21_03_2022.Node<int>(3);
            var node3 = new ControlWork_21_03_2022.Node<int>(4);
            var node4 = new ControlWork_21_03_2022.Node<int>(46);
            var node5 = new ControlWork_21_03_2022.Node<int>(46);

            var nodes = new[] { node1, node2, node3, node4, node5 };

            queue.Enqueue(node);
            queue.Enqueue(node1);
            queue.Enqueue(node2);
            queue.Enqueue(node3);
            queue.Enqueue(node4);
            queue.Enqueue(node5);
            queue.Remove(0);

            Assert.AreNotEqual(queue.ToList()[0], node);
            Assert.AreEqual(queue.ToList()[0], node1);
            
        }
    }
}