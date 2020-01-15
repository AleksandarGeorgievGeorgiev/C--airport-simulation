using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ProCP.Visuals;


namespace ProCP.Visuals
{
    [Serializable]
    public class SecurityTile : GridTile
    {
        public static int nodeId = 0;
        public SecurityTile(int column, int row, int tileWidth, int tileHeight) : base(column, row, tileWidth, tileHeight)
        {
            this.Column = column;
            this.Row = row;

            nodeId++;
            NodeId = nodeId;

            clickableColor = Brushes.White;
            unclickableColour = Brushes.LightGray;

            imgpath = "../../Resources/scan.png";
            img = loadImage(imgpath, img, tileWidth, tileHeight);

            fillBrush = clickableColor;
        }
    }
}
