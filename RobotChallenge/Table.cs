using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RobotChallenge
{
   public class Table
    {
        // Dimensions of the table
        const int TABLE_HEIGHT = 5;
        const int TABLE_WIDTH = 5;

        // robots present on the table
        public List<Robot> Robots { get; set; } = new();

        int _selectedRobot = -1;

        // Index of the robot currently active from the robots. -1 when no robot is selected.
        public int SelectedRobot { get => _selectedRobot; 
            set { 
                if(value < Robots.Count)
                {
                    _selectedRobot = value;
                }
            }
        }


        /// <summary>
        /// Places the robot on the table.
        /// Does nothing if robot placed outside of table boundary.
        /// </summary>
        /// <param name="location">Location of the new robot.</param>
        /// <param name="direction">Direction the robot is facing.</param>
        public void PlaceRobot(IntVector2 location, IntVector2 direction)
        {
            // Guard clause to make sure robot is within the table confinements. 
            if (!ValidRobotLocation(location)) return;


            Robots.Add(new Robot(location, direction));

            if (Robots.Count == 1)
            {
                SelectedRobot = 0;
            }
        }


        /// <summary>
        /// Moves the robot in the direction it is facing. 
        /// Does nothing if the movement will make the robot fall off the table. 
        /// </summary>
        public void MoveRobot()
        {
            // Guard clause to ensure robot is selected.
            if (SelectedRobot == -1) return;

            // Guard clause to check whether the movement will push the robot off the table. 
            IntVector2 newLocation = Robots[SelectedRobot].Location + Robots[SelectedRobot].Direction;
            if (!ValidRobotLocation(newLocation)) return;

            Robots[SelectedRobot].Location = newLocation;

        }

        /// <summary>
        /// Rotates the direction the robot is facing. 
        /// </summary>
        /// <param name="rotation">Angle in radians. Anti-clockwise. </param>
        public void RotateRobot(float rotation)
        {
            // Guard clause to ensure robot is selected.
            if (SelectedRobot == -1) return;

            IntVector2 newDirection = IntVector2.Transform(Robots[SelectedRobot].Direction, Matrix3x2.CreateRotation(rotation));

            Robots[SelectedRobot].Direction = newDirection;
        }

        /// <summary>
        /// Summarises the state of the table.  
        /// </summary>
        /// <returns>Outputs number of robots, current active robot and its location.</returns>
        public string Report()
        {
            StringBuilder reportString = new();

            reportString.AppendLine($"No. of Robots: {Robots.Count}");
            reportString.AppendLine($"Active Robot: {(SelectedRobot == -1 ? "None" : SelectedRobot + 1)}");
            if (SelectedRobot != -1)
            {
                reportString.AppendLine($"{Robots[SelectedRobot].Location.X},{Robots[SelectedRobot].Location.Y},{Parser.VectorToDirection(Robots[SelectedRobot].Direction)}");
            }

            return reportString.ToString();
        }

        /// <summary>
        /// Checks whether the position is allowed for the robot.
        /// </summary>
        /// <param name="location">Location that needs to be checked.</param>
        /// <returns>True if the location is valid, false otherwise. </returns>
        private static bool ValidRobotLocation(IntVector2 location) => (location.X >= 0 && location.Y >= 0 && location.X <= TABLE_WIDTH && location.Y <= TABLE_HEIGHT);
        

    }
}
