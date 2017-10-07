using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarterProject.Web.Api;

namespace Harembis
{
    public class QuickMine
    {
        static public string Mine(GameInfo gameInfo, Tile[,] map)
        {
            Point toCollect = null;
            Point player = gameInfo.Player.Position;
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (map[i, j].C == (Byte)TileContent.Resource)
                    {
                        toCollect = new Point(map[i, j].X, map[i, j].Y);
                    }

                }
            }
            if (mineInRange(gameInfo, map) && toCollect != null)
                return AIHelper.CreateCollectAction(toCollect);
            int x = 0;
            if (toCollect.X != player.X)
                x = (int)((toCollect.X - player.X) / MathF.Abs(toCollect.X - player.X));
            int y = 0;
            if (x == 0 && toCollect.Y != player.Y)
                y = (int)((toCollect.Y - player.Y) / MathF.Abs(toCollect.Y - player.Y));

            return AIHelper.CreateMoveAction(new Point(player.X + x, player.Y + y));
        }

        static public string GoHome(GameInfo gameInfo, Tile[,] map)
        {
            Point player = gameInfo.Player.Position;
            Point house = gameInfo.Player.HouseLocation;
            int x = 0;
            if (house.X != player.X)
                x = (int)((house.X - player.X) / MathF.Abs(house.X - player.X));
            int y = 0;
            if (x == 0 && house.Y != player.Y)
                y = (int)((house.Y - player.Y) / MathF.Abs(house.Y - player.Y));

            return AIHelper.CreateMoveAction(new Point(player.X + x, player.Y + y));
        }

        static bool mineInRange(GameInfo gameInfo, Tile[,] map)
        {
            Point player = new Point(10, 10);
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (map[player.X + j, player.Y + i].C == (byte)TileContent.Resource)
                        return true;
                }
            }
            return false;
        }

        static public void CoutMap(Tile[,] map)
        {
            Console.Write('\n');
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    switch (map[i, j].C)
                    {
                        case (Byte)TileContent.Empty:
                            Console.Write('-');
                            break;
                        case (Byte)TileContent.House:
                            Console.Write('H');
                            break;
                        case (Byte)TileContent.Lava:
                            Console.Write('L');
                            break;
                        case (Byte)TileContent.Player:
                            Console.Write('P');
                            break;
                        case (Byte)TileContent.Resource:
                            Console.Write('R');
                            break;
                        case (Byte)TileContent.Shop:
                            Console.Write('S');
                            break;
                        case (Byte)TileContent.Wall:
                            Console.Write('/');
                            break;
                        default:
                            Console.Write('F');
                            break;
                    }
                }
                Console.Write('\n');
            }
            Console.Write('\n');
        }
    }
}
