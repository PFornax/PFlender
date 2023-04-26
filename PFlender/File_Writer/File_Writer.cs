using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Numerics;
using System.Drawing;
using Keyframes;
using Actors;


namespace file_writer
{
    public class File_Writer
    {

        public void Write_File(string filename) {
                string path = $@"C:\Users\Pascal\Desktop\...PFlender data\file testing\{filename}.PFlend"; // Replace with your desired file path

                // Create a new file or overwrite an existing file
                using (StreamWriter writer = new StreamWriter(path))
            {
                // Write some text to the file
                writer.WriteLine("Hello, world!");
                writer.WriteLine("This is a new line.");
            }

        }

    }
}
