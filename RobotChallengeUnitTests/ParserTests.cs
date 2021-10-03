using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotChallenge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotChallengeUnitTests
{
    [TestClass]
    public class ParserTests
    {

        [TestMethod]
        public void VectorToDirectionNorth() =>
            Assert.AreEqual("NORTH", Parser.VectorToDirection(new IntVector2(0,1)));

        [TestMethod]
        public void VectorToDirectionEast() =>
            Assert.AreEqual("EAST", Parser.VectorToDirection(new IntVector2(1, 0)));

        [TestMethod]
        public void VectorToDirectionSouth() =>
            Assert.AreEqual("SOUTH", Parser.VectorToDirection(new IntVector2(0, -1)));

        [TestMethod]
        public void VectorToDirectionWest() =>
         Assert.AreEqual("WEST", Parser.VectorToDirection(new IntVector2(-1, 0)));


        [TestMethod]
        public void DirectionToVectorNorth() =>
            Assert.AreEqual(new IntVector2(0, 1), Parser.DirectionToVector("NORTH"));

        [TestMethod]
        public void DirectionToVectorEast() =>
            Assert.AreEqual( new IntVector2(1, 0), Parser.DirectionToVector("EAST"));

        [TestMethod]
        public void DirectionToVectorSouth() =>
            Assert.AreEqual(new IntVector2(0, -1), Parser.DirectionToVector("SOUTH"));

        [TestMethod]
        public void DirectionToVectorWest() =>
         Assert.AreEqual(new IntVector2(-1, 0), Parser.DirectionToVector("WEST"));

        [TestMethod]
        public void RunStringCommandPlace() 
        {
            Table table = new();
            Parser.RunStringCommand(table, "PLACE 1,1,NORTH");
            Assert.AreEqual("No. of Robots: 1\r\nActive Robot: 1\r\n1,1,NORTH\r\n", table.Report());
        }

        [TestMethod]
        public void RunStringCommandMove()
        {
            Table table = new();
            Parser.RunStringCommand(table, "PLACE 1,1,NORTH");
            Parser.RunStringCommand(table, "MOVE");
            Assert.AreEqual("No. of Robots: 1\r\nActive Robot: 1\r\n1,2,NORTH\r\n", table.Report());
        }

        [TestMethod]
        public void RunStringCommandLeft()
        {
            Table table = new();
            Parser.RunStringCommand(table, "PLACE 1,1,NORTH");
            Parser.RunStringCommand(table, "LEFT");
            Assert.AreEqual("No. of Robots: 1\r\nActive Robot: 1\r\n1,1,WEST\r\n", table.Report());
        }

        [TestMethod]
        public void RunStringCommandRight()
        {
            Table table = new();
            Parser.RunStringCommand(table, "PLACE 1,1,NORTH");
            Parser.RunStringCommand(table, "RIGHT");
            Assert.AreEqual("No. of Robots: 1\r\nActive Robot: 1\r\n1,1,EAST\r\n", table.Report());
        }

        [TestMethod]
        public void RunStringCommandRobot()
        {
            Table table = new();
            Parser.RunStringCommand(table, "PLACE 1,1,NORTH");
            Parser.RunStringCommand(table, "RIGHT");
            Parser.RunStringCommand(table, "PLACE 3,3,SOUTH");
            Parser.RunStringCommand(table, "ROBOT 2");
            Parser.RunStringCommand(table, "MOVE");
            Assert.AreEqual("No. of Robots: 2\r\nActive Robot: 2\r\n3,2,SOUTH\r\n", table.Report());
        }

        [TestMethod]
        public void InterviewScenarioA()
        {
            Table table = new();
            Parser.RunStringCommand(table, "PLACE 0,0,NORTH");
            Parser.RunStringCommand(table, "MOVE");
            Assert.AreEqual("No. of Robots: 1\r\nActive Robot: 1\r\n0,1,NORTH\r\n", table.Report());
        }
        
        [TestMethod]
        public void InterviewScenarioB()
        {
            Table table = new();
            Parser.RunStringCommand(table, "PLACE 0,0,NORTH");
            Parser.RunStringCommand(table, "LEFT");
            Assert.AreEqual("No. of Robots: 1\r\nActive Robot: 1\r\n0,0,WEST\r\n", table.Report());
        }

        [TestMethod]
        public void InterviewScenarioC()
        {
            Table table = new();
            Parser.RunStringCommand(table, "PLACE 1,2,EAST");
            Parser.RunStringCommand(table, "MOVE");
            Parser.RunStringCommand(table, "MOVE");
            Parser.RunStringCommand(table, "LEFT");
            Parser.RunStringCommand(table, "MOVE");
            Assert.AreEqual("No. of Robots: 1\r\nActive Robot: 1\r\n3,3,NORTH\r\n", table.Report());
        }

    }
}
