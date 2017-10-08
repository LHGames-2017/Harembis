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
        public bool isAdjacent(TileType type)
        {
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (map_[10 + j, 10 + i].C == (byte)type)
                    {
                        tmp = new Point(map_[10 + j, 10 + i].X, map_[10 + j, 10 + i].Y);
                        return true;
                    }
                }
            }
            return false;
        }
        public string getCloser(Point point)
        {
            int x = 0;
            if (point.X != player.X)
                x = (int)((point.X - player.X) / MathF.Abs(point.X - player.X));
            int y = 0;
            if (x == 0 && point.Y != player.Y)
                y = (int)((point.Y - player.Y) / MathF.Abs(point.Y - player.Y));

            Point nPoint = new Point(player.X + x, player.Y + y);
            Point nextPoint = pointToMap(nPoint);
            switch ((TileType)map_[nextPoint.Y, nextPoint.X].C)
            {
                case TileType.W:
                    return AIHelper.CreateAttackAction(nPoint);
                case TileType.L:
                    Point p = new Point(player.X + 1, player.Y);
                    if (canMove(p))
                        return getCloser(p);
                    p = new Point(player.X, player.Y+1);
                    if (canMove(p))
                        return getCloser(p);
                    p = new Point(player.X, player.Y - 1);
                    if (canMove(p))
                        return getCloser(p);
                    p = new Point(player.X - 1, player.Y);
                    if (canMove(p))
                        return getCloser(p);
                    break;
                case TileType.R:
                    mine();
                    break;
            }
            return AIHelper.CreateMoveAction(nPoint);
        }

        public bool canMove(Point point)
        {
            Point nPoint = new Point(player.X + point.X, player.Y + point.Y);
            Point nextPoint = pointToMap(nPoint);
            switch ((TileType)map_[nextPoint.Y, nextPoint.X].C)
            {
                case TileType.L:
                    return false;
                case TileType.R:
                    return false;
                case TileType.S:
                    return false;
                default:
                    return true;
            }
            {
                
            }
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

        public string mine()
        {
            if (isAdjacent(TileType.R))
            {
                return AIHelper.CreateCollectAction(tmp);
            }
            else
                return getCloser(TileType.R);
        }

        public string GoHome()
        {
            return getCloser(gameInfo_.Player.HouseLocation);
        }

        public Point pointToMap(Point point)
        {
            int x = point.X - player.X + 10;
            int y = point.Y - player.Y + 10;
            if (x < 0)
                x = 0;
            else if (x > 20)
                x = 20;
            if (y < 0)
                y = 0;
            else if (y > 20)
                y = 20;
            return new Point(x, y);
        }

        public Point mapToPoint(Point point)
        {
            return new Point(point.X, point.Y);
        }
        GameInfo gameInfo_;
        Tile[,] map_;
        Point player;
        Point tmp;

    }
}
