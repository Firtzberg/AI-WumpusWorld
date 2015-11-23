using System;
using System.Collections.Generic;
using System.Linq;
using CustomControls;

namespace Agent
{
    partial class KnowledgeBase
    {
        private Direction? AStarSearchDoOdredista(List<Position> Odredista)
        {
            if(Odredista.Count == 0)
                return null;
            List<Putanja> Popis = new List<Putanja>();
            Position New;
            Direction[] Directions = new Direction[] { Direction.Down,
                Direction.Left, Direction.Right, Direction.Up };
            var ProsliPolozaji = new List<Position> { AgentPosition };
            foreach (var d in Directions)
            {
                New = AgentPosition.Move(d);
                if (New != AgentPosition)
                {
                    new Putanja(d, New.X, New.Y, Odredista)
                        .AddToSortedList(Popis);
                    ProsliPolozaji.Add(New);
                }
            }
            Putanja stanje = Popis.First();
            Popis.Remove(stanje);
            while (!stanje.Stigao)
            {
                if(WIC.IsSafe(stanje.Polozaj.X, stanje.Polozaj.Y))
                    foreach (var d in Directions)
                    {
                        New = stanje.Polozaj.Move(d);
                        if (!ProsliPolozaji.Exists(x => x == New))
                        {
                            new Putanja(stanje, d).AddToSortedList(Popis);
                            ProsliPolozaji.Add(New);
                        }
                    }
                if (Popis.Count == 0)
                    return null;
                stanje = Popis.First();
                Popis.Remove(stanje);
            }
            return stanje.PrviKorak;
        }

        private class Putanja : IComparable<Putanja>
        {
            Direction prviKorak;
            int ukupnoKoraka;
            public Position Polozaj;
            List<Position> odredista;
            int? tezinska;

            public Putanja(Direction PrviKorak, int XNakonKoraka, int YNakonKoraka,
                List<Position> Odredista)
            {
                if (Odredista == null || Odredista.Count == 0)
                    return;
                prviKorak = PrviKorak;
                Polozaj = new Position(XNakonKoraka, YNakonKoraka, Odredista.First().MaxX, Odredista.First().MaxY);
                ukupnoKoraka = 1;
                odredista = Odredista;
                tezinska = null;
            }

            public Putanja(Putanja stara, Direction d)
            {
                prviKorak = stara.prviKorak;
                Polozaj = stara.Polozaj.Move(d);
                ukupnoKoraka = stara.ukupnoKoraka + 1;
                odredista = stara.odredista;
            }

            public Direction PrviKorak
            {
                get { return prviKorak; }
            }

            public bool Stigao
            {
                get { return TezinskaFunkcija() == 0; }
            }

            int TezinskaFunkcija()
            {
                if (tezinska != null)
                    return tezinska.Value;
                tezinska =  odredista.Select(p =>
                {
                    int a = p.X - Polozaj.X;
                    if (a < 0) a = -a;
                    int b = p.Y - Polozaj.Y;
                    if (b < 0)
                        a -= b;
                    else a += b;
                    return a;
                }).Min();
                return tezinska.Value;
            }

            public int Heuristika()
            {
                return TezinskaFunkcija() + ukupnoKoraka;
            }

            public int CompareTo(Putanja druga)
            {
                return this.Heuristika().CompareTo(druga.Heuristika());
            }

            public void AddToSortedList(List<Putanja> L)
            {
                int i = this.Heuristika();
                i = L.FindIndex(x => x.Heuristika() >= i);
                if (i < 0)
                    L.Add(this);
                else L.Insert(i, this);
            }
        }
    }
}
