using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Game
    {
        #region attributes
        private static Game _Instance;
        #endregion

        #region properties
        public static Game Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new Game();
                return _Instance;
            }
        }
        public char player1 { get; set; } // H-Human E-Engine1 A-Ai ...
        public char player2 { get; set; } // ...
        public char perspective { get; set; } // W / B
        public int xMove { get; set; }
        public int yMove { get; set; }
        public int curX { get; set; }
        public int curY { get; set; }
        public bool msdrag { get; set; }
        public char toMove { get; set; }
        public List<Field> possition { get; set; }
        #endregion

        #region methods
        private Game()
        {
            player1 = 'H';
            player2 = 'H';
            perspective = 'W';
            //xMove = -1;
            //yMove = -1;
            msdrag = false;
            toMove = 'W';
            possition = Board.Instance.Fields;
        }

        public Field GetField(int x, int y)
        {
            Field f = null;
            foreach (Field ff in possition)
                if (ff.x == x && ff.y == y)
                    f = ff;
            return f;
        }

        public bool IsCheckedAfter(int x1, int y1, int x2, int y2)
        {
            bool check = false;
            
            //pre save pieces
            char f1 = GetField(x1, y1).Figure;
            char t1 = GetField(x1, y1).Team;
            char f2 = GetField(x2, y2).Figure;
            char t2 = GetField(x2, y2).Team;
            // virtualy move piece
            possition = Board.Instance.Fields;
            GetField(x2, y2).Figure = GetField(x1, y1).Figure;
            GetField(x2, y2).Team = GetField(x1, y1).Team;
            GetField(x1, y1).Figure = 'E';
            GetField(x1, y1).Team = 'E';

            // find king
            Field king = null;
            foreach (Field ff in possition)
                if (ff.Figure == 'K' && ff.Team == toMove)
                    king = ff;
            // check for vertical/xorizontal attacks (Queen/Rook)
            int x = king.x;
            int y = king.y;
            bool stop = false;
            while (!stop)
            {
                x++;
                if (x <= 7)
                {
                    if (GetField(x, y).Team == toMove || (GetField(x, y).Team != toMove && GetField(x, y).Team != 'E' && GetField(x, y).Figure != 'Q' && GetField(x, y).Figure != 'R'))
                        stop = true;
                    else if (GetField(x, y).Team != toMove && GetField(x, y).Team != 'E' && (GetField(x, y).Figure == 'Q' || GetField(x, y).Figure == 'R'))
                        check = true;
                }
                else
                    stop = true;
            }
            x = king.x;
            y = king.y;
            stop = false;
            while (!stop)
            {
                x--;
                if (x >= 0)
                {
                    if (GetField(x, y).Team == toMove || (GetField(x, y).Team != toMove && GetField(x, y).Team != 'E' && GetField(x, y).Figure != 'Q' && GetField(x, y).Figure != 'R'))
                        stop = true;
                    else if (GetField(x, y).Team != toMove && GetField(x, y).Team != 'E' && (GetField(x, y).Figure == 'Q' || GetField(x, y).Figure == 'R'))
                        check = true;
                }
                else
                    stop = true;
                
            }
            x = king.x;
            y = king.y;
            stop = false;
            while (!stop)
            {
                y--;
                if (y >= 0)
                {
                    if (GetField(x, y).Team == toMove || (GetField(x, y).Team != toMove && GetField(x, y).Team != 'E' && GetField(x, y).Figure != 'Q' && GetField(x, y).Figure != 'R'))
                        stop = true;
                    else if (GetField(x, y).Team != toMove && GetField(x, y).Team != 'E' && (GetField(x, y).Figure == 'Q' || GetField(x, y).Figure == 'R'))
                        check = true;
                }
                else
                    stop = true;
                
            }
            x = king.x;
            y = king.y;
            stop = false;
            while (!stop)
            {
                if (y <= 7)
                {
                    y++;
                    if (GetField(x, y).Team == toMove || (GetField(x, y).Team != toMove && GetField(x, y).Team != 'E' && GetField(x, y).Figure != 'Q' && GetField(x, y).Figure != 'R'))
                        stop = true;
                    else if (GetField(x, y).Team != toMove && GetField(x, y).Team != 'E' && (GetField(x, y).Figure == 'Q' || GetField(x, y).Figure == 'R'))
                        check = true;
                }
                else
                    stop = true;
            }
            // check for diagonal attacks ( Queen/Bishop)
            x = king.x;
            y = king.y;
            stop = false;
            while (!stop)
            {
                x--;
                y--;
                if (x >= 0 && y >= 0)
                {
                    if (GetField(x, y).Team == toMove || (GetField(x, y).Team != toMove && GetField(x, y).Team != 'E' && GetField(x, y).Figure != 'Q' && GetField(x, y).Figure != 'B'))
                        stop = true;
                    else if (GetField(x, y).Team != toMove && GetField(x, y).Team != 'E' && (GetField(x, y).Figure == 'Q' || GetField(x, y).Figure == 'B'))
                        check = true;
                }
                else
                    stop = true;
            }
            x = king.x;
            y = king.y;
            stop = false;
            while (!stop)
            {
                x--;
                y++;
                if (x >= 0 && y <= 7)
                {
                    if (GetField(x, y).Team == toMove || (GetField(x, y).Team != toMove && GetField(x, y).Team != 'E' && GetField(x, y).Figure != 'Q' && GetField(x, y).Figure != 'B'))
                        stop = true;
                    else if (GetField(x, y).Team != toMove && GetField(x, y).Team != 'E' && (GetField(x, y).Figure == 'Q' || GetField(x, y).Figure == 'B'))
                        check = true;
                }
                else
                    stop = true;
            }
            x = king.x;
            y = king.y;
            stop = false;
            while (!stop)
            {
                x++;
                y++;
                if (x <= 7 && y <= 7)
                {
                    if (GetField(x, y).Team == toMove || (GetField(x, y).Team != toMove && GetField(x, y).Team != 'E' && GetField(x, y).Figure != 'Q' && GetField(x, y).Figure != 'B'))
                        stop = true;
                    else if (GetField(x, y).Team != toMove && GetField(x, y).Team != 'E' && (GetField(x, y).Figure == 'Q' || GetField(x, y).Figure == 'B'))
                        check = true;
                }
                else
                    stop = true;
            }
            x = king.x;
            y = king.y;
            stop = false;
            while (!stop)
            {
                x++;
                y--;
                if (x <= 7 && y >= 0)
                {
                    if (GetField(x, y).Team == toMove || (GetField(x, y).Team != toMove && GetField(x, y).Team != 'E' && GetField(x, y).Figure != 'Q' && GetField(x, y).Figure != 'B'))
                        stop = true;
                    else if (GetField(x, y).Team != toMove && GetField(x, y).Team != 'E' && (GetField(x, y).Figure == 'Q' || GetField(x, y).Figure == 'B'))
                        check = true;
                }
                else
                    stop = true;
            }
            
            // check by pawns
            x = king.x;
            y = king.y;
            if(perspective == toMove)
            {
                x--;
                y++;
                if (x >= 0 && y <= 7)
                    if (GetField(x, y).Figure == 'P' && GetField(x, y).Team != toMove)
                        check = true;
                x = king.x;
                y = king.y;
                x--;
                y--;
                if (x > 0 && y >= 0)
                    if (GetField(x, y).Figure == 'P' && GetField(x, y).Team != toMove)
                        check = true;
            }
            else
            {
                x++;
                y++;
                if (x <= 7 && y <= 7)
                    if (GetField(x, y).Figure == 'P' && GetField(x, y).Team != toMove)
                        check = true;
                x = king.x;
                y = king.y;
                x++;
                y--;
                if (x <= 7 && y >= 0)
                    if (GetField(x, y).Figure == 'P' && GetField(x, y).Team != toMove)
                        check = true;
            }
            // riding on a HORSEEE!!!!
            x = king.x;
            y = king.y;
            x -= 2;
            y--;
            if(x >= 0 && y >= 0)
                if (GetField(x, y).Figure == 'H' && GetField(x, y).Team != toMove)
                    check = true;
            x = king.x;
            y = king.y;
            x -= 2;
            y++;
            if (x >= 0 && y <= 7)
                if (GetField(x, y).Figure == 'H' && GetField(x, y).Team != toMove)
                    check = true;
            x = king.x;
            y = king.y;
            x--;
            y-=2;
            if (x >= 0 && y >= 0)
                if (GetField(x, y).Figure == 'H' && GetField(x, y).Team != toMove)
                    check = true;
            x = king.x;
            y = king.y;
            x--;
            y+=2;
            if (x >= 0 && y <= 7)
                if (GetField(x, y).Figure == 'H' && GetField(x, y).Team != toMove)
                    check = true;
            x = king.x;
            y = king.y;
            x++;
            y-=2;
            if (x <= 7 && y >= 0)
                if (GetField(x, y).Figure == 'H' && GetField(x, y).Team != toMove)
                    check = true;
            x = king.x;
            y = king.y;
            x++;
            y += 2;
            if (x <= 7 && y <= 7)
                if (GetField(x, y).Figure == 'H' && GetField(x, y).Team != toMove)
                    check = true;
            x = king.x;
            y = king.y;
            x += 2;
            y--;
            if (x <= 7 && y >= 0)
                if (GetField(x, y).Figure == 'H' && GetField(x, y).Team != toMove)
                    check = true;
            x = king.x;
            y = king.y;
            x += 2;
            y++;
            if (x <= 7 && y <= 7)
                if (GetField(x, y).Figure == 'H' && GetField(x, y).Team != toMove)
                    check = true;
            // check by enemy king
            x = king.x;
            y = king.y;
            x--;
            y--;
            if (x >= 0 && y >= 0)
                if (GetField(x, y).Figure == 'K' && GetField(x, y).Team != toMove)
                    check = true;
            x = king.x;
            y = king.y;
            x--;
            y++;
            if (x >= 0 && y <= 7)
                if (GetField(x, y).Figure == 'K' && GetField(x, y).Team != toMove)
                    check = true;
            x = king.x;
            y = king.y;
            x--;
            if (x >= 0)
                if (GetField(x, y).Figure == 'K' && GetField(x, y).Team != toMove)
                    check = true;
            x = king.x;
            y = king.y;
            y--;
            if (y >= 0)
                if (GetField(x, y).Figure == 'K' && GetField(x, y).Team != toMove)
                    check = true;
            y++;
            if (y <= 7)
                if (GetField(x, y).Figure == 'K' && GetField(x, y).Team != toMove)
                    check = true;
            x = king.x;
            y = king.y;
            x++;
            y--;
            if (x <= 7 && y >= 0)
                if (GetField(x, y).Figure == 'K' && GetField(x, y).Team != toMove)
                    check = true;
            x = king.x;
            y = king.y;
            x++;
            y++;
            if (x <= 7 && y <= 7)
                if (GetField(x, y).Figure == 'K' && GetField(x, y).Team != toMove)
                    check = true;
            x = king.x;
            y = king.y;
            x++;
            if (x <= 7)
                if (GetField(x, y).Figure == 'K' && GetField(x, y).Team != toMove)
                    check = true;
            
        
            // virtual move piece back
            GetField(x1, y1).Team = t1;
            GetField(x1, y1).Figure = f1;
            GetField(x2, y2).Team = t2;
            GetField(x2, y2).Figure = f2;
            return check;
           
        }

        #endregion
    }
}
