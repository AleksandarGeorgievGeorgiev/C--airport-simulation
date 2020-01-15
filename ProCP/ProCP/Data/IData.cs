using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProCP.Visuals;

namespace ProCP.Data
{
    public interface IData
    {
        Grid ReadData(string file);

        void WriteData(string file, Grid g);
    }
}
