using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Keyframes;
using Actors;

namespace file_editor
{
	public class File_Writer
	{

		public void Write_File(string filename)
		{
			string path = $@"C:\Users\Pascal\Desktop\...PFlender data\file testing\{filename}.PFlend"; // Replace with your desired file path
			string app_version = "a20230426";

			// Create a new file or overwrite an existing file
			using (StreamWriter writer = new StreamWriter(path))
			{
				// Write some text to the file
				writer.WriteLine("# pflender " + app_version);
				writer.WriteLine("\n// This is an .PFlend file, made for PFlender\n\n#-");

			}

		}

	}
}
