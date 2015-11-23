using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CustomControls
{
    public partial class WumpusWorldBoard : Panel
    {
        private WumpusWorldSquare[,] Squares;
        private Position AgentPosition;
        private int moves;
        private int columns;
        private int rows;
        private int wumpusCount;
        private int holeCount;
        private bool AgentAlive;
        private bool GoldFound;
        private bool keyInputEnabled;
        private int squareDimension;
        public event EventHandler<GameEndedEventArgs> GameEnded;
        public event EventHandler<AgentMovedEventArgs> AgentMoved;
        public event EventHandler GoldFoundEH;

        public WumpusWorldBoard()
        {
            this.SetStyle(ControlStyles.Selectable, true);
            InitializeComponent();
            this.squareDimension = 80;
            moves = 0;
            Reset(4, 4, 1, 3);
            this.KeyDown += new KeyEventHandler(this.BoardKeyDown);
        }

        protected virtual void OnAgentMoved(AgentMovedEventArgs e)
        {
            EventHandler<AgentMovedEventArgs> eh = this.AgentMoved;
            if (eh != null)
                eh(this, e);
        }

        protected virtual void OnGoldFound(EventArgs e)
        {
            EventHandler eh = this.GoldFoundEH;
            if (eh != null)
                eh(this, e);
        }

        protected virtual void OnGameEnded(GameEndedEventArgs e)
        {
            EventHandler<GameEndedEventArgs> eh = this.GameEnded;
            if (eh != null)
                eh(this, e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            this.Focus();
            base.OnMouseDown(e);
        }

        protected override bool IsInputKey(Keys keyData)
        {
            if (!keyInputEnabled) return false;
            if (keyData == Keys.Up || keyData == Keys.Down) return true;
            if (keyData == Keys.W || keyData == Keys.S) return true;
            if (keyData == Keys.Left || keyData == Keys.Right) return true;
            if (keyData == Keys.A || keyData == Keys.D) return true;
            return base.IsInputKey(keyData);
        }

        protected void SquareMouseDown(object sender, MouseEventArgs e)
        {
            this.OnMouseDown(e);
        }

        public int Moves
        {
            get { return moves; }
        }

        public int AgentPositionX
        {
            get { return AgentPosition.X; }
        }

        public int AgentPositionY
        {
            get { return AgentPosition.Y; }
        }

        public void Reset(
            int Rows,
            int Columns,
            int WumpusCount,
            int HoleCount)
        {
            this.SuspendLayout();
            this.Controls.Clear();
            rows = Rows;
            columns = Columns;
            wumpusCount = WumpusCount;
            holeCount = HoleCount;
            AgentPosition = new Position(0, 0, rows, columns);
            AgentAlive = true;
            GoldFound = false;
            if (rows < 1 || columns < 1 || (Rows == 1 && Columns == 1))
                throw new ArgumentOutOfRangeException();
            if (rows * columns < 2 + wumpusCount + holeCount)
                throw new ArgumentException();
            Squares = new WumpusWorldSquare[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    WumpusWorldSquare Sq = new WumpusWorldSquare();
                    Sq.MouseDown += new MouseEventHandler(this.SquareMouseDown);
                    Squares[i, j] = Sq;
                    this.Controls.Add(Sq);
                }
            }

            System.Random r = new Random();
            int x, y, fields;
            //Proizvoljan odabir položaja blaga
            int Number = r.Next() % (rows * columns - 1) + 1;
            Squares[Number % rows, Number / rows].Glitter = true;

            //Postavljanje Wumpusa na različita mjesta
            fields = rows * columns - 2;
            for (int i = 1; i < rows * columns&& WumpusCount > 0; i++)
            {
                x = i % rows;
                y = i / rows;
                if (Squares[x, y].Glitter)
                    continue;
                Number = r.Next() % (fields);
                fields--;
                if (Number < WumpusCount)
                {
                    Squares[x, y].IsWumpus = true;
                    //Postavljanje zadaha na odgovarajuća mjesta
                    Squares[x, y].Stench = true;
                    if (x > 0)
                        Squares[x - 1, y].Stench = true;
                    if (x < rows - 1)
                        Squares[x + 1, y].Stench = true;
                    if (y > 0)
                        Squares[x, y - 1].Stench = true;
                    if (y < columns - 1)
                        Squares[x, y + 1].Stench = true;
                    WumpusCount--;
                }
            }

            fields = rows * columns - 2 - wumpusCount;
            for (int i = 1; i < rows * columns && HoleCount > 0; i++)
            {
                x = i % rows;
                y = i / rows;
                if (Squares[x, y].Glitter || Squares[x, y].IsWumpus)
                    continue;
                Number = r.Next() % (fields);
                fields--;
                if (Number < HoleCount)
                {
                    Squares[x, y].IsHole = true;
                    //Postavljanje propuha na odgovarajuća mjesta
                    Squares[x, y].Breeze = true;
                    if (x > 0)
                        Squares[x - 1, y].Breeze = true;
                    if (x < rows - 1)
                        Squares[x + 1, y].Breeze = true;
                    if (y > 0)
                        Squares[x, y - 1].Breeze = true;
                    if (y < columns - 1)
                        Squares[x, y + 1].Breeze = true;
                    HoleCount--;
                }
            }
            

            //Početno polje je poznato
            Squares[0, 0].Explored = true;
            Squares[0, 0].IsAgent = true;
            this.Size = new Size(this.Padding.Vertical + rows * squareDimension,
                this.Padding.Horizontal + columns * squareDimension);
            UpdateSquareSizes();
            this.ResumeLayout();
            this.PerformLayout();
        }

        public bool Breeze
        {
            get { return Squares[AgentPosition.X, AgentPosition.Y].Breeze; }
        }

        public bool Stench
        {
            get { return Squares[AgentPosition.X, AgentPosition.Y].Stench; }
        }

        public bool Glitter
        {
            get { return Squares[AgentPosition.X, AgentPosition.Y].Glitter; }
        }

        public void ShowSquares(bool show)
        {
            foreach (var s in Squares)
                s.ShowSquare = show;
            this.Update();
        }

        protected override void OnPaddingChanged(EventArgs e)
        {
            base.OnPaddingChanged(e);
            this.Size = new Size(this.Padding.Horizontal + rows * squareDimension,
                this.Padding.Vertical + columns * squareDimension);
            UpdateSquareSizes();
        }

        public bool KeyInputEnabled
        {
            get { return keyInputEnabled; }
            set { keyInputEnabled = value; }
        }

        public GameResult Result
        {
            get
            {
                if (!AgentAlive)
                    return GameResult.Lost;
                if (GoldFound && AgentPosition.X == 0 && AgentPosition.Y == 0)
                    return GameResult.Won;
                return GameResult.Running;
            }
        }

        public int SquareDimension
        {
            get { return squareDimension; }
            set { if (value > 0) { squareDimension = value; this.UpdateSquareSizes(); } }
        }

        private void UpdateSquareSizes()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    WumpusWorldSquare Sq = Squares[i, j];
                    Sq.Height = this.squareDimension;
                    Sq.Width = this.squareDimension;
                    Sq.Location = new Point(this.Padding.Left + this.squareDimension * i,
                        this.Padding.Top + this.squareDimension * (columns - j - 1));
                }
            }
            this.Refresh();
        }

        public int Rows
        {
            get { return rows; }
        }

        public int Columns
        {
            get { return columns; }
        }

        public void AgentMove(Direction d)
        {
            if (!AgentAlive)
                return;
            if (GoldFound && AgentPosition.X == 0 && AgentPosition.Y == 0)
                return;
            moves++;
            this.SuspendLayout();
            Position New = AgentPosition.Move(d);
            if (New == AgentPosition)
                return;
            Squares[AgentPosition.X, AgentPosition.Y].IsAgent = false;
            AgentPosition = New;
            WumpusWorldSquare Sq = Squares[AgentPosition.X, AgentPosition.Y];
            Sq.Explored = true;
            Sq.IsAgent = true;
            this.Update();
            this.ResumeLayout(false);
            this.PerformLayout();
            if (Sq.IsHole || Sq.IsWumpus)
            {
                AgentAlive = false;
                this.OnGameEnded(new GameEndedEventArgs(false));
            }
            if (Sq.Glitter && !GoldFound)
            {
                GoldFound = true;
                this.OnGoldFound(EventArgs.Empty);
            }
            if (AgentPosition.X == 0 && AgentPosition.Y == 0 && GoldFound)
                this.OnGameEnded(new GameEndedEventArgs(true));
            this.OnAgentMoved(new AgentMovedEventArgs(d,
                AgentPosition.X, AgentPosition.Y));
        }

        public void BoardKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                case Keys.Left:
                    this.AgentMove(Direction.Left);
                    break;
                case Keys.S:
                case Keys.Down:
                    this.AgentMove(Direction.Down);
                    break;
                case Keys.D:
                case Keys.Right:
                    this.AgentMove(Direction.Right);
                    break;
                case Keys.W:
                case Keys.Up:
                    this.AgentMove(Direction.Up);
                    break;
            }
        }
    }

    public class GameEndedEventArgs : EventArgs
    {
        private bool gameWon;
        public GameEndedEventArgs(bool GameWon)
        {
            gameWon = GameWon;
        }
        public bool GameWon
        {
            get { return gameWon; }
        }
    }

    public class AgentMovedEventArgs : EventArgs
    {
        Direction direction;
        int PositionX;
        int PositionY;

        public AgentMovedEventArgs(Direction Direction,
            int AgentPositionX, int AgentPositionY)
        {
            this.direction = Direction;
            this.PositionX = AgentPositionX;
            this.PositionY = AgentPositionY;
        }

        public Direction Direction
        {
            get { return direction; }
        }

        public int AgentPositionX
        {
            get { return PositionX; }
        }

        public int AgentPositionY
        {
            get { return PositionY; }
        }
    }

    public enum GameResult
    {
        Running,
        Won,
        Lost
    }
}
