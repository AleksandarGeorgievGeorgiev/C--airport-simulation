using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ProCP.Data
{
    class ReadTextFile: IData
    {
        public void ReadData(string file)
        {
            try
            {
                using(StreamReader sr = new StreamReader(file))
                {
                    string line = sr.ReadLine();
                    while(!sr.EndOfStream)
                    {
                        //do the initialize part e.g: creating checkin, ... according to the content of the file.
                    }


                    //close
                    sr.Close();
                }
            }
            catch(IOException e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
}
