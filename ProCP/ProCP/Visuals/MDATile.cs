using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProCP.Visuals
{
    [Serializable]
    public class MDATile: GridTile
    {
        public static int nodeId = 0;

        List<MDATilePart> tileParts;
        public MDATile(int column, int row, int tileWidth, int tileHeight) : base(column, row, tileWidth, tileHeight) {
            tileParts = new List<MDATilePart>();
            nodeId++;
            NodeId = nodeId;
        }

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
