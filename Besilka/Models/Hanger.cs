using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Besilka.Models
{
    public class Hanger
    {
        public Hanger()
        {
            HangerPoints = new Dictionary<string, Point>();
        }

        public Dictionary<string, Point> HangerPoints { get; set; }

        public Point Rope { get; set; }

        public Point Body { get; set; }

        public Point Head { get; set; }

        public Point LeftArm { get; set; }

        public Point RightArm { get; set; }

        public Point LeftLeg { get; set; }

        public Point RightLeg { get; set; }

        public static int HeadDiameter = 40;

        public static int BodyHeight = 85;

        public static int RopeLength = 40;

        public static Point ArmOffset = new Point(30, 50);

        public static Point LegOffset = new Point(40, 40);
    }
}
