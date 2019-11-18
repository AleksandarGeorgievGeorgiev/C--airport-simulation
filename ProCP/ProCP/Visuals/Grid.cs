using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProCP.Abstractions;
using ProCP.Visuals;

namespace ProCP.Visuals
{
    [Serializable]
    public class Grid
    {
        private int tileWidth;
        private int tileHeight;
        private int horizontalTileCount = 20;
        private int verticalTileCount = 20;
        private float animatedBoxWidth;
        private float animatedBoxHeight;

        int bottomRow;

        public List<GridTile> gridTiles;

        public int HorizontalTileCount
        {
            get { return horizontalTileCount; }
            set { horizontalTileCount = value; }
        }
        public int VerticalTileCount
        {
            get { return verticalTileCount; }
            set { verticalTileCount = value; }
        }


        public Grid(int animBoxW, int animBoxH)
        {
            gridTiles = new List<GridTile>();

            this.animatedBoxHeight = animBoxH;
            this.animatedBoxWidth = animBoxW;

            tileHeight = (int)(animBoxH - 1) / verticalTileCount;
            tileWidth = (int)(animBoxW - 1) / horizontalTileCount;

            bottomRow = verticalTileCount - 1;

            CreateGrid();
        }

        private void CreateGrid()
        {
            for (int col = 0; col < horizontalTileCount; col++)
            {
                for (int row = 0; row < verticalTileCount; row++)
                {
                    gridTiles.Add(new EmptyTile(col, row, tileWidth, tileHeight));
                }
            }
        }

        public void DrawGrid(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            foreach (GridTile n in gridTiles)
            {
                n.DrawTile(e, tileWidth, tileHeight);
            }
        }
    }
}
