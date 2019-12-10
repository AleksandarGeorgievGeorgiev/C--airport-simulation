using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace ProCP.Visuals
{
    public class MDATilePart: GridTile
    {
        MDATile mainTile;
        public MDATilePart(int column, int row, int tileWidth, int tileHeight, MDATile mainTile): base(column, row, tileWidth, tileHeight)
        {
            clickableColor = Brushes.Purple;
            unclickableColour = Brushes.MediumPurple;

            imgpath = "../../Resources/loader.png";
            img = loadImage(imgpath, img, this.tileWidth, this.tileHeight);

            fillBrush = Brushes.Purple;
            this.mainTile = mainTile;
        }

        public MDATile GetMainTile()
        {
            return this.mainTile;
        }
    }
}
