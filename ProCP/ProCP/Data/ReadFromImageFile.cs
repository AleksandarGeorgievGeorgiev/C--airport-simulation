using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProCP.Visuals;

namespace ProCP.Data
{
    class ReadFromImageFile: IData
    {

        public Grid ReadData(string file)
        {
            Grid myGrid = null;
            FileStream stream = null;
            BinaryFormatter formatter;
            try
            {
                stream = new FileStream(file, FileMode.Open, FileAccess.Read);
                formatter = new BinaryFormatter();
                while(stream.Position < stream.Length)
                {
                    myGrid = (Grid)formatter.Deserialize(stream);
                }
            }
            catch(IOException e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                if(stream != null)
                {
                    stream.Close();
                }
            }
            return myGrid;
        }

        public void WriteData(string path, Grid myGrid)
        {
            FileStream stream = null;
            BinaryFormatter formatter;
            try
            {
                stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                formatter = new BinaryFormatter();
                formatter.Serialize(stream, myGrid);
            }
            catch (IOException e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
        }
    }
}
