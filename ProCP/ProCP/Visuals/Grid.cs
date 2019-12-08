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
        private int horizontalTileCount = 17;
        private int verticalTileCount = 12;

        int bottomRow;
        int topRow;

        public List<GridTile> gridTiles;
        public List<GridTile> componentList;



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
            this.componentList = new List<GridTile>();

            tileHeight = (int)(animBoxH - 1) / verticalTileCount;
            tileWidth = (int)(animBoxW - 1) / horizontalTileCount;

            bottomRow = verticalTileCount - 1;

            CreateGrid();
        }

        public int GetTileWidth() { return this.tileWidth; }
        public int GetTileHeight() { return this.tileHeight; }

        public List<GridTile> CheckTheConnection()
        {
            return this.componentList;
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

        public GridTile FindTileInPixelCoordinates(float targetX, float targetY)
        {
            GridTile foundTile = new EmptyTile(-1, -1, tileWidth, tileHeight);
            foreach (GridTile n in gridTiles)
            {
                if ((n.Column * tileWidth) <= targetX && (n.Column * tileWidth) + tileWidth >= targetX && (n.Row * tileHeight) <= targetY && (n.Row * tileHeight) + tileHeight >= targetY)
                {
                    foundTile = n;
                    return foundTile;
                }
            }
            return foundTile;
        }
        public GridTile FindTileInRowColumnCoordinates(int targetColumn, int targetRow)
        {
            GridTile foundTile = new EmptyTile(targetColumn, targetRow, tileWidth, tileHeight);
            foreach (GridTile n in gridTiles)
            {
                if (n.Column == targetColumn && n.Row == targetRow)
                {
                    foundTile = n;
                    return foundTile;
                }
            }
            return foundTile;
        }

        //my changes
        public bool DrawAComponent(GridTile component, GridTile selectedTile)
        {
            GridTile replace;
            if(selectedTile is EmptyTile)
            {
                if(component is MDATile m)
                {
                    //replace empty tile with mda
                    // 2 row
                    for(int i = selectedTile.Row; i <= selectedTile.Row + 1; i++)
                    {
                        // 17 column
                        for(int j = selectedTile.Column; j <= selectedTile.Column + 17; j++)
                        {
                            replace = FindTileInRowColumnCoordinates(j, i);
                            this.gridTiles.Remove(replace);
                            MDATilePart p = new MDATilePart(j, i, tileWidth, tileHeight, m);
                            m.AddTilePart(p);
                            this.gridTiles.Add(p);
                        }
                    }
                }
                else
                {
                    this.gridTiles.Remove(selectedTile);
                    this.gridTiles.Add(component);
                }
                if(component is CheckInTile)
                {
                    // send this list to the back-end, reason for sending only the checkins since it is the root so from that the back-end 
                    // can retrieve all the node that connected to this check in and create nodes in the back-end accordingly => not necessary to send all the nodes(except the checkins)
                    this.componentList.Add(component);
                }
                return true;
            }
            return false;
        }
        // find 4 tiles surround current tile
        private List<GridTile> FindTilesFromCurrentLocation(GridTile current)
        {
            List<GridTile> temp = new List<GridTile>();
            if(!(current is CheckInTile) && !(current is DropOffTile)) 
            {
                temp.Add(FindTileInRowColumnCoordinates(current.Column, current.Row - 1));
                temp.Add(FindTileInRowColumnCoordinates(current.Column + 1, current.Row));
                temp.Add(FindTileInRowColumnCoordinates(current.Column - 1, current.Row));
                temp.Add(FindTileInRowColumnCoordinates(current.Column, current.Row + 1));
            } 
            else if(current is CheckInTile)
            {
                temp.Add(FindTileInRowColumnCoordinates(current.Column, current.Row + 1));
            }
            else
            {
                temp.Add(FindTileInRowColumnCoordinates(current.Column, current.Row - 1));
            }
            
            return temp;
        }

        public bool ConnectTile(GridTile currentTile)
        {
            List<GridTile> tileList = this.FindTilesFromCurrentLocation(currentTile);
            if(tileList.Count == 1)
            {
                if(!(tileList[0] is EmptyTile))
                {
                    tileList[0].SetNextTile(currentTile);
                    currentTile.SetPreviousTile(tileList[0]);
                    return true;
                }
            }
            foreach(var tile in tileList)
            {
                if(!(tile is EmptyTile))
                {
                    if(tile.NextTiles.Count == 0 || tile.PreviousTile == null)
                    {
                        tile.SetNextTile(currentTile);
                        currentTile.SetPreviousTile(tile);
                    }
                    if(tile is MDATilePart p)
                    {
                        this.ConnectMda(currentTile, p);
                    }
                }
            }
            return false;
        }

        public void ConnectMda(GridTile current, MDATilePart tilePart)
        {
            current.SetNextTile(tilePart.GetMainTile());
            tilePart.GetMainTile().SetPreviousTile(current);
        }
    }
}
