using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProCP.Data
{
    class ReadFromImageFile: IData
    {

        public void ReadData(string file)
        {
            try
            {
                Stream stream = new FileStream(file, FileMode.Open, FileAccess.Read);
                IFormatter formatter = new BinaryFormatter();
                // deserialize obj
            }
            catch(IOException e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
}
