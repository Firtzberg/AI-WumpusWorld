using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomControls
{
    public class Position
    {
        int x;
        int y;
        int maxX;
        int maxY;

        public Position(int X, int Y, int MaxX, int MaxY)
        {
            if (X > MaxX - 1)
                X = MaxX - 1;
            if (Y > MaxY - 1)
                Y = MaxY - 1;
            if (X < 0)
                X = 0;
            if (Y < 0)
                Y = 0;
            x = X;
            y = Y;
            maxX = MaxX;
            maxY = MaxY;

        }

        public int X
        {
            get { return x; }
        }

        public int Y
        {
            get { return y; }
        }

        public int MaxX
        {
            get { return maxX; }
        }

        public int MaxY
        {
            get { return maxY; }
        }

        public Position Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Down:
                    return new Position(x, y - 1, maxX, maxY);
                case Direction.Left:
                    return new Position(x - 1, y, maxX, maxY);
                case Direction.Right:
                    return new Position(x + 1, y, maxX, maxY);
                default:
                    return new Position(x, y + 1, maxX, maxY);
            }
        }

        public static bool operator ==(Position first, Position second)
        {
            if (System.Object.ReferenceEquals(first, second))
                return true;
            if (((object)first == null) || ((object)second == null))
                return false;
            return first.x == second.x && first.y == second.y;
        }

        public static bool operator !=(Position first, Position second)
        {
            return !(first==second);
        }

        public IEnumerable<Position> Neighbours
        {
            get
            {
                var Directions = new List<Direction>{
                    Direction.Down,
                    Direction.Left,
                    Direction.Right,
                    Direction.Up
                };
                var N = new List<Position>(4);
                Position np;
                foreach (var d in Directions)
                {
                    np = this.Move(d);
                    if (np != this)
                        N.Add(np);
                }
                return N;
            }
        }
    }

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
}
