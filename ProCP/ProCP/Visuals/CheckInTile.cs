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
    public class CheckInTile : GridTile
    {
        public static int nodeId = 0;

        public CheckInTile(int column, int row, int tileWidth, int tileHeight) : base(column,row,tileWidth,tileHeight)
        {
            this.Column = column;
            this.Row = row;

            nodeId++;
            NodeId = nodeId;

            clickableColor = Brushes.White;
            unclickableColour = Brushes.LightGray;

            imgpath = "../../Resources/counter.png";
            img = loadImage(imgpath, img, tileWidth, tileHeight);

            img = Image.FromFile(imgpath);
                
            fillBrush = clickableColor;
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
