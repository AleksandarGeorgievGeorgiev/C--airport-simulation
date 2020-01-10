using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ProCP.Nodes;

namespace ProCP.Visuals
{
    class ConveyorTile : GridTile
    {
        public ConveyorTile(int column, int row, int tileWidth, int tileHeight) : base(column, row, tileWidth, tileHeight)
        {
            this.Column = column;
            this.Row = row;

            clickableColor = Brushes.White;
            unclickableColour = Brushes.LightGray;

            imgpath = "../../Resources/conveyor.png";
            img = loadImage(imgpath, img, tileWidth, tileHeight);

            fillBrush = clickableColor;

            this.Length = 1;
        }
        protected override void DrawTileInfo(Graphics g, RectangleF r, int tileHeight)
        {
            /*Font stringFont = new Font("Ariel", tileHeight / 3, FontStyle.Bold, GraphicsUnit.Pixel);
            CheckInDesk c = nodeInGrid as CheckInDesk;
            string s = Convert.ToString(c.NodeId);
            g.DrawString("ID " + s, stringFont, Brushes.Black, r);*/
        }
    }
}
