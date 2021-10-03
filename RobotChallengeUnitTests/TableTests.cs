using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotChallenge;
using System;

namespace RobotChallengeUnitTests
{
    [TestClass]
    public class TableTests
    {
        [TestMethod]
        public void PlaceRobotOutsideTable()
        {
            Table table = new();
            table.PlaceRobot(new IntVector2(6, 6), new IntVector2(0, 1));
            Assert.AreEqual("No. of Robots: 0\r\nActive Robot: None\r\n", table.Report());
        }

        [TestMethod]
        public void PlaceRobotInsideTable()
        {
            Table table = new();
            table.PlaceRobot(new IntVector2(2, 2), new IntVector2(0, 1));
            Assert.AreEqual("No. of Robots: 1\r\nActive Robot: 1\r\n2,2,NORTH\r\n", table.Report());
        }
        [TestMethod]
        public void MoveRobotUp()
        {
            Table table = new();
            table.PlaceRobot(new IntVector2(2, 2), new IntVector2(0, 1));
            table.MoveRobot();
            Assert.AreEqual("No. of Robots: 1\r\nActive Robot: 1\r\n2,3,NORTH\r\n", table.Report());
        }

        [TestMethod]
        public void MoveRobotRight()
        {
            Table table = new();
            table.PlaceRobot(new IntVector2(2, 2), new IntVector2(1, 0));
            table.MoveRobot();
            Assert.AreEqual("No. of Robots: 1\r\nActive Robot: 1\r\n3,2,EAST\r\n", table.Report());
        }

        [TestMethod]
        public void MoveRobotDown()
        {
            Table table = new();
            table.PlaceRobot(new IntVector2(2, 2), new IntVector2(0, -1));
            table.MoveRobot();
            Assert.AreEqual("No. of Robots: 1\r\nActive Robot: 1\r\n2,1,SOUTH\r\n", table.Report());
        }

        [TestMethod]
        public void MoveRobotLeft()
        {
            Table table = new();
            table.PlaceRobot(new IntVector2(2, 2), new IntVector2(-1, 0));
            table.MoveRobot();
            Assert.AreEqual("No. of Robots: 1\r\nActive Robot: 1\r\n1,2,WEST\r\n", table.Report());
        }

        [TestMethod]
        public void MoveRobotOutsideRight()
        {
            Table table = new();
            table.PlaceRobot(new IntVector2(4, 2), new IntVector2(1, 0));
            table.MoveRobot();
            table.MoveRobot();
            Assert.AreEqual("No. of Robots: 1\r\nActive Robot: 1\r\n5,2,EAST\r\n", table.Report());
        }

        [TestMethod]
        public void MoveRobotOutsideLeft()
        {
            Table table = new();
            table.PlaceRobot(new IntVector2(1, 2), new IntVector2(-1, 0));
            table.MoveRobot();
            table.MoveRobot();
            Assert.AreEqual("No. of Robots: 1\r\nActive Robot: 1\r\n0,2,WEST\r\n", table.Report());
        }

        [TestMethod]
        public void MoveRobotOutsideUp()
        {
            Table table = new();
            table.PlaceRobot(new IntVector2(1, 4), new IntVector2(0, 1));
            table.MoveRobot();
            table.MoveRobot();
            Assert.AreEqual("No. of Robots: 1\r\nActive Robot: 1\r\n1,5,NORTH\r\n", table.Report());
        }

        [TestMethod]
        public void MoveRobotOutsideDown()
        {
            Table table = new();
            table.PlaceRobot(new IntVector2(1, 1), new IntVector2(0, -1));
            table.MoveRobot();
            table.MoveRobot();
            Assert.AreEqual("No. of Robots: 1\r\nActive Robot: 1\r\n1,0,SOUTH\r\n", table.Report());
        }

        [TestMethod]
        public void RotateRobotRight()
        {
            Table table = new();
            table.PlaceRobot(new IntVector2(1, 1), new IntVector2(0, 1));
            table.RotateRobot((float)(-Math.PI / 2));
            Assert.AreEqual("No. of Robots: 1\r\nActive Robot: 1\r\n1,1,EAST\r\n", table.Report());
        }

        [TestMethod]
        public void RotateRobotLeft()
        {
            Table table = new();
            table.PlaceRobot(new IntVector2(1, 1), new IntVector2(0, 1));
            table.RotateRobot((float)(Math.PI / 2));
            Assert.AreEqual("No. of Robots: 1\r\nActive Robot: 1\r\n1,1,WEST\r\n", table.Report());
        }
        [TestMethod]
        public void SelectRobot()
        {
            Table table = new();
            table.PlaceRobot(new IntVector2(1, 1), new IntVector2(0, 1));
            table.MoveRobot();
            table.PlaceRobot(new IntVector2(4, 3), new IntVector2(0, -1));
            table.SelectedRobot = 1;
            table.MoveRobot();
            Assert.AreEqual("No. of Robots: 2\r\nActive Robot: 2\r\n4,2,SOUTH\r\n", table.Report());
        }

    }
}
