﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLForTankGame
{
    public class Game : IGame, IObserver// сущность игра, которая видит все на поле и что-то делает при определенных действиях в игре
    {
        public List<IObjectsOnField> StaticObjectsInGame { get; private set; }
        public List<IDamagable> DamagableObjectsInGame { get; private set; }

        private static Game instance;        
        private Game(int CountTanks, int CountObstacles, int CountCartridges, int CountArtifacts)
        {
            Builder P = new BuilderForPlayerTank();
            Director Pl = new Director(P);
            Builder D = new DefenseTankBuilder();
            Director Def = new Director(D);
            Builder A = new AttackTankBuilder();
            Director Att = new Director(A);

            StaticObjectsInGame = new List<IObjectsOnField>();
            DamagableObjectsInGame = new List<IDamagable>();

            Pl.Construct();
            Tank ForPlayer = P.GetResult();
            StaticObjectsInGame.Add(ForPlayer);
            DamagableObjectsInGame.Add(ForPlayer);
            Tank Bot = null;
            for (int i = 0; i < CountTanks - 1; i++)
            {
                switch (Utils.GetRandom.Next(1,3))
                {
                    case 1:
                        Def.Construct();
                        Bot = D.GetResult();
                        break;
                    case 2:
                        Att.Construct();
                        Bot = A.GetResult();
                        break;
                }
                StaticObjectsInGame.Add(Bot);
                DamagableObjectsInGame.Add(Bot);
            }

            for (int i = 0; i < CountObstacles; i++)
            {
                Obstacles MyObstacle = null;
                switch (Utils.GetRandom.Next(1, 3))
                {
                    case 1:
                        MyObstacle = new UnDestructibleObstacle(Utils.GetRandom.Next(1, 26), Utils.GetRandom.Next(1, 26)); // рандомная или конкретная координата на поле
                        break;
                    case 2:
                        MyObstacle = new DestructibleObstacle(Utils.GetRandom.Next(1, 26), Utils.GetRandom.Next(1, 26)); // рандомная или конкретная координата на поле
                        DamagableObjectsInGame.Add((IDamagable)MyObstacle);
                        break;
                }
                StaticObjectsInGame.Add(MyObstacle);
            }

            for (int i = 0; i < CountArtifacts; i++)
            {
                Artifact MyArt = null;
                switch (Utils.GetRandom.Next(1, 4))
                {
                    case 1:
                        MyArt = new RepairKit(Utils.GetRandom.Next(1, 26), Utils.GetRandom.Next(1, 26)); // рандомная или конкретная координата на поле
                        break;
                    case 2:
                        MyArt = new IncreaseDamage(Utils.GetRandom.Next(1, 26), Utils.GetRandom.Next(1, 26)); // рандомная или конкретная координата на поле
                        break;
                    case 3:
                        MyArt = new IncreaseRange(Utils.GetRandom.Next(1, 26), Utils.GetRandom.Next(1, 26)); // рандомная или конкретная координата на поле
                        break;
                }
                StaticObjectsInGame.Add(MyArt);
            }

            for (int i = 0; i < CountCartridges; i++)
            {
                CartridgeOnField MyCart = null;
                switch (Utils.GetRandom.Next(1, 4))
                {
                    case 1:
                        MyCart = new CartridgeOnField(Cartridge.TypeOfCartridges.Light, 20, 4, Utils.GetRandom.Next(1, 26), Utils.GetRandom.Next(1, 26), ImagesForGame.GetLightShell);
                        break;
                    case 2:
                        MyCart = new CartridgeOnField(Cartridge.TypeOfCartridges.Medium, 25, 4, Utils.GetRandom.Next(1, 26), Utils.GetRandom.Next(1, 26), ImagesForGame.GetMediumShell); 
                        break;
                    case 3:
                        MyCart = new CartridgeOnField(Cartridge.TypeOfCartridges.Heavy, 30, 4, Utils.GetRandom.Next(1, 26), Utils.GetRandom.Next(1, 26), ImagesForGame.GetHeavyShell); 
                        break;
                }
                StaticObjectsInGame.Add(MyCart);
            }
        }

        public static Game ReturnInstance()
        {
            return instance;
        }

        private void CreateObservers()
        {
            Tank Buf;
            foreach (IObjectsOnField t in StaticObjectsInGame)
                if (t is Tank)
                {
                    Buf = (Tank)t;
                    Buf.AddObserver(instance);
                }
        }

        public static Game Initialize(int CountTanks, int CountObstacles, int CountCartridges, int CountArtifacts)
        {
            if (instance == null)
                instance = new Game(CountTanks, CountObstacles, CountCartridges, CountArtifacts);
            instance.CreateObservers();
            return instance;
        }

        public void UpdateMove(Tank ob, Tank.Direction dir)
        {
            ob.Move(dir);
        }

        public void UpdateShoot(Tank ob) // типа как делегат
        {
            ob.Shoot();
        }
    }
}
