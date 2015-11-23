using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using CustomControls;

namespace Agent
{
    class WorldImageContainer
    {
        bool goldFound;
        int width;
        int height;
        int wumpusCount;
        int holeCount;
        List<WorldImage> Images;
        float[,] HoleProbabilities;
        float[,] WumpusProbabilities;
        bool[,] SquareUnknown;
        bool[,] SquareExplored;
        int unknownCount;

        public bool GoldFound
        {
            get { return goldFound; }
        }

        public WorldImageContainer(int Width, int Height, int WumpusCount, int HoleCount)
        {
            width = Width;
            height = Height;
            wumpusCount = WumpusCount;
            holeCount = HoleCount;

            unknownCount = width * height;

            HoleProbabilities = new float[width, height];
            WumpusProbabilities = new float[width, height];
            SquareUnknown = new bool[width, height];
            SquareExplored = new bool[width, height];

            for(int i=0;i<width;i++)
                for (int j = 0; j < height; j++)
                {
                    HoleProbabilities[i, j] = 0;
                    WumpusProbabilities[i, j] = 0;
                    SquareExplored[i, j] = false;
                    SquareUnknown[i, j] = true;
                }

            Images = new List<WorldImage>();
            Images.Add(new WorldImage(width, height));
        }

        public void SetExplored(int X, int Y, bool Breeze, bool Stench, bool Glitter)
        {
            //If the agent was on that square
            //no new evidence will be found
            if (SquareExplored[X, Y])
                return;
            if (Glitter)
                goldFound = true;
            //if there exists a chance that some world images
            //have a threat at specified position, they need to be removed
            if (!SquareUnknown[X, Y])
            {
                //check if there are some world images
                //with a wumpus on that position
                if (WumpusProbabilities[X, Y] != 0F)
                    //removing them
                    Images.RemoveAll(img => img.GetIsWumpus(X, Y));
                //check if there are some world images
                //with a hole on that position
                if (HoleProbabilities[X, Y] != 0F)
                    //removing them
                    Images.RemoveAll(img => img.GetIsHole(X, Y));
            }
            //telling all worlds that the square is secure and explored
            Images.ForEach(img => img.SetExplored(X, Y));
            SquareExplored[X, Y] = true;
            if (SquareUnknown[X, Y])
            {
                SquareUnknown[X, Y] = false;
                unknownCount--;
            }
            else
            {
                HoleProbabilities[X, Y] = 0F;
                WumpusProbabilities[X, Y] = 0F;
            }

            //get all neighbour fileds
            var p = new Position(X, Y, width, height);
            var NeighbourFields = p.Neighbours;

            //if there is no stench, all world images with a
            //wumpus on a neighbour field are invalid
            if (!Stench)
                foreach (var f in NeighbourFields)
                    if (!SquareUnknown[f.X, f.Y] && WumpusProbabilities[f.X, f.Y] != 0F)
                    {
                        Images.RemoveAll(img => img.GetIsWumpus(f.X, f.Y));
                        WumpusProbabilities[f.X, f.Y] = 0F;
                    }
            //if there is no breeze, all world images with a
            //wumpus on a neighbour field are invalid
            if (!Breeze)
                foreach (var f in NeighbourFields)
                    if (!SquareUnknown[f.X, f.Y] && HoleProbabilities[f.X, f.Y] != 0F)
                    {
                        Images.RemoveAll(img => img.GetIsHole(f.X, f.Y));
                        HoleProbabilities[f.X, f.Y] = 0F;
                    }

            //Splitting the world images
            List<WorldImage> NewImageList = new List<WorldImage>();
            WorldImage NewImage;
            //for every neighbour field set all possibilities
            foreach (var f in NeighbourFields)
            {
                //only unknown fields are considered
                if (SquareUnknown[f.X, f.Y])
                {
                    //if breeze is felt, they could be holes
                    if (Breeze)
                    {
                        foreach (var img in Images)
                        {
                            //only if more holes can be put on the world
                            if (img.HoleCount < holeCount)
                            {
                                NewImage = new WorldImage(img);
                                NewImage.SetSquare(f.X, f.Y, false, true);
                                NewImageList.Add(NewImage);
                            }
                        }
                        //random number between 0 and 1.
                        HoleProbabilities[f.X, f.Y] = 0.5F;
                    }
                    //if stench is felt, they could be wumpuses
                    if (Stench)
                    {
                        foreach (var img in Images)
                        {
                            //only if more wumpuses can be put on the world
                            if (img.WumpusCount < wumpusCount)
                            {
                                NewImage = new WorldImage(img);
                                NewImage.SetSquare(f.X, f.Y, true, false);
                                NewImageList.Add(NewImage);
                            }
                        }
                        //random number between 0 and 1.
                        WumpusProbabilities[f.X, f.Y] = 0.5F;
                    }
                    foreach (var img in Images)
                        img.SetSquare(f.X, f.Y, false, false);
                    //the neighbour field is no longer unknnown in any world images
                    SquareUnknown[f.X, f.Y] = false;
                    unknownCount--;

                    //merge the old and new list
                    Images.AddRange(NewImageList);
                    //clean list for next round
                    NewImageList.Clear();
                }
            }

            //If breeze is felt, remove all world images
            //which have no hole in the surrounding fields
            if (Breeze)
            {
                //check if some of the neighbour fields is surely a hole
                bool hasSureHole = false;
                foreach (var f in NeighbourFields)
                    if (HoleProbabilities[f.X, f.Y] == 1F)
                    {
                        hasSureHole = true;
                        break;
                    }
                //there is no sure hole
                if (!hasSureHole)
                {
                    //take neighbour field which could be holes
                    var CouldBeHoles = NeighbourFields.Where(f =>
                        HoleProbabilities[f.X, f.Y] != 0F);
                    //remove all worlds where non of them is a hole
                    Images.RemoveAll(img =>
                    {
                        foreach (var possiblePosition in CouldBeHoles)
                            if (img.GetIsHole(possiblePosition.X, possiblePosition.Y))
                                return false;
                        return true;
                    });
                }
            }

            //If stench is felt, remove all world images
            //which have no wumpus in the surrounding fields
            if (Stench)
            {
                //check if some of the neighbour fields is surely a wumpus
                bool hasSureWumpus = false;
                foreach (var f in NeighbourFields)
                    if (WumpusProbabilities[f.X, f.Y] == 1F)
                    {
                        hasSureWumpus = true;
                        break;
                    }
                //there is no sure wumpus
                if (!hasSureWumpus)
                {
                    //take neighbour field which could be a wumpus
                    var CouldBeWumpus = NeighbourFields.Where(f =>
                        WumpusProbabilities[f.X, f.Y] != 0F);
                    //remove all worlds where non of them is a wumpus
                    Images.RemoveAll(img =>
                    {
                        foreach (var possiblePosition in CouldBeWumpus)
                            if (img.GetIsWumpus(possiblePosition.X, possiblePosition.Y))
                                return false;
                        return true;
                    });
                }
            }

            //the minimum number of holes and wumpuses
            //to satisfy all conditions has increased
            //if the number of holes or wumpuses in a world image is to small
            //they can not satisfy all conditions
            if (minThreadCount > 0)
                Images.RemoveAll(img => img.HoleCount + img.WumpusCount < minThreadCount);

            //refreshing the general data
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                {
                    //if the square is unknown or explored, are world images
                    //are telling the same.
                    if (SquareUnknown[i, j] || SquareExplored[i, j])
                        continue;
                    //if there wurely was a hole before
                    //there is it surely now.
                    //Nothing changed for this square
                    if (HoleProbabilities[i, j] == 1F)
                        continue;
                    //if there wurely was a wumpus before
                    //there is it surely now.
                    //Nothing changed for this square
                    if (WumpusProbabilities[i, j] == 1F)
                        continue;
                    //if there could be a hole before
                    //find the new probability
                    if (HoleProbabilities[i, j] != 0F)
                        HoleProbabilities[i, j] = this.GetHoleRatio(i, j);
                    //if there could be a wumpus before
                    //find the new probability
                    if (WumpusProbabilities[i, j] != 0F)
                        WumpusProbabilities[i, j] = this.GetWumpusRatio(i, j);
                }
        }

        public bool IsSafe(int X, int Y)
        {
            if (SquareUnknown[X,Y])
                return false;
            if (HoleProbabilities[X, Y] != 0F)
                return false;
            if (WumpusProbabilities[X, Y] != 0F)
                return false;
            return true;
        }

        public List<Position> SafestPlaces
        {
            get
            {
                var Positions = new List<Position>();
                float BestSafety = 0F;
                float Safety;
                for (int i = 0; i < width; i++)
                    for (int j = 0; j < height; j++)
                    {
                        if (SquareUnknown[i, j] || SquareExplored[i, j])
                            continue;
                        Safety = 1 - HoleProbabilities[i, j] - WumpusProbabilities[i, j];
                        if (Safety < BestSafety)
                            continue;
                        if (Safety > BestSafety)
                        {
                            Positions.Clear();
                            BestSafety = Safety;
                        }
                        Positions.Add(new Position(i, j, width, height));
                    }
                return Positions;
            }
        }

        public List<Position> SafestPlacesExcept(List<Position> Exceptions)
        {
                var Positions = new List<Position>();
                float BestSafety = 0F;
                float Safety;
                for (int i = 0; i < width; i++)
                    for (int j = 0; j < height; j++)
                    {
                        if (SquareUnknown[i, j] || SquareExplored[i, j])
                            continue;
                        if (Exceptions.Any(p => p.X == i && p.Y == j))
                            continue;
                        Safety = 1 - HoleProbabilities[i, j] - WumpusProbabilities[i, j];
                        if (Safety < BestSafety)
                            continue;
                        if (Safety > BestSafety)
                        {
                            Positions.Clear();
                            BestSafety = Safety;
                        }
                        Positions.Add(new Position(i, j, width, height));
                    }
                return Positions;
        }

        int minThreadCount
        {
            get
            {
                if (goldFound)
                    return wumpusCount + holeCount - unknownCount;
                else
                    return wumpusCount + holeCount + 1 - unknownCount;
            }
        }

        float GetHoleRatio(int X, int Y)
        {
            BigInteger Weight;
            BigInteger SecureWeight = BigInteger.Zero;
            BigInteger TotalWeight = BigInteger.Zero;
            foreach (var img in Images)
            {
                Weight = GetWeight(img);
                TotalWeight += Weight;
                if (img.GetIsHole(X, Y))
                    SecureWeight += Weight;
            }
            if (TotalWeight == BigInteger.Zero)
                return 0F;
            return ((float)((SecureWeight*10000)/TotalWeight))/10000;
        }

        float GetWumpusRatio(int X, int Y)
        {
            BigInteger Weight;
            BigInteger SecureWeight = BigInteger.Zero;
            BigInteger TotalWeight = BigInteger.Zero;
            foreach (var img in Images)
            {
                Weight = GetWeight(img);
                TotalWeight += Weight;
                if (img.GetIsWumpus(X, Y))
                    SecureWeight += Weight;
            }
            if (TotalWeight == 0L)
                return 0F;
            return ((float)((SecureWeight*10000) / TotalWeight))/10000;
        }

        BigInteger GetWeight(WorldImage Image)
        {
            BigInteger weight = BigInteger.One;
            int N = unknownCount;
            // possible gold positions
            if (!goldFound)
            {
                weight *= NChoooseK.Get(N, 1);
                N--;
            }
            // possible wumpus positions
            weight *= NChoooseK.Get(N, wumpusCount - Image.WumpusCount);
            N -= wumpusCount - Image.WumpusCount;
            // possible hole counts
            weight *= NChoooseK.Get(N, holeCount - Image.HoleCount);
            return weight;
        }

        class WorldImage
        {
            int width;
            int height;
            int wumpusCount;
            int holeCount;
            private enum SquareImage
            {
                Unknown,
                Wumpus,
                Hole,
                Explored,
                Secure
            }
            SquareImage[,] Squares;

            public WorldImage(int Width, int Height)
            {
                width = Width;
                height = Height;
                wumpusCount = 0;
                holeCount = 0;
                Squares = new SquareImage[width, height];
                for (int i = 0; i < width; i++)
                    for (int j = 0; j < height; j++)
                        Squares[i, j] = SquareImage.Unknown;
            }

            public WorldImage(WorldImage Image)
            {
                width = Image.width;
                height = Image.height;
                wumpusCount = Image.wumpusCount;
                holeCount = Image.holeCount;
                Squares = new SquareImage[width, height];
                for (int i = 0; i < width; i++)
                    for (int j = 0; j < height; j++)
                        Squares[i, j] = Image.Squares[i,j];
            }

            public void SetSquare(int X, int Y, bool IsWumpus, bool IsHole)
            {
                if(Squares[X,Y]!= SquareImage.Unknown)
                    throw new Exception("Prepisivanje polja.");
                if(IsWumpus&&IsHole)
                    throw new Exception("U slici svijeta ne moze biti i Wumpus i rupa.");
                if (IsWumpus)
                {
                    wumpusCount++;
                    Squares[X, Y] = SquareImage.Wumpus;
                    return;
                }
                if (IsHole)
                {
                    holeCount++;
                    Squares[X, Y] = SquareImage.Hole;
                    return;
                }
                Squares[X, Y] = SquareImage.Secure;
            }

            public void SetExplored(int X, int Y)
            {
                if (Squares[X, Y] != SquareImage.Secure
                    && Squares[X,Y] != SquareImage.Unknown)
                    throw new Exception("Otkrivanje polja s opasnosti");
                Squares[X, Y] = SquareImage.Explored;
            }

            public bool GetIsSecure(int X, int Y)
            {
                return Squares[X, Y] == SquareImage.Secure;
            }

            public bool GetIsExplored(int X, int Y)
            {
                return Squares[X, Y] == SquareImage.Explored;
            }

            public bool GetIsUnknown(int X, int Y)
            {
                return Squares[X, Y] == SquareImage.Unknown;
            }

            public bool GetIsHole(int X, int Y)
            {
                return Squares[X, Y] == SquareImage.Hole;
            }

            public bool GetIsWumpus(int X, int Y)
            {
                return Squares[X, Y] == SquareImage.Wumpus;
            }

            public int WumpusCount
            {
                get { return wumpusCount; }
            }

            public int HoleCount
            {
                get { return holeCount; }
            }
        }

        static class NChoooseK
        {
            static List<BigInteger[]> L = new List<BigInteger[]>();

            public static BigInteger Get(int N, int K)
            {
                if (K > (N >> 1))
                    K = N - K;
                if (K < 0)
                    return 0L;
                if (N >= L.Count)
                    while (L.Count <= N)
                    {
                        int size = (L.Count >> 1) + 1;
                        var arr = new BigInteger[size];
                        arr[0] = BigInteger.One;
                        if (size > 1)
                            arr[1] = L.Count;
                        for (int i = 2; i < size; i++)
                            arr[i] = BigInteger.MinusOne;
                        L.Add(arr);
                    }
                if (L[N][K].Sign == -1)
                    L[N][K] = Get(N - 1, K) + Get(N - 1, K - 1);
                return L[N][K];
            }
        }
    }
}
