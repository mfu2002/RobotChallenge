using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RobotChallenge
{
 public  static class Parser
    {

        /// <summary>
        /// Converts a vector direction to compass equivalent. 
        /// </summary>
        /// <param name="vecDirection">2D Direction Vector</param>
        /// <returns>Representation of the vector in compass notation (north, south etc.)</returns>
        public static string VectorToDirection(IntVector2 vecDirection)
        {
            if(vecDirection.X == 0 && vecDirection.Y == 1) return "NORTH";
            if(vecDirection.X == 1 && vecDirection.Y == 0) return "EAST";
            if(vecDirection.X == 0 && vecDirection.Y == -1) return "SOUTH";
            if(vecDirection.X == -1 && vecDirection.Y == 0) return "WEST";
            return "Invalid Direction";
        }

        /// <summary>
        /// Converts compass notation to 2D direction vector.
        /// </summary>
        /// <param name="direction">
        /// Direction in compass notation (e.g. NORTH).
        /// String must be capitalised. 
        /// </param>
        /// <returns>Representation of the compass notation as 2D direction vector.</returns>
        public static IntVector2 DirectionToVector(string direction)
        {
            switch (direction)
            {
                case "NORTH":
                    return new IntVector2(0, 1);
                case "EAST":
                    return new IntVector2(1, 0);
                case "SOUTH":
                    return new IntVector2(0, -1);
                case "WEST":
                    return new IntVector2(-1, 0);
                default:
                    return new IntVector2(0, 0);
            }
        }

        /// <summary>
        /// Parses the string and runs the appropriate command on the table. 
        /// </summary>
        /// <param name="table">Active table being manipulated.</param>
        /// <param name="command">Command to parse and process</param>
        public static void RunStringCommand(Table table, string command)
        {
            string[] commandWords = command.Split(' ');
            switch (commandWords[0])
            {
                case "PLACE":
                    string[] commandParameters = commandWords[1].Split(',');
                    IntVector2 location = new IntVector2(int.Parse(commandParameters[0]), int.Parse(commandParameters[1]));
                    IntVector2 direction = DirectionToVector(commandParameters[2]);
                    table.PlaceRobot(location, direction);
                    break;
                case "MOVE":
                    table.MoveRobot();
                    break;

                case "LEFT":
                    table.RotateRobot((float)(Math.PI / 2));
                    break;
                case "RIGHT":
                    table.RotateRobot((float)(-Math.PI / 2));
                    break;
                case "REPORT":
                    Console.WriteLine(table.Report());
                    break;
                case "ROBOT":
                    table.SelectedRobot = int.Parse(commandWords[1]) - 1;
                    break;
            }
        }


    }
}
