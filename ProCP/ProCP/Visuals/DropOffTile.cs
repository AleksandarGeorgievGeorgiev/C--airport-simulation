using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ProCP.Nodes;
using ProCP.Visuals;

namespace ProCP.Visuals
{
    public class DropOffTile : GridTile 
    {
        public DropOffTile(int column, int row, int tileWidth, int tileHeight) : base(column, row, tileWidth, tileHeight)
        {
            this.Column = column;
            this.Row = row;

            clickableColor = Brushes.White;
            unclickableColour = Brushes.LightGray;

            imgpath = "../../Resources/luggage-cart.png";
            img = loadImage(imgpath, img, tileWidth, tileHeight);

            fillBrush = clickableColor;
        }
        protected override void DrawTileInfo(Graphics g, RectangleF r, int tileHeight)
        {
        /*    Font stringFont = new Font("Ariel", tileHeight / 4, FontStyle.Bold, GraphicsUnit.Pixel);
            DropOff c = nodeInGrid as DropOff;
            string gateID = Convert.ToString(c.NodeId);
            g.DrawString("Gate: " + gateID, stringFont, Brushes.Black, r);*/
        }

    }
}
