using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;

namespace InvadersProto7
{

    class Enemy
    {
        char enemy = 'W';
        int enemyHP = 5;
        int enemyPosX = 3, enemyPosY = 1;

        public Enemy()
        {

        }
    }
    public class Program
    {
        static char player = 'M';
        static char space = '*';
        public static int gridLenght = 10, gridHeight = 10;
        public static int playerPosX = 2, playerPosY = 2;
        static bool gameRunning = true;


        static void Main(string[] args)
        {
            InitiateGame();
            Rungame();
        }

        private static void InitiateGame()
        {
            int enemyCount = 5;
            for (int i = 0; i <= enemyCount; ++i)
            {
                new Enemy();
            }
        }

        public static void Rungame()
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            while (gameRunning)
            {
                DrawGame();
                PlayerInput();

                //norpat från gitdemot
                // ----- begränsa programmet till x gånger per sekund (FPS) ----- 
                int ms_per_frame = 33; // 30 FPS
                if (timer.ElapsedMilliseconds < ms_per_frame)
                {
                    int time_left = ms_per_frame - (int)timer.ElapsedMilliseconds;
                    if (time_left > 0)
                        Thread.Sleep(time_left);
                }
                timer.Restart();
            }
        }

        public static void PlayerInput()
        {
            while (Console.KeyAvailable)
            {
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.A)
                    playerPosX = -1;
                if (key.Key == ConsoleKey.D)
                    playerPosX = 1;
                if (key.Key == ConsoleKey.Escape)
                    gameRunning = false;
                if (key.Key == ConsoleKey.Spacebar)
                    new PlayerShoot();

            }
        }



        public static void DrawGame()
        {
            Console.Clear();
            //char projectile = PlayerShoot.projectile;
            for (int y = 0; y <= gridHeight; ++y)
            {
                for (int x = 0; x <= gridLenght; ++x)
                {
                    if (x == playerPosX && y == playerPosY)
                    {
                        Console.Write(player);
                    }
                    else if (x == ; && y == PlayerShoot.projectilePosY)
                    {
                        Console.Write(PlayerShoot.projectile);
                    }
                    else
                    {
                        Console.Write(space);
                    }
                }
                Console.WriteLine();
            }
        }
    }

    public class PlayerShoot
    {
       public List<PlayerShoot> listOfProjectiles = new List<PlayerShoot>();

        public int projectilePosX = 0, projectilePosY = 0;
        public  static char projectile = 'I';

        public PlayerShoot()
        {
            listOfProjectiles.Add(this);
            this.projectilePosX = Program.playerPosX;
            this.projectilePosY = Program.playerPosY + 1;

            if (projectilePosX >= Program.gridLenght || projectilePosY >= Program.gridHeight) // ||kollision med fiende
            {
                listOfProjectiles.Remove(this);
            }
        }
    }
}
