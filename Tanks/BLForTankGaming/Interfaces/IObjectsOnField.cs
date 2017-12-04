using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BLForTankGame
{
    public interface IObjectsOnField // интерфейс, описывающий все обьекты, присутствующие на поле
    {
        Image ObjectImage { get; } // изображение обьекта (танка, артефакта и так далее)
        int GetX { get; } // координата икс на поле
        int GetY { get; } // координта игрек на поле
    }
}
