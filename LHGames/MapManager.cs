using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarterProject.Web.Api;

namespace Harembis
{
    public class MapManager
    {
        public MapManager(GameInfo gameInfo, Tile[,] map)
        {
            gameInfo_ = gameInfo;
            map_ = map;
            player = gameInfo_.Player.Position;
        }
        public bool isHome()
        {
            return (gameInfo_.Player.Position == gameInfo_.Player.HouseLocation);
        }
        public bool isAdjacent(Point point)
        {
            return ((MathF.Abs(player.X - point.X) == 1) ^ (MathF.Abs(player.Y - point.Y) == 1));
        }
        public string getCloser(Point point)
        {
            int x = 0;
            if (point.X != player.X)
                x = (int)((point.X - player.X) / MathF.Abs(point.X - player.X));
            int y = 0;
            if (x == 0 && point.Y != player.Y)
                y = (int)((point.Y - player.Y) / MathF.Abs(point.Y - player.Y));

            return AIHelper.CreateMoveAction(new Point(player.X + x, player.Y + y));
        }
        public string getCloser(TileType type)
        {
            Point toCollect = player;
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (map_[i, j].C == (Byte)type)
                    {
                        toCollect = new Point(map_[i, j].X, map_[i, j].Y);
                    }

                }
            }
            return getCloser(toCollect);
        }

        public float getDistance(Point point)
        {
            return MathF.Sqrt(MathF.Pow(point.X - player.X, 2) + MathF.Pow(point.Y - player.Y, 2));
        }

        GameInfo gameInfo_;
        Tile[,] map_;
        Point player;

    }
}
