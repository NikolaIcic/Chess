using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Board
    {
        #region attributes
        private static Board _Instance = null;
        private List<Field> _Fields = null;
        #endregion

        #region properties
        public List<Field> Fields
        {
            get { return _Fields; }
        }
        public static Board Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new Board();
                return _Instance;
            }
        }
        #endregion

        #region functions
        private Board()
        {
            _Fields = new List<Field>();
        }
        public void AddField(Field f)
        {
            _Fields.Add(f);
        }

        public void Clear()
        {
            _Fields.Clear();
        }
        public Field GetField(int x,int y)
        {
            Field f = null;
            foreach(Field ff in _Fields)
            {
                if (ff.x == x && ff.y == y)
                    f = ff;
            }
            return f;
        }
        public List<Field> GetPosibleMoves(Field f)
        {
            bool stop = false;
            int x = f.x;
            int y = f.y;
            List<Field> moves = new List<Field>();
            switch (f.Figure)
            {
                case 'P':
                    if(f.Team == Game.Instance.perspective)
                    {
                        if (GetField(f.x - 1, f.y) != null)
                            if (GetField(f.x - 1, f.y).Team == 'E')
                                if(!Game.Instance.IsCheckedAfter(f.x, f.y, f.x - 1, f.y))
                                     moves.Add(GetField(f.x - 1, f.y));
                        if(GetField(f.x -1,f.y -1) != null)
                            if (GetField(f.x - 1, f.y -1).Team != 'E' && GetField(f.x - 1, f.y -1).Team != Game.Instance.toMove)
                                if (!Game.Instance.IsCheckedAfter(f.x, f.y, f.x - 1, f.y - 1))
                                    moves.Add(GetField(f.x - 1, f.y - 1));
                        if (GetField(f.x - 1, f.y + 1) != null)
                            if (GetField(f.x - 1, f.y + 1).Team != 'E' && GetField(f.x - 1, f.y + 1).Team != Game.Instance.toMove)
                                if (!Game.Instance.IsCheckedAfter(f.x, f.y, f.x - 1, f.y + 1))
                                    moves.Add(GetField(f.x - 1, f.y + 1));
                        if (f.firstTime)
                        {
                            if (GetField(f.x - 2, f.y).Team == 'E' && GetField(f.x - 1, f.y).Team == 'E')
                                if (!Game.Instance.IsCheckedAfter(f.x, f.y, f.x - 2, f.y))
                                    moves.Add(GetField(f.x - 2, f.y));
                        }
                        // ampeson
                        if(f.x == 3)
                        {
                            if (GetField(f.x, f.y - 1).Team != f.Team && GetField(f.x, f.y - 1).Figure == 'P' && GetField(f.x - 1, f.y - 1).Figure == 'E')
                                if (!Game.Instance.IsCheckedAfter(f.x, f.y, f.x - 1, f.y - 1))
                                    moves.Add(GetField(f.x - 1, f.y - 1));
                            if (GetField(f.x, f.y + 1).Team != f.Team && GetField(f.x, f.y + 1).Figure == 'P' && GetField(f.x - 1, f.y + 1).Figure == 'E')
                                if (!Game.Instance.IsCheckedAfter(f.x, f.y, f.x - 1, f.y + 1))
                                    moves.Add(GetField(f.x - 1, f.y + 1));
                        } 
                    }
                    else
                    {
                        if (GetField(f.x + 1, f.y) != null)
                            if (GetField(f.x + 1, f.y).Team == 'E')
                                if (!Game.Instance.IsCheckedAfter(f.x, f.y, f.x + 1, f.y))
                                    moves.Add(GetField(f.x + 1, f.y));
                        if (GetField(f.x + 1, f.y - 1) != null)
                            if (GetField(f.x + 1, f.y - 1).Team != 'E' && GetField(f.x + 1, f.y - 1).Team != Game.Instance.toMove)
                                if (!Game.Instance.IsCheckedAfter(f.x, f.y, f.x - 1, f.y -1))
                                    moves.Add(GetField(f.x + 1, f.y - 1));
                        if (GetField(f.x + 1, f.y + 1) != null)
                            if (GetField(f.x + 1, f.y + 1).Team != 'E' && GetField(f.x + 1, f.y + 1).Team != Game.Instance.toMove)
                                if (!Game.Instance.IsCheckedAfter(f.x, f.y, f.x + 1, f.y + 1))
                                    moves.Add(GetField(f.x + 1, f.y + 1));
                        if (f.firstTime)
                        {
                            if (GetField(f.x + 2, f.y).Team == 'E' && GetField(f.x + 1, f.y).Team == 'E')
                                if (!Game.Instance.IsCheckedAfter(f.x, f.y, f.x + 2, f.y))
                                    moves.Add(GetField(f.x + 2, f.y));
                        }
                        // ampeson
                        if (f.x == 4)
                        {
                            if (GetField(f.x, f.y - 1).Team != f.Team && GetField(f.x, f.y - 1).Figure == 'P' && GetField(f.x + 1, f.y - 1).Figure == 'E')
                                if (!Game.Instance.IsCheckedAfter(f.x, f.y, f.x + 1, f.y - 1))
                                    moves.Add(GetField(f.x + 1, f.y - 1));
                            if (GetField(f.x, f.y + 1).Team != f.Team && GetField(f.x, f.y + 1).Figure == 'P' && GetField(f.x + 1, f.y + 1).Figure == 'E')
                                if (!Game.Instance.IsCheckedAfter(f.x, f.y, f.x + 1, f.y + 1))
                                    moves.Add(GetField(f.x + 1, f.y + 1));
                        }
                    }
                    break;
                case 'K':
                    break;
                case 'R':
                    stop = false;
                    x = f.x + 1;
                    y = f.y;
                    while (!stop)
                    {
                        if(GetField(x,y) != null)
                        {
                            if (GetField(x, y).Team == 'E')
                            {
                                if (!Game.Instance.IsCheckedAfter(f.x, f.y, x, y))
                                    moves.Add(GetField(x, y));
                            }
                            else
                            {
                                stop = true;
                                if (GetField(x, y).Team != f.Team)
                                    if (!Game.Instance.IsCheckedAfter(f.x, f.y, x, y))
                                        moves.Add(GetField(x, y));
                            }
                            x++;
                        }
                        else
                        {
                            stop = true;
                        }
                    }
                    stop = false;
                    x = f.x - 1;
                    y = f.y;
                    while (!stop)
                    {
                        if (GetField(x, y) != null)
                        {
                            if (GetField(x, y).Team == 'E')
                            {
                                if (!Game.Instance.IsCheckedAfter(f.x, f.y, x, y))
                                    moves.Add(GetField(x, y));
                            }
                            else
                            {
                                stop = true;
                                if (GetField(x, y).Team != f.Team)
                                    if (!Game.Instance.IsCheckedAfter(f.x, f.y, x, y))
                                        moves.Add(GetField(x, y));
                            }
                            x--;
                        }
                        else
                        {
                            stop = true;
                        }
                    }
                    stop = false;
                    x = f.x;
                    y = f.y - 1;
                    while (!stop)
                    {
                        if (GetField(x, y) != null)
                        {
                            if (GetField(x, y).Team == 'E')
                            {
                                if (!Game.Instance.IsCheckedAfter(f.x, f.y, x, y))
                                    moves.Add(GetField(x, y));
                            }
                            else
                            {
                                stop = true;
                                if (GetField(x, y).Team != f.Team)
                                    if (!Game.Instance.IsCheckedAfter(f.x, f.y, x, y))
                                        moves.Add(GetField(x, y));
                            }
                            y--;
                        }
                        else
                        {
                            stop = true;
                        }
                    }
                    stop = false;
                    x = f.x;
                    y = f.y + 1;
                    while (!stop)
                    {
                        if (GetField(x, y) != null)
                        {
                            if (GetField(x, y).Team == 'E')
                            {
                                if (!Game.Instance.IsCheckedAfter(f.x, f.y, x, y))
                                    moves.Add(GetField(x, y));
                            }
                            else
                            {
                                stop = true;
                                if (GetField(x, y).Team != f.Team)
                                    if (!Game.Instance.IsCheckedAfter(f.x, f.y, x, y))
                                        moves.Add(GetField(x, y));
                            }
                            y++;
                        }
                        else
                        {
                            stop = true;
                        }
                    }
                    break;
                case 'H':
                    if (GetField(f.x-2, f.y-1) != null)
                        if (GetField(f.x-2, f.y-1).Team != f.Team)
                            if (!Game.Instance.IsCheckedAfter(f.x, f.y, f.x-2, f.y-1))
                                moves.Add(GetField(f.x-2, f.y-1));
                    if (GetField(f.x-2, f.y+1) != null)
                        if (GetField(f.x-2, f.y+1).Team != f.Team)
                            if (!Game.Instance.IsCheckedAfter(f.x, f.y, f.x-2, f.y+1))
                                moves.Add(GetField(f.x-2, f.y+1));
                    if (GetField(f.x-1, f.y-2) != null)
                        if (GetField(f.x-1, f.y-2).Team != f.Team)
                            if (!Game.Instance.IsCheckedAfter(f.x, f.y, f.x-1, f.y-2))
                                moves.Add(GetField(f.x-1, f.y-2));
                    if (GetField(f.x-1, f.y+2) != null)
                        if (GetField(f.x-1, f.y+2).Team != f.Team)
                            if (!Game.Instance.IsCheckedAfter(f.x, f.y, f.x-1, f.y+2))
                                moves.Add(GetField(f.x-1, f.y+2));
                    if (GetField(f.x+1, f.y-2) != null)
                        if (GetField(f.x+1, f.y-2).Team != f.Team)
                            if (!Game.Instance.IsCheckedAfter(f.x, f.y, f.x+1, f.y-2))
                                moves.Add(GetField(f.x+1, f.y-2));
                    if (GetField(f.x+1, f.y+2) != null)
                        if (GetField(f.x+1, f.y+2).Team != f.Team)
                            if (!Game.Instance.IsCheckedAfter(f.x, f.y, f.x+1, f.y+2))
                                moves.Add(GetField(f.x+1, f.y+2));
                    if (GetField(f.x+2, f.y-1) != null)
                        if (GetField(f.x+2, f.y-1).Team != f.Team)
                            if (!Game.Instance.IsCheckedAfter(f.x, f.y, f.x+2, f.y-1))
                                moves.Add(GetField(f.x+2, f.y-1));
                    if (GetField(f.x+2, f.y+1) != null)
                        if (GetField(f.x+2, f.y+1).Team != f.Team)
                            if (!Game.Instance.IsCheckedAfter(f.x, f.y, f.x+2, f.y+1))
                                moves.Add(GetField(f.x+2, f.y+1));
                    break;
                case 'B':
                    stop = false;
                    x = f.x + 1;
                    y = f.y + 1;
                    while (!stop)
                    {
                        if (GetField(x, y) != null)
                        {
                            if (GetField(x, y).Team == 'E')
                            {
                                if (!Game.Instance.IsCheckedAfter(f.x, f.y, x, y))
                                    moves.Add(GetField(x, y));
                            }
                            else
                            {
                                stop = true;
                                if (GetField(x, y).Team != f.Team)
                                    if (!Game.Instance.IsCheckedAfter(f.x, f.y, x, y))
                                        moves.Add(GetField(x, y));
                            }
                            y++;
                            x++;
                        }
                        else
                        {
                            stop = true;
                        }
                    }
                    stop = false;
                    x = f.x + 1;
                    y = f.y - 1;
                    while (!stop)
                    {
                        if (GetField(x, y) != null)
                        {
                            if (GetField(x, y).Team == 'E')
                            {
                                if (!Game.Instance.IsCheckedAfter(f.x, f.y, x, y))
                                    moves.Add(GetField(x, y));
                            }
                            else
                            {
                                stop = true;
                                if (GetField(x, y).Team != f.Team)
                                    if (!Game.Instance.IsCheckedAfter(f.x, f.y, x, y))
                                        moves.Add(GetField(x, y));
                            }
                            y--;
                            x++;
                        }
                        else
                        {
                            stop = true;
                        }
                    }
                    stop = false;
                    x = f.x - 1;
                    y = f.y + 1;
                    while (!stop)
                    {
                        if (GetField(x, y) != null)
                        {
                            if (GetField(x, y).Team == 'E')
                            {
                                if (!Game.Instance.IsCheckedAfter(f.x, f.y, x, y))
                                    moves.Add(GetField(x, y));
                            }
                            else
                            {
                                stop = true;
                                if (GetField(x, y).Team != f.Team)
                                    if (!Game.Instance.IsCheckedAfter(f.x, f.y, x, y))
                                        moves.Add(GetField(x, y));
                            }
                            y++;
                            x--;
                        }
                        else
                        {
                            stop = true;
                        }
                    }
                    stop = false;
                    x = f.x - 1;
                    y = f.y - 1;
                    while (!stop)
                    {
                        if (GetField(x, y) != null)
                        {
                            if (GetField(x, y).Team == 'E')
                            {
                                if (!Game.Instance.IsCheckedAfter(f.x, f.y, x, y))
                                    moves.Add(GetField(x, y));
                            }
                            else
                            {
                                stop = true;
                                if (GetField(x, y).Team != f.Team)
                                    if (!Game.Instance.IsCheckedAfter(f.x, f.y, x, y))
                                        moves.Add(GetField(x, y));
                            }
                            y--;
                            x--;
                        }
                        else
                        {
                            stop = true;
                        }
                    }
                    break;
                case 'Q':
                    stop = false;
                    x = f.x + 1;
                    y = f.y;
                    while (!stop)
                    {
                        if (GetField(x, y) != null)
                        {
                            if (GetField(x, y).Team == 'E')
                            {
                                if (!Game.Instance.IsCheckedAfter(f.x, f.y, x, y))
                                    moves.Add(GetField(x, y));
                            }
                            else
                            {
                                stop = true;
                                if (GetField(x, y).Team != f.Team)
                                    if (!Game.Instance.IsCheckedAfter(f.x, f.y, x, y))
                                        moves.Add(GetField(x, y));
                            }
                            x++;
                        }
                        else
                        {
                            stop = true;
                        }
                    }
                    stop = false;
                    x = f.x - 1;
                    y = f.y;
                    while (!stop)
                    {
                        if (GetField(x, y) != null)
                        {
                            if (GetField(x, y).Team == 'E')
                            {
                                if (!Game.Instance.IsCheckedAfter(f.x, f.y, x, y))
                                    moves.Add(GetField(x, y));
                            }
                            else
                            {
                                stop = true;
                                if (GetField(x, y).Team != f.Team)
                                    if (!Game.Instance.IsCheckedAfter(f.x, f.y, x, y))
                                        moves.Add(GetField(x, y));
                            }
                            x--;
                        }
                        else
                        {
                            stop = true;
                        }
                    }
                    stop = false;
                    x = f.x;
                    y = f.y - 1;
                    while (!stop)
                    {
                        if (GetField(x, y) != null)
                        {
                            if (GetField(x, y).Team == 'E')
                            {
                                if (!Game.Instance.IsCheckedAfter(f.x, f.y, x, y))
                                    moves.Add(GetField(x, y));
                            }
                            else
                            {
                                stop = true;
                                if (GetField(x, y).Team != f.Team)
                                    if (!Game.Instance.IsCheckedAfter(f.x, f.y, x, y))
                                        moves.Add(GetField(x, y));
                            }
                            y--;
                        }
                        else
                        {
                            stop = true;
                        }
                    }
                    stop = false;
                    x = f.x;
                    y = f.y + 1;
                    while (!stop)
                    {
                        if (GetField(x, y) != null)
                        {
                            if (GetField(x, y).Team == 'E')
                            {
                                if (!Game.Instance.IsCheckedAfter(f.x, f.y, x, y))
                                    moves.Add(GetField(x, y));
                            }
                            else
                            {
                                stop = true;
                                if (GetField(x, y).Team != f.Team)
                                    if (!Game.Instance.IsCheckedAfter(f.x, f.y, x, y))
                                        moves.Add(GetField(x, y));
                            }
                            y++;
                        }
                        else
                        {
                            stop = true;
                        }
                    }
                    x = f.x + 1;
                    y = f.y + 1;
                    while (!stop)
                    {
                        if (GetField(x, y) != null)
                        {
                            if (GetField(x, y).Team == 'E')
                            {
                                if (!Game.Instance.IsCheckedAfter(f.x, f.y, x, y))
                                    moves.Add(GetField(x, y));
                            }
                            else
                            {
                                stop = true;
                                if (GetField(x, y).Team != f.Team)
                                    if (!Game.Instance.IsCheckedAfter(f.x, f.y, x, y))
                                        moves.Add(GetField(x, y));
                            }
                            y++;
                            x++;
                        }
                        else
                        {
                            stop = true;
                        }
                    }
                    stop = false;
                    x = f.x + 1;
                    y = f.y - 1;
                    while (!stop)
                    {
                        if (GetField(x, y) != null)
                        {
                            if (GetField(x, y).Team == 'E')
                            {
                                if (!Game.Instance.IsCheckedAfter(f.x, f.y, x, y))
                                    moves.Add(GetField(x, y));
                            }
                            else
                            {
                                stop = true;
                                if (GetField(x, y).Team != f.Team)
                                    if (!Game.Instance.IsCheckedAfter(f.x, f.y, x, y))
                                        moves.Add(GetField(x, y));
                            }
                            y--;
                            x++;
                        }
                        else
                        {
                            stop = true;
                        }
                    }
                    stop = false;
                    x = f.x - 1;
                    y = f.y + 1;
                    while (!stop)
                    {
                        if (GetField(x, y) != null)
                        {
                            if (GetField(x, y).Team == 'E')
                            {
                                if (!Game.Instance.IsCheckedAfter(f.x, f.y, x, y))
                                    moves.Add(GetField(x, y));
                            }
                            else
                            {
                                stop = true;
                                if (GetField(x, y).Team != f.Team)
                                    if (!Game.Instance.IsCheckedAfter(f.x, f.y, x, y))
                                        moves.Add(GetField(x, y));
                            }
                            y++;
                            x--;
                        }
                        else
                        {
                            stop = true;
                        }
                    }
                    stop = false;
                    x = f.x - 1;
                    y = f.y - 1;
                    while (!stop)
                    {
                        if (GetField(x, y) != null)
                        {
                            if (GetField(x, y).Team == 'E')
                            {
                                if (!Game.Instance.IsCheckedAfter(f.x, f.y, x, y))
                                    moves.Add(GetField(x, y));
                            }
                            else
                            {
                                stop = true;
                                if (GetField(x, y).Team != f.Team)
                                    if (!Game.Instance.IsCheckedAfter(f.x, f.y, x, y))
                                        moves.Add(GetField(x, y));
                            }
                            y--;
                            x--;
                        }
                        else
                        {
                            stop = true;
                        }
                    }
                    break;
                case 'E':
                    break;
                default:
                    break;
            }
            return moves;
        }

        
        #endregion
    }
}
