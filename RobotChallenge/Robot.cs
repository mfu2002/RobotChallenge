using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RobotChallenge
{
   public class Robot
    {
        // Stores Robot X and Y coordinate
        public IntVector2 Location { get; set; }

        // Stores the direction in which the robot is facing as a vector.
        // Using a vector to allow future adaptations of the software to face N30°E and is not just constrained to North, South, East, West 
        public IntVector2 Direction { get; set; }


        public Robot(IntVector2 location, IntVector2 direction)
        {
            Location = location;
            Direction = direction;
        }

    }
}
