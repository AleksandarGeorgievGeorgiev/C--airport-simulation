using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProCP.Visuals
{
    public class MDATile: GridTile
    {
        List<MDATilePart> tileParts = new List<MDATilePart>();
        public MDATile(int column, int row, int tileWidth, int tileHeight) : base(column, row, tileWidth, tileHeight) { }

        public List<MDATilePart> GetTileParts()
        {
            return this.tileParts;
        }

        public void AddTilePart(MDATilePart t)
        {
            this.tileParts.Add(t);
        }
    }
}
