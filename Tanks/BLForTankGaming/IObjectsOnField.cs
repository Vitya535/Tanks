using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BLForInterfaces
{
    public interface IObjectsOnField // интерфейс, описывающий все обьекты, присутствующие на поле
    {
        Image GetObjectImage { get; } // изображение обьекта (танка, артефакта и так далее)
        int GetX { get; } // координата икс на поле
        int GetY { get; } // координта игрек на поле
    }
}
