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
                    break;
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

        //hide all rows
        public bool HideAllRowsButOne(GridTile component, int visibleRow)
        {
            if(component.Row != visibleRow)
            {
                return false;
            }
            return true;
        }

        //my changes
        public bool DrawAComponent(GridTile component, GridTile selectedTile)
        {
            GridTile replace;
            if(selectedTile is EmptyTile)
            {
                if(component is MDATile)
                {
                    MDATile m = (MDATile)component;
                    //replace empty tile with mda
                    // 2 row
                    for (int i = selectedTile.Row; i <= selectedTile.Row + 1; i++)
                    {
                        // 17 column
                        if(selectedTile.Column != 0)
                        {
                            selectedTile.Column = 0;
                        }
                        for(int j = selectedTile.Column; j < selectedTile.Column + 17; j++)
                        {

                            replace = FindTileInRowColumnCoordinates(j, i);
                            if(replace is EmptyTile)
                            {
                                this.gridTiles.Remove(replace);
                                MDATilePart p = new MDATilePart(j, i, tileWidth, tileHeight, m);
                                m.AddTilePart(p);
                                this.gridTiles.Add(p);
                            }
                        }
                    }
                }
                else
                {
                    if(component is CheckInTile)
                    {
                        if(!this.HideAllRowsButOne(component, 0))
                        {
                            return false;
                        }
                    }
                    else if(component is DropOffTile)
                    {
                        if(!this.HideAllRowsButOne(component, 11))
                        {
                            return false;
                        }
                    }
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
            foreach(var tile in tileList)
            {
                if(!(tile is EmptyTile))
                {
                    if (tile is MDATilePart p)
                    {
                        this.ConnectMda(currentTile, p);
                        //temporary solution, somehow the mda tile keep adding 2 mda tile(adding its own) with 1 conveyor to its tileparts 
                        //this temporary solution fix that problem but need to change it later on for efficiency
                        p.GetMainTile().NextTiles.RemoveAll(x => x is MDATile);
                        continue;
                    }
                    // connecting 
                    if (tile.NextTiles.Count == 0)
                    {
                        if(currentTile.Row > tile.Row || currentTile.Column > tile.Column)
                        {
                            tile.SetNextTile(currentTile);
                            currentTile.SetPreviousTile(tile);
                        }
                    }
                    else if(tile.PreviousTile == null)
                    {
                        if(currentTile.Row < tile.Row || currentTile.Column < tile.Column)
                        {
                            currentTile.SetNextTile(tile);
                            tile.SetPreviousTile(currentTile);
                        }
                    }
                }
            }
            return false;
        }

        public bool ConnectingComponentValidaion(GridTile current, GridTile selectedTile)
        {
            GridTile check;
            List<GridTile> temp;
            if(current is CheckInTile)
            {
                check = this.gridTiles.Find(x => x.Row == current.Row + 1);
                if(!(check is ConveyorTile || check is EmptyTile))
                {
                    return false;
                }
            }
            else if(current is SecurityTile)
            {
                temp = this.FindTilesFromCurrentLocation(current);
                foreach(var t in temp)
                {
                    if(!(t is ConveyorTile || t is EmptyTile))
                    {
                        return false;
                    }
                }
            }
            else if(current is DropOffTile)
            {
                check = this.gridTiles.Find(x => x.Row == current.Row - 1);
                if (!(check is ConveyorTile || check is EmptyTile))
                {
                    return false;
                }
            }
            this.DrawAComponent(current, selectedTile);
            return true;
        }

        public void ConnectMda(GridTile current, MDATilePart tilePart)
        {
            //connect to the main MDA which is sent to the backend
            //check if the conveyor is before or after the mda
            if(current.Row < tilePart.Row)
            {
                current.SetNextTile(tilePart.GetMainTile());
            }
            else
            {
                current.SetPreviousTile(tilePart.GetMainTile());
                tilePart.GetMainTile().SetNextTile(current);
            }
        }

        public void DeleteNode(GridTile current)
        {
            if(!(current is EmptyTile))
            {
                this.gridTiles.Remove(current);
                this.gridTiles.Add(new EmptyTile(current.Column, current.Row, tileWidth, tileHeight));
            }
        }
    }
}
