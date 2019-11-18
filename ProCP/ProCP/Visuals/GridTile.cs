﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProCP.Abstractions;
using ProCP.Contracts;

namespace ProCP.Visuals
{
    public class GridTile
    {
        private int column;
        private int row;

        [NonSerialized]
        public Brush fillBrush;
        [NonSerialized]
        public Brush clickableColor;
        [NonSerialized]
        public Brush unclickableColour;

        public ChainNode nodeInGrid;

        protected GridTile nextTile;

        protected string imgpath;
        protected Image img;

        protected string baggageImgPath;
        protected Image baggageImg;

        protected string arrowImgPath;
        protected Image arrowImg;
        public bool selected = false;

        public int Column { get; set; }
        public int Row { get; set; }

        public GridTile(int column, int row, int tileWidth, int tileHeight)
        {
            this.column = column;
            this.row = row;
        }

        public GridTile NextTile
        {
            get { return nextTile; }
        }

        protected Image loadImage(string path, Image img, int tileWidth, int tileHeight)
        {
            using (var srce = new Bitmap(path))
            {
                var dest = new Bitmap(tileWidth, tileHeight, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
                using (var gr = Graphics.FromImage(dest))
                {
                    gr.DrawImage(srce, new Rectangle(Point.Empty, dest.Size));
                }
                if (img != null) img.Dispose();
                img = dest;
            }
            return img;
        }

        public virtual void DrawTile(PaintEventArgs e, int tileWidth, int tileHeight)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.LightSteelBlue);
            RectangleF r = new RectangleF(column * tileWidth, row * tileHeight, tileWidth, tileHeight);

            DrawBackground(p, g, r, tileWidth, tileHeight);
            DrawArrowNext(p, g, tileWidth, tileHeight);
            DrawBaggage(g, tileWidth, tileHeight);
            DrawTileInfo(g, r, tileHeight);
        }

        protected virtual void DrawBackground(Pen p, Graphics g, RectangleF r, int tileWidth, int tileHeight)
        {
            g.DrawImage(img, r);
            g.DrawRectangle(p, column * tileWidth, row * tileHeight, tileWidth, tileHeight);

            if (selected)
            {
                p = new Pen(Color.Yellow);
                g.DrawRectangle(p, column * tileWidth, row * tileHeight, tileWidth, tileHeight);
            }
        }

        protected virtual void DrawArrowNext(Pen p, Graphics g, int tileWidth, int tileHeight)
        {
            if (nextTile != null)
            {
                int arrowWidth = tileWidth / 4;
                int arrowHeight = tileHeight / 4;

                int arrowX = column * tileWidth + tileWidth / 2 - arrowWidth / 2;
                int arrowY = row * tileHeight + tileHeight / 2 - arrowHeight / 2;
                if (nextTile.column < this.column)
                {
                    p = new Pen(Color.Red);
                    Rectangle r = new Rectangle(arrowX, arrowY, arrowWidth, arrowHeight);
                    g.DrawImage(arrowImg, r);
                }
                else if (nextTile.column > this.column)
                {
                    p = new Pen(Color.Red);
                    Rectangle r = new Rectangle(arrowX, arrowY, arrowWidth, arrowHeight);
                    g.DrawImage(arrowImg, r);
                    
                }
                else if (nextTile.row < this.row)
                {
                    p = new Pen(Color.Red);
                    Rectangle r = new Rectangle(arrowX, arrowY, arrowWidth, arrowHeight);
                    g.DrawImage(arrowImg, r);
                }
                else if (nextTile.row > this.row)
                {
                    p = new Pen(Color.Red);
                    Rectangle r = new Rectangle(arrowX, arrowY, arrowWidth, arrowHeight);
                    g.DrawImage(arrowImg, r);
                }
            }
        }

        protected virtual void DrawBaggage(Graphics g, int tileWidth, int tileHeight)
        {
            if (nodeInGrid != null)
            {
                if (nodeInGrid.NodeNodeStatus == NodeStatus.Busy)
                {
                    RectangleF baggageRec = new RectangleF(column * tileWidth + 10, row * tileHeight + 10, tileWidth - 20, tileHeight - 20);
                    g.DrawImage(baggageImg, baggageRec);
                }
            }
        }

        protected virtual void DrawTileInfo(Graphics g, RectangleF r, int tileHeight)
        {

        }

    }
}