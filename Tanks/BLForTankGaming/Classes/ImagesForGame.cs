using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BLForTankGame
{
    public class ImagesForGame
    {
        private static readonly Image tankPlayerDown = Image.FromFile("../../../Images/PLayDown.jpg");
        private static readonly Image tankPlayerUp = Image.FromFile("../../../Images/PlayUp.jpg");
        private static readonly Image tankPlayerLeft = Image.FromFile("../../../Images/PLayLeft.jpg");
        private static readonly Image tankPlayerRight = Image.FromFile("../../../Images/PlayRight.jpg");

        private static readonly Image tankAIDown = Image.FromFile("../../../Images/AIdown.jpg");
        private static readonly Image tankAIUp = Image.FromFile("../../../Images/AIUp.jpg");
        private static readonly Image tankAILeft = Image.FromFile("../../../Images/AILeft.jpg");
        private static readonly Image tankAIRight = Image.FromFile("../../../Images/AIRight.jpg");

        private static readonly Image destructObstacle = Image.FromFile("../../../Images/brick.jpg");
        private static readonly Image undestructObstacle = Image.FromFile("../../../Images/metbrck.jpg");

        private static readonly Image repairKit = Image.FromFile("../../../Images/health.jpg");
        private static readonly Image damageUp = Image.FromFile("../../../Images/damage.jpg");
        private static readonly Image rangeUp = Image.FromFile("../../../Images/range.jpg");

        private static readonly Image lightShell = Image.FromFile("../../../Images/whiteShell.jpg");
        private static readonly Image mediumShell = Image.FromFile("../../../Images/yellowShell.jpg");
        private static readonly Image heavyShell = Image.FromFile("../../../Images/blackShell.jpg");

        public static Image GetTankPlayerDown { get { return tankPlayerDown; } }
        public static Image GetTankPlayerUp { get { return tankPlayerUp; } }
        public static Image GetTankPlayerLeft { get { return tankPlayerLeft; } }
        public static Image GetTankPlayerRight { get { return tankPlayerRight; } }

        public static Image GetTankAIDown { get { return tankAIDown; } }
        public static Image GetTankAIUp { get { return tankAIUp; } }
        public static Image GetTankAILeft { get { return tankAILeft; } }
        public static Image GetTankAIRight { get { return tankAIRight; } }

        public static Image GetDestructObstacle { get { return destructObstacle; } }
        public static Image GetUndestructObstacle { get { return undestructObstacle; } }

        public static Image GetRepairKit { get { return repairKit; } }
        public static Image GetDamageUp { get { return damageUp; } }
        public static Image GetRangeUp { get { return rangeUp; } }

        public static Image GetLightShell { get { return lightShell; } }
        public static Image GetMediumShell { get { return mediumShell; } }
        public static Image GetHeavyShell { get { return heavyShell; } }
    }
}
