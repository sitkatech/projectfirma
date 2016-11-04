using System.Collections.Generic;
using NUnit.Framework;

namespace LtInfo.Common
{
    [TestFixture]
    public class GraphHelperTest
    {
        [Test]
        public void NullNodeTest()
        {
            TestNode testNode = null;
            var result = GraphHelper.IsTraverseAValidTree(testNode, x => x.Children);
            Assert.That(result, Is.EqualTo(true), "Should be a valid tree");

            var result1 = GraphHelper.Traverse(testNode, x => x.Children);
            Assert.That(result1, Is.EqualTo(new List<TestNode>()));
        }

        [Test]
        public void OneNodeChildrenTraversalTest()
        {
            var testNode = new TestNode();
            var result = GraphHelper.IsTraverseAValidTree(testNode, x => x.Children);
            Assert.That(result, Is.EqualTo(true), "Should be a valid tree");

            var result1 = GraphHelper.Traverse(testNode, x => x.Children);
            Assert.That(result1, Is.EqualTo(new List<TestNode> { testNode }));
        }

        [Test]
        public void OneNodeParentTraversalTest()
        {
            var testNode = new TestNode();
            var result = GraphHelper.IsTraverseAValidTree(testNode, x => x.Parent);
            Assert.That(result, Is.EqualTo(true), "Should be a valid tree");

            var result1 = GraphHelper.Traverse(testNode, x => x.Parent);
            Assert.That(result1, Is.EqualTo(new List<TestNode> { testNode }));
        }

        [Test]
        public void TwoNodesTest()
        {
            var testNode1 = new TestNode();
            var testNode2 = new TestNode();
            testNode1.Children = new List<TestNode>{ testNode2};
            testNode2.Parent = testNode1;
            var result = GraphHelper.IsTraverseAValidTree(testNode1, x => x.Children);
            Assert.That(result, Is.EqualTo(true), "Should be a valid tree");

            var result1 = GraphHelper.Traverse(testNode1, x => x.Children);
            Assert.That(result1, Is.EqualTo(new List<TestNode> { testNode1, testNode2 }));
        }

        [Test]
        public void InvalidTreeWithTwoNodesTest()
        {
            var testNode1 = new TestNode();
            var testNode2 = new TestNode();
            testNode1.Children = new List<TestNode> { testNode2 };
            testNode2.Parent = testNode1;
            testNode2.Children = new List<TestNode> { testNode1 };
            testNode1.Parent = testNode2;
            var result = GraphHelper.IsTraverseAValidTree(testNode1, x => x.Children);
            Assert.That(result, Is.EqualTo(false), "Should be an invalid tree");

            var result1 = GraphHelper.Traverse(testNode1, x => x.Children);
            Assert.That(result1, Is.EqualTo(new List<TestNode> { testNode1, testNode2 }));
        }

        [Test]
        public void InvalidTreeWithThreeNodesTest()
        {
            var testNode1 = new TestNode();
            var testNode2 = new TestNode();
            var testNode3 = new TestNode();
            testNode1.Parent = testNode3;
            testNode1.Children = new List<TestNode> { testNode2 };
            testNode2.Parent = testNode1;
            testNode2.Children = new List<TestNode> { testNode3 };
            testNode3.Parent = testNode2;
            testNode3.Children = new List<TestNode> { testNode1 };
            var result = GraphHelper.IsTraverseAValidTree(testNode1, x => x.Children);
            Assert.That(result, Is.EqualTo(false), "Should be an invalid tree");

            var result1 = GraphHelper.Traverse(testNode1, x => x.Children);
            Assert.That(result1, Is.EqualTo(new List<TestNode> { testNode1, testNode2, testNode3 }));
        }

        public class TestNode
        {
            public TestNode Parent;
            public List<TestNode> Children;
        }
    }
}