using Solitaire.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klondike
{
    public partial class Form1 : Form
    {
        string[] cardsarr, cards;int[] collected; string[,] board; int i1, j1, i2, j2, nindex; bool sel1, sel2; int shuffler; int maxind;
        int[] covers;

        private void pictureBox_DoubleClick(object sender, MouseEventArgs e)
        {

        }

        bool kempty = false;

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form1instance = new Form1(); form1instance.Show();
        }

        public Form1()
        {
            i1 = -1; i2 = -1; j1 = -1; j2 = -1; sel1 = false; sel2 = false; covers = new int[7] { 0, 1, 2, 3, 4, 5, 6 }; shuffler = 27; maxind = 51;
            InitializeComponent();
            string[] cards = new string[52] {
                "s01","s02","s03","s04","s05","s06","s07","s08","s09","s10","s11","s12","s13",
                "h01","h02","h03","h04","h05","h06","h07","h08","h09","h10","h11","h12","h13",
                "c01","c02","c03","c04","c05","c06","c07","c08","c09","c10","c11","c12","c13",
                "d01","d02","d03","d04","d05","d06","d07","d08","d09","d10","d11","d12","d13"
            };
            cardsarr = new string[52] {
                "s01","s02","s03","s04","s05","s06","s07","s08","s09","s10","s11","s12","s13",
                "h01","h02","h03","h04","h05","h06","h07","h08","h09","h10","h11","h12","h13",
                "c01","c02","c03","c04","c05","c06","c07","c08","c09","c10","c11","c12","c13",
                "d01","d02","d03","d04","d05","d06","d07","d08","d09","d10","d11","d12","d13"
            };
            collected = new int[4] {0,0,0,0};
            board = new string[19, 7];
            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    board[i, j] = "";
                }
            }
            Random r = new Random();
            cardsarr = cardsarr.OrderBy(x => r.Next()).ToArray();
            /* cardsarr = new string[52] {
                "s01","s09","s03","s04","h06","s06","s07","s02","s05","s10","s11","s12","s13",
                "h02","s08","h03","h04","h05","h01","h07","h08","h09","d01","h11","h12","h13",
                "c01","d13","c03","c13","c05","c06","c07","c08","c09","c10","c11","c12","c04",
                "h10","d02","d03","d04","d05","d06","d07","d08","d09","d10","d11","d12","c02"
            }; */
            board[0, 0] = cardsarr[0]; board[0, 1] = cardsarr[1]; board[0, 2] = cardsarr[2]; board[0, 3] = cardsarr[3]; board[0, 4] = cardsarr[4]; board[0, 5] = cardsarr[5]; board[0, 6] = cardsarr[6];
            board[1, 1] = cardsarr[7]; board[1, 2] = cardsarr[8]; board[1, 3] = cardsarr[9]; board[1, 4] = cardsarr[10]; board[1, 5] = cardsarr[11]; board[1, 6] = cardsarr[12];
            board[2, 2] = cardsarr[13]; board[2, 3] = cardsarr[14]; board[2, 4] = cardsarr[15]; board[2, 5] = cardsarr[16]; board[2, 6] = cardsarr[17];
            board[3, 3] = cardsarr[18]; board[3, 4] = cardsarr[19]; board[3, 5] = cardsarr[20]; board[3, 6] = cardsarr[21];
            board[4, 4] = cardsarr[22]; board[4, 5] = cardsarr[23]; board[4, 6] = cardsarr[24];
            board[5, 5] = cardsarr[25]; board[5, 6] = cardsarr[26];
            board[6, 6] = cardsarr[27];

            pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_paint);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pictureBox_Click(object sender, MouseEventArgs e)
        {
            int mx = e.X;
            int my = e.Y; bool ssel; bool trx = false; int tc = 0; int tr = 0;
            switch (e.Button)
            {
                case MouseButtons.Left:
                    // Left click
                    
            // if clicked the menu pack on top left
            if (mx >= 32 && mx < 107 && my >= 24 && my < 133)
            {
                if (sel1 && nindex != -1 && !sel2) { sel1 = false; nindex = -1; }
                if (shuffler < maxind) { shuffler++; } else { shuffler = 27; }
                this.Refresh();
            }
            if (!sel1 && !sel2 && mx >= 128 && mx < 203 && my >= 24 && my < 133 && shuffler > 27 && shuffler <= maxind)
            {
                nindex = shuffler; ssel = true; sel1 = true; this.Refresh();
            }
            if (!sel2)
            {
                
                // if clicked inside board 2d array range
                if (mx >= 32 && my >= 150)
                {
                    if (mx >= 32 && mx < 107)
                    {
                        trx = true; tc = 0;
                    }
                    else if (mx >= 128 && mx < 203)
                    {
                        trx = true;
                        tc = 1;
                    }
                    else if (mx >= 224 && mx < 299)
                    {
                        trx = true; tc = 2;
                    }
                    else if (mx >= 320 && mx < 395)
                    {
                        trx = true; tc = 3;
                    }
                    else if (mx >= 416 && mx < 491)
                    {
                        trx = true; tc = 4;
                    }
                    else if (mx >= 512 && mx < 587)
                    {
                        trx = true; tc = 5;
                    }
                    else if (mx >= 608 && mx < 683)
                    {
                        trx = true; tc = 6;
                    }
                    if (trx)
                    {
                        int l = 0;
                        for (int x = 0; x < 19; x++)
                        {
                            if (board[x, tc] != "") { l++; }
                        }
                        for (int z = 0; z < l; z++)
                        {

                            if (z < l - 1)
                            {

                                if (my >= (150 + (12 * z)) && my < (150 + (12 * (z + 1))) && z >= covers[tc])
                                {
                                    if (!sel1) { sel1 = true; i1 = z; j1 = tc; this.Refresh(); }
                                    else
                                    {
                                        sel2 = true; i2 = z; j2 = tc; this.Refresh();

                                        checkSel();
                                    }
                                }
                            }
                            else if (z == l - 1 && my >= (150 + (12 * z)) && my < (259 + (12 * z)) && z >= covers[tc])
                            {
                                if (!sel1) { sel1 = true; i1 = z; j1 = tc; this.Refresh(); }
                                else
                                {
                                    sel2 = true; i2 = z; j2 = tc; this.Refresh();

                                    checkSel();
                                }
                            }

                        }
                        if (sel1 && l == 0 && my >= (150 + (12 * 0)) && my < (259 + (12 * 0)))
                        {
                            if (i1 != -1 && j1 != -1)
                            {

                                int nz = 0; /*card number*/
                                string f = board[i1, j1];
                                foreach (char c in f) { if ((c >= '0') && (c <= '9')) { nz = nz * 10 + (c - '0'); } }   // extracting card number
                                if (nz == 13)
                                {
                                    kempty = true;

                                }
                                sel2 = true; i2 = 0; j2 = tc; this.Refresh(); checkSel();
                            } else if (nindex != -1) {
                                int nz = 0; /*card number*/
                                string f = cardsarr[nindex];
                                foreach (char c in f) { if ((c >= '0') && (c <= '9')) { nz = nz * 10 + (c - '0'); } }   // extracting card number
                                if (nz == 13)
                                {
                                    kempty = true;

                                }
                                sel2 = true; i2 = 0; j2 = tc; this.Refresh(); checkSel();
                            }
                        }
                    }
                }
            }
            
    break;

    case MouseButtons.Right:
                    // Right click



                    // if clicked the menu pack on top left

                    if (mx >= 128 && mx < 203 && my >= 24 && my < 133 && shuffler > 27 && shuffler <= maxind)
                    {
                        int shufl = shuffler; string b2 = cardsarr[shufl];
                        int n1 = 0; /*card number*/ string s1 = ""; /*suit*/
                        foreach (char c in b2)
                        {
                            if ((c >= '0') && (c <= '9')) { n1 = n1 * 10 + (c - '0'); }
                            else if (c == 'c' || c == 's') { s1 = Char.ToString(c); }
                            else if (c == 'd' || c == 'h') { s1 = Char.ToString(c); }
                        }
                        switch (s1)
                        {
                            case "s":
                                if (collected[0] == n1 - 1)
                                {
                                    sel1 = false; sel2 = false; i1 = -1; i2 = -1;
                                    nindex = -1; j1 = -1; j2 = -1; collected[0]++;
                                    cardsarr[shufl] = "";
                                    for (int m = shufl; m < maxind; m++)
                                    {
                                        cardsarr[m] = cardsarr[m + 1];
                                    }
                                    maxind--; shufl = -1; shuffler--;
                                    this.Refresh();
                                }
                                break;
                            case "h":
                                if (collected[1] == n1 - 1)
                                {
                                    sel1 = false; sel2 = false; i1 = -1; i2 = -1;
                                    nindex = -1; j1 = -1; j2 = -1; collected[1]++;
                                    cardsarr[shufl] = "";
                                    for (int m = shufl; m < maxind; m++)
                                    {
                                        cardsarr[m] = cardsarr[m + 1];
                                    }
                                    maxind--; shufl = -1; shuffler--;
                                    this.Refresh();
                                }
                                break;
                            case "c":
                                if (collected[2] == n1 - 1)
                                {
                                    sel1 = false; sel2 = false; i1 = -1; i2 = -1;
                                    nindex = -1; j1 = -1; j2 = -1; collected[2]++;
                                    cardsarr[shufl] = "";
                                    for (int m = shufl; m < maxind; m++)
                                    {
                                        cardsarr[m] = cardsarr[m + 1];
                                    }
                                    maxind--; shufl = -1; shuffler--;
                                    this.Refresh();
                                }
                                break;
                            case "d":
                                if (collected[3] == n1 - 1)
                                {
                                    sel1 = false; sel2 = false; i1 = -1; i2 = -1;
                                    nindex = -1; j1 = -1; j2 = -1; collected[3]++;
                                    cardsarr[shufl] = "";
                                    for (int m = shufl; m < maxind; m++)
                                    {
                                        cardsarr[m] = cardsarr[m + 1];
                                    }
                                    maxind--; shufl = -1; shuffler--;
                                    this.Refresh();
                                }
                                break;
                        }

                    }

                    // if clicked inside board 2d array range
                    if (mx >= 32 && my >= 150)
                    {
                        if (mx >= 32 && mx < 107)
                        {
                            trx = true; tc = 0;
                        }
                        else if (mx >= 128 && mx < 203)
                        {
                            trx = true;
                            tc = 1;
                        }
                        else if (mx >= 224 && mx < 299)
                        {
                            trx = true; tc = 2;
                        }
                        else if (mx >= 320 && mx < 395)
                        {
                            trx = true; tc = 3;
                        }
                        else if (mx >= 416 && mx < 491)
                        {
                            trx = true; tc = 4;
                        }
                        else if (mx >= 512 && mx < 587)
                        {
                            trx = true; tc = 5;
                        }
                        else if (mx >= 608 && mx < 683)
                        {
                            trx = true; tc = 6;
                        }
                        if (trx)
                        {
                            int l = 0;
                            for (int x = 0; x < 19; x++)
                            {
                                if (board[x, tc] != "") { l++; }
                            }
                            for (int z = 0; z < l; z++)
                            {

                                if (z == l - 1 && my >= (150 + (12 * z)) && my < (259 + (12 * z)) && z >= covers[tc])
                                {

                                    string b2 = board[z, tc];

                                    int n1 = 0; /*card number*/ string s1 = ""; /*suit*/
                                    foreach (char c in b2)
                                    {
                                        if ((c >= '0') && (c <= '9'))
                                        {
                                            n1 = n1 * 10 + (c - '0');
                                        }
                                        else if (c == 'c' || c == 's') { s1 = Char.ToString(c); }
                                        else if (c == 'd' || c == 'h') { s1 = Char.ToString(c); }
                                    }
                                    switch (s1)
                                    {
                                        case "s":
                                            if (collected[0] == n1 - 1) { sel1 = false; sel2 = false; i1 = -1; i2 = -1;
                                                nindex = -1; j1 = -1; j2 = -1; board[z, tc] = ""; collected[0]++; 
                                                if (z <= covers[tc]) { covers[tc]--; } this.Refresh();
                                            }
                                            break;
                                        case "h":
                                            if (collected[1] == n1 - 1) { sel1 = false; sel2 = false; i1 = -1; i2 = -1;
                                                nindex = -1; j1 = -1; j2 = -1; board[z, tc] = ""; collected[1]++; 
                                                if (z <= covers[tc]) { covers[tc]--; } this.Refresh();
                                            }
                                            break;
                                        case "c":
                                            if (collected[2] == n1 - 1) { sel1 = false; sel2 = false; i1 = -1; i2 = -1;
                                                nindex = -1; j1 = -1; j2 = -1; board[z, tc] = ""; collected[2]++; 
                                                if (z <= covers[tc]) { covers[tc]--; } this.Refresh();
                                            }
                                            break;
                                        case "d":
                                            if (collected[3] == n1 - 1) { sel1 = false; sel2 = false; i1 = -1; i2 = -1;
                                                nindex = -1; j1 = -1; j2 = -1; board[z, tc] = ""; collected[3]++; 
                                                if (z <= covers[tc]) { covers[tc]--; } this.Refresh();
                                            }
                                            break;
                                    }




                                }

                            }
                        }
                    }




                    break;
        }
        }

        private void checkSel()
        {

            bool wrong = false;
            if (i2 < 18)
            {
                if (board[i2 + 1, j2] != "") { wrong = true; }
            }
            // if sel1 is from the board
            if (i1 != -1 && j1 != -1 && i2 != -1 && j2 != -1 && j1 != j2 && !wrong)
            {
                string b1 = board[i1, j1];
                string b2 = board[i2, j2];

                int n1 = 0; /*card number*/ string s1 = ""; /*suit*/ string compr1 = "a"; /*Suits opposite or not*/
                foreach (char c in b1)
                {
                    if ((c >= '0') && (c <= '9'))
                    {
                        n1 = n1 * 10 + (c - '0');
                    }
                    else if (c == 'c' || c == 's') { s1 = Char.ToString(c); compr1 = "x"; }
                    else if (c == 'd' || c == 'h') { s1 = Char.ToString(c); compr1 = "y"; }
                }
                int n2 = 0; string s2 = ""; string compr2 = "b";
                foreach (char c in b2)
                {
                    if ((c >= '0') && (c <= '9'))
                    {
                        n2 = n2 * 10 + (c - '0');
                    }
                    else if (c == 'c' || c == 's') { s2 = Char.ToString(c); compr2 = "y"; }
                    else if (c == 'd' || c == 'h') { s2 = Char.ToString(c); compr2 = "x"; }
                }
                bool matched = false;
                if (compr1 == compr2 && n1 == (n2 - 1)) { matched = true; }
                if (kempty) { matched = true; }
                if (matched)
                {
                    int ii2 = 1; if (kempty) { ii2 = 0; }
                    for (int m = i1; m < 19; m++)
                    {
                        // TODO: Handle if index outside bounds error happen
                        if (board[m, j1] != "")
                        {
                            board[i2 + ii2, j2] = board[m, j1];
                            board[m, j1] = "";
                            ii2++;
                        }
                    }
                    if (i1 <= covers[j1]) { covers[j1]--; }

                }
                else { try { Thread.Sleep(200); } catch (Exception zz) { } }

            }


            //if sel1 is from the shuffler
            else if (nindex != -1 && i1 == -1 && j1 == -1 && i2 != -1 && j2 != -1 && !wrong)
            {
                string b1 = cardsarr[nindex];
                string b2 = board[i2, j2];

                int n1 = 0; /*card number*/ string s1 = ""; /*suit*/ string compr1 = "a"; /*Suits opposite or not*/
                foreach (char c in b1)
                {
                    if ((c >= '0') && (c <= '9'))
                    {
                        n1 = n1 * 10 + (c - '0');
                    }
                    else if (c == 'c' || c == 's') { s1 = Char.ToString(c); compr1 = "x"; }
                    else if (c == 'd' || c == 'h') { s1 = Char.ToString(c); compr1 = "y"; }
                }
                int n2 = 0; string s2 = ""; string compr2 = "b";
                foreach (char c in b2)
                {
                    if ((c >= '0') && (c <= '9'))
                    {
                        n2 = n2 * 10 + (c - '0');
                    }
                    else if (c == 'c' || c == 's') { s2 = Char.ToString(c); compr2 = "y"; }
                    else if (c == 'd' || c == 'h') { s2 = Char.ToString(c); compr2 = "x"; }
                }
                bool matched = false;
                if (compr1 == compr2 && n1 == (n2 - 1)) { matched = true; }
                if (kempty) { matched = true; Console.WriteLine("kempty is passed"); }
                if (matched)
                {
                    int ii2 = 1; if (kempty) { ii2 = 0; }
                    // TODO: Handle if index outside bounds error happen
                    if (i2 < 18)
                    {
                        board[i2 + ii2, j2] = cardsarr[nindex];
                    }
                    cardsarr[nindex] = "";
                    for (int m = nindex; m < maxind; m++)
                    {
                        cardsarr[m] = cardsarr[m + 1];
                    }
                    maxind--; nindex = -1; shuffler--;
                }
                else { try { Thread.Sleep(200); } catch (Exception zz) { } }

            }

            sel1 = false; sel2 = false; i1 = -1; i2 = -1; j1 = -1; j2 = -1; nindex = -1; kempty = false;
            this.Refresh();
        }

        private void pictureBox_paint(object sender, PaintEventArgs e)
        {

            // Create a local version of the graphics object for the PictureBox.
            Graphics g = e.Graphics;
            try
            {
                if (shuffler < maxind) { e.Graphics.DrawImage(Resources.back, 32, 24, 75, 109); }
                else { e.Graphics.DrawImage(Resources.none, 32, 24, 75, 109); }

                if (shuffler > 27 && shuffler <= maxind)
                {
                    e.Graphics.DrawImage((System.Drawing.Image)(Solitaire.Properties.Resources.ResourceManager.GetObject(cardsarr[shuffler]))
                      , 128, 24, 75, 109);
                }
                else { e.Graphics.DrawImage(Resources.empty, 128, 24, 75, 109); }

                if (sel1 && nindex == shuffler) { e.Graphics.DrawImage(Resources.sel, 128, 24, 75, 109); }
                string ls = ""; string lh = ""; string lc = ""; string ld = "";
                if (collected[0] == 0) { e.Graphics.DrawImage(Resources.empty, 320, 24, 75, 109); }
                else {
                    if (collected[0]<10) { ls = "0"; }
                        e.Graphics.DrawImage((System.Drawing.Image)(Solitaire.Properties.Resources.ResourceManager.GetObject("s" + ls + collected[0])), 320, 24, 75, 109);
                }
                if (collected[1] == 0) { e.Graphics.DrawImage(Resources.empty, 416, 24, 75, 109); }
                else {
                    if (collected[1] < 10) { lh = "0"; }
                    e.Graphics.DrawImage((System.Drawing.Image)(Solitaire.Properties.Resources.ResourceManager.GetObject("h" + lh + collected[1])), 416, 24, 75, 109);
                }
                if (collected[2] == 0) { e.Graphics.DrawImage(Resources.empty, 512, 24, 75, 109); }
                else {
                    if (collected[2] < 10) { lc = "0"; }
                    e.Graphics.DrawImage((System.Drawing.Image)(Solitaire.Properties.Resources.ResourceManager.GetObject("c" + lc + collected[2])), 512, 24, 75, 109);
                }
                if (collected[3] == 0) { e.Graphics.DrawImage(Resources.empty, 608, 24, 75, 109); }
                else {
                    if (collected[3] < 10) { ld = "0"; }
                    e.Graphics.DrawImage((System.Drawing.Image)(Solitaire.Properties.Resources.ResourceManager.GetObject("d" + ld + collected[3])), 608, 24, 75, 109);
                }
                
               

                for (int j = 0; j < 7; j++)
                {
                    for (int i = 0; i < 19; i++)
                    {

                        if (i < 19)
                        {
                            float tileX = (j * 96) + 32;
                            float tileY = (i * 12) + 150;
                            string type = board[i, j];
                            if (board[i, j] != "")
                            {
                                if (i < 18)
                                {
                                    if (i >= covers[j])
                                    {
                                        e.Graphics.DrawImage(((System.Drawing.Image)(Solitaire.Properties.Resources.ResourceManager.GetObject(board[i, j]))),
                                                                        tileX, tileY, 75, 109);
                                    }
                                    else
                                    {
                                        e.Graphics.DrawImage(Resources.back, tileX, tileY, 75, 109);
                                    }

                                }
                                else
                                {
                                    e.Graphics.DrawImage(((System.Drawing.Image)(Solitaire.Properties.Resources.ResourceManager.GetObject(board[i, j]))),
                                                                        tileX, tileY, 75, 109);
                                }



                            }
                            else if (i == 0) { e.Graphics.DrawImage(Resources.empty, tileX, tileY, 75, 109); }
                            if (sel1 && j1 == j && i1 == i) { e.Graphics.DrawImage(Resources.sel, (j1 * 96) + 32, (i1 * 12) + 150, 75, 109); }
                            if (sel2 && j2 == j && i2 == i) { e.Graphics.DrawImage(Resources.sel, (j2 * 96) + 32, (i2 * 12) + 150, 75, 109); }

                        }
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            try
            {
                Thread.Sleep(40);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }



        }
    }

}

