using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomControls;

namespace Agent
{
    public partial class KnowledgeBase
    {
        int width;
        int height;
        Position AgentPosition;
        WorldImageContainer WIC;

        public KnowledgeBase(int BoardWidth, int BoardHeight,
            int WumpusCount, int HoleCount,
            bool Breeze, bool Stench, bool Glitter)
        {
            width = BoardWidth;
            height = BoardHeight;
            AgentPosition = new Position(0, 0, width, height);
            WIC = new WorldImageContainer(width, height, WumpusCount, HoleCount);
            WIC.SetExplored(0, 0, Breeze, Stench, Glitter);
        }

        public void Move(Direction dir, bool Breeze, bool Stench, bool Glitter)
        {
            AgentPosition = AgentPosition.Move(dir);
            WIC.SetExplored(AgentPosition.X, AgentPosition.Y, Breeze, Stench, Glitter);
        }

        public Direction BestMove()
        {
            if (WIC.GoldFound)
                return DirectionToShortestExit();
            Direction? d = null;
            var GoodMoves = WIC.SafestPlaces;
            List<Position> Unreachable = new List<Position>();
            while (GoodMoves.Count != 0 && (d = AStarSearchDoOdredista(GoodMoves)) == null)
            {
                Unreachable.AddRange(GoodMoves);
                GoodMoves = WIC.SafestPlacesExcept(Unreachable);
            }
            if (d != null)
                return d.Value;
            return Direction.Up;
        }

        private Direction DirectionToShortestExit()
        {
            if (AgentPosition.X == 0 && AgentPosition.Y == 0)
                return Direction.Down;
            return AStarSearchDoOdredista(new List<Position> {
                new Position(0, 0, width, height) }).Value;
        }
    }
}
