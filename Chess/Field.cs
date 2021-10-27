using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Field
    {
        #region attributes
        private char _Figure; // P-Pown H-Horse B-Bishop R-Rook Q-Queen K-King E-Empty
        private char _Team; // B-Black W-White E-Empty
        private int _x, _y;
        private bool _firstTime;
        #endregion

        #region properties
        public char Figure {
            get { return _Figure; }
            set { _Figure = value; }
        }
        public char Team
        {
            get { return _Team; }
            set { _Team = value; }
        }
        public int x {
            get { return _x; } set { _x = value; } }
        public int y {
            get { return _y; } set { _y = value; } }
        public bool firstTime
        {
            get { return _firstTime; }
            set { _firstTime = value; }
        }
        #endregion

        #region methods
        public Field(int xCord,int yCord)
        {
            _x = xCord;
            _y = yCord;
            _Figure = 'E';
            _Team = 'E';
            firstTime = true;
        }
        #endregion
    }
}
