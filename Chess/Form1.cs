using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    
    public partial class Form1 : Form
    {
        // like dat dat dat

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Start();
        }

        private void Start()
        {
            panel1.Controls.Clear();
            Board.Instance.Clear();
            CreateBoard();
            CreatePictures();
            SetFigures();
            SetPictures();
            //MovePiece(6, 3, 4, 3);
        }

        private string GetPictureName(int x,int y)
        {
            char[] sq = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
            return sq[y] + (8 - x).ToString(); 
        }

        private void CreateBoard()
        {
            for (int i = 0; i < 8; i++)
                for(int j = 0; j < 8; j++)
                {
                    Field f = new Field(i, j);
                    Board.Instance.AddField(f);
                }
        }

        private void CreatePictures()
        {
            // Add picture boxex
            for (int i=0;i<8;i++)
                for(int j = 0; j < 8; j++)
                {
                    PictureBox p = new System.Windows.Forms.PictureBox();
                    p.Name = GetPictureName(i, j);
                    p.Size = new Size(100, 100);
                    p.Location = new Point(j*100,i*100);
                    if((i+j)%2==0)
                    p.BackColor = Color.AntiqueWhite;
                    else
                    p.BackColor = Color.MediumSlateBlue;
                    p.MouseDown += new System.Windows.Forms.MouseEventHandler(pb_mouseDown);
                    p.MouseMove += new System.Windows.Forms.MouseEventHandler(pb_mouseMove);
                    p.MouseUp += new System.Windows.Forms.MouseEventHandler(pb_mouseUp);
                    panel1.Controls.Add(p);
                }
        }

        private void SetFigures()
        {
            if (Game.Instance.perspective == 'W')
            {
                // Pawns
                for (int i = 0; i < 8; i++)
                {
                    // Upper Pieces
                    Board.Instance.GetField(1, i).Figure = 'P';
                    Board.Instance.GetField(1, i).Team = 'B';
                    // Lower Pieces
                    Board.Instance.GetField(6, i).Figure = 'P';
                    Board.Instance.GetField(6, i).Team = 'W';
                }
                // Rooks
                Board.Instance.GetField(0, 0).Figure = 'R';
                Board.Instance.GetField(0, 0).Team = 'B';
                Board.Instance.GetField(0, 7).Figure = 'R';
                Board.Instance.GetField(0, 7).Team = 'B';
                Board.Instance.GetField(7, 0).Figure = 'R';
                Board.Instance.GetField(7, 0).Team = 'W';
                Board.Instance.GetField(7, 7).Figure = 'R';
                Board.Instance.GetField(7, 7).Team = 'W';
                // Bishops
                Board.Instance.GetField(0, 2).Figure = 'B';
                Board.Instance.GetField(0, 2).Team = 'B';
                Board.Instance.GetField(0, 5).Figure = 'B';
                Board.Instance.GetField(0, 5).Team = 'B';
                Board.Instance.GetField(7, 2).Figure = 'B';
                Board.Instance.GetField(7, 2).Team = 'W';
                Board.Instance.GetField(7, 5).Figure = 'B';
                Board.Instance.GetField(7, 5).Team = 'W';
                // Knights
                Board.Instance.GetField(0, 1).Figure = 'H';
                Board.Instance.GetField(0, 1).Team = 'B';
                Board.Instance.GetField(0, 6).Figure = 'H';
                Board.Instance.GetField(0, 6).Team = 'B';
                Board.Instance.GetField(7, 1).Figure = 'H';
                Board.Instance.GetField(7, 1).Team = 'W';
                Board.Instance.GetField(7, 6).Figure = 'H';
                Board.Instance.GetField(7, 6).Team = 'W';
                // Kings
                Board.Instance.GetField(0, 4).Figure = 'K';
                Board.Instance.GetField(0, 4).Team = 'B';
                Board.Instance.GetField(7, 4).Figure = 'K';
                Board.Instance.GetField(7, 4).Team = 'W';
                // Queens
                Board.Instance.GetField(0, 3).Figure = 'Q';
                Board.Instance.GetField(0, 3).Team = 'B';
                Board.Instance.GetField(7, 3).Figure = 'Q';
                Board.Instance.GetField(7, 3).Team = 'W';
            }
            else
            {
                // Black Perspective here...
            }
            
        }

        private void SetPictures()
        {
            for (int i=0;i<8;i++)
                for(int j = 0; j < 8; j++)
                {
                    char Figure = Board.Instance.GetField(i, j).Figure;
                    char Team = Board.Instance.GetField(i, j).Team;
                    if (Team == 'W')
                    {
                        switch (Figure)
                        {
                            case 'P':
                                (panel1.Controls[GetPictureName(i,j)] as PictureBox).Image = Properties.Resources.wpawn;
                                break;
                            case 'K':
                                (panel1.Controls[GetPictureName(i, j)] as PictureBox).Image = Properties.Resources.wking;
                                break;
                            case 'R':
                                (panel1.Controls[GetPictureName(i, j)] as PictureBox).Image = Properties.Resources.wrook;
                                break;
                            case 'H':
                                (panel1.Controls[GetPictureName(i, j)] as PictureBox).Image = Properties.Resources.whorse;
                                break;
                            case 'B':
                                (panel1.Controls[GetPictureName(i, j)] as PictureBox).Image = Properties.Resources.wbishop;
                                break;
                            case 'Q':
                                (panel1.Controls[GetPictureName(i, j)] as PictureBox).Image = Properties.Resources.wqueen;
                                break;
                            case 'E':
                                (panel1.Controls[GetPictureName(i, j)] as PictureBox).Image = null;
                                break;
                            default:
                                (panel1.Controls[GetPictureName(i, j)] as PictureBox).Image = null;
                                break;
                        }
                    }
                    else if (Team == 'B')
                    {
                        switch (Figure)
                        {
                            case 'P':
                                (panel1.Controls[GetPictureName(i, j)] as PictureBox).Image = Properties.Resources.bpawn;
                                break;
                            case 'K':
                                (panel1.Controls[GetPictureName(i, j)] as PictureBox).Image = Properties.Resources.bking;
                                break;
                            case 'R':
                                (panel1.Controls[GetPictureName(i, j)] as PictureBox).Image = Properties.Resources.brook;
                                break;
                            case 'H':
                                (panel1.Controls[GetPictureName(i, j)] as PictureBox).Image = Properties.Resources.bhorse;
                                break;
                            case 'B':
                                (panel1.Controls[GetPictureName(i, j)] as PictureBox).Image = Properties.Resources.bbishop;
                                break;
                            case 'Q':
                                (panel1.Controls[GetPictureName(i, j)] as PictureBox).Image = Properties.Resources.bqueen;
                                break;
                            case 'E':
                                (panel1.Controls[GetPictureName(i, j)] as PictureBox).Image = null;
                                break;
                            default:
                                (panel1.Controls[GetPictureName(i, j)] as PictureBox).Image = null;
                                break;
                        }
                    }
                }
        }

        private void MovePiece(int x,int y,int xx, int yy)
        {
            if(Board.Instance.GetField(x,y).Figure != 'E' && Board.Instance.GetField(xx,yy) != null)
            {
                // set the piece
                Board.Instance.GetField(xx, yy).Figure = Board.Instance.GetField(x, y).Figure;
                Board.Instance.GetField(xx, yy).Team = Board.Instance.GetField(x, y).Team;

                // remove the piece
                Board.Instance.GetField(x, y).Figure = 'E';
                Board.Instance.GetField(x, y).Team = 'E';
                (panel1.Controls[GetPictureName(x, y)] as PictureBox).Image = null;
                SetPictures();
                Board.Instance.GetField(xx, yy).firstTime = false;
            }
        }

        private void pb_mouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                int y = (Control.MousePosition.X - this.Location.X - 8 - panel1.Location.X) / 100;
                int x = (Control.MousePosition.Y - this.Location.Y - 30 - panel1.Location.Y) / 100;

                if (Board.Instance.GetField(x, y).Team == Game.Instance.toMove)
                {
                    Game.Instance.xMove = x;
                    Game.Instance.yMove = y;
                    Game.Instance.msdrag = true;
                    Game.Instance.curX = e.X;
                    Game.Instance.curY = e.Y;
                    PictureBox p = new System.Windows.Forms.PictureBox();
                    p.Name = "Drag";
                    p.Size = new Size(100, 100);
                    p.Location = new Point(panel1.Controls[GetPictureName(x, y)].Location.X, panel1.Controls[GetPictureName(x, y)].Location.Y);
                    //p.BackColor = Color.MediumOrchid;
                    p.Image = (panel1.Controls[GetPictureName(x, y)] as PictureBox).Image;
                    panel1.Controls.Add(p);
                    p.BringToFront();
                }
            }
        }

        private void pb_mouseMove(object sender, MouseEventArgs e)
        {
            if (Game.Instance.msdrag)
            {
                panel1.Controls["Drag"].Top += e.Y - Game.Instance.curY;
                panel1.Controls["Drag"].Left += e.X - Game.Instance.curX;

                Game.Instance.curY = e.Y;
                Game.Instance.curX = e.X;
            }
        }

        private void pb_mouseUp(object sender, MouseEventArgs e)
        {
            if (Game.Instance.msdrag)
            {
                Game.Instance.msdrag = false;
                int y = (Control.MousePosition.X - this.Location.X - 8 - panel1.Location.X) / 100;
                int x = (Control.MousePosition.Y - this.Location.Y - 30 - panel1.Location.Y) / 100;
                panel1.Controls.RemoveByKey("Drag");
                if(x < 8 && x >= 0 && y >= 0 && y < 8)
                {
                    foreach(Field ff in Board.Instance.GetPosibleMoves(Board.Instance.GetField(Game.Instance.xMove, Game.Instance.yMove))){
                        if(Board.Instance.GetField(x,y) == ff)
                        {
                            MovePiece(Game.Instance.xMove, Game.Instance.yMove, x, y);
                            if (Game.Instance.toMove == 'W')
                                Game.Instance.toMove = 'B';
                            else
                                Game.Instance.toMove = 'W';
                        }
                    }
                }
            }
        }
    }
}
