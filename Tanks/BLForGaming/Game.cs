﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLForGaming
{
    class Game // сущность игра, которая видит все на поле и что-то делает при определенных действиях в игре
    {
        public static GameField Field { get; } // игровое поле, оно одно будет - поэтому static (для него тоже будет "Одиночка")
        public List<Tank> TanksInGame; // танки в игре
        public List<Obstacles> ObstaclesInGame; // препятствия в игре
        public List<Artifact> ArtifactsInGame; // артефакты в игре

        private static Game instance;        

        protected Game()
        {
            
        }

        public static Game Initialize()
        {
            if (instance == null)
                instance = new Game();
            // после инициализации - методы типа "создать поле", "создать танки в игре" и т. д.
            return instance;
        }
    }
}
