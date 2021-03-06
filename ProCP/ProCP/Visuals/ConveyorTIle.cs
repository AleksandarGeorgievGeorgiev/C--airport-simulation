﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ProCP.Nodes;

namespace ProCP.Visuals
{
    [Serializable]
    class ConveyorTile : GridTile
    {
        public static int nodeId = 0;
        public ConveyorTile(int column, int row, int tileWidth, int tileHeight) : base(column, row, tileWidth, tileHeight)
        {
            this.Column = column;
            this.Row = row;

            nodeId++;
            NodeId = nodeId;

            clickableColor = Brushes.White;
            unclickableColour = Brushes.LightGray;

            imgpath = "../../Resources/conveyor.png";
            img = loadImage(imgpath, img, tileWidth, tileHeight);

            fillBrush = clickableColor;

            this.Length = 2;
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
