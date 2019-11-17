using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProCP.Visuals
{
    [Serializable]
    class EmptyTile : GridTile
    {
        public EmptyTile(int column, int row, int tileWidth, int tileHeight)
        : base(column, row, tileWidth, tileHeight)
        {
            this.Column = column;
            this.Row = row;

            clickableColor = Brushes.White;
            unclickableColour = Brushes.LightGray;

            imgpath = "../../Resources/empty.png";
            img = loadImage(imgpath, img, tileWidth, tileHeight);

            fillBrush = clickableColor;
        }
    }
}
