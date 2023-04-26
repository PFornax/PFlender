using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using Keyframes;
using Actors;
using System.Numerics;
using System.Drawing;

namespace file_reader
{
    public class File_Reader
    {
		//path the PFlend file is saved in.
        string path = @"C:\Users\Pascal\Desktop\...PFlender data\file testing\test1.PFlend";

       

        public void Read_File(Actor_Manager actor_manager)
        {
			TextReader reader = new StreamReader(path);
            //Debug.WriteLine(reader.ReadToEnd());
			string current_folder = "none";
            string current_actor = "none";


			string name = null;
		    string type = "Cube";
		    List<string> childs = new List<string>();
		    //Actor values:
		    float positionX = 0f;
			float positionY = 0f;
			float rotation = 0f;
		    float scaleX = 1f;
            float scaleY = 1f;
		    int colorA = 0;
			int colorR = 0;
            int colorG = 0;
            int colorB = 0;
			bool visibility = true;


			if (!File.Exists(path)) 
            {
                Debug.WriteLine("Not found | File could not be found in the given dictionary.");
                return;
            }

            while (current_folder != "end")
            {
                string current_line = reader.ReadLine();


				//only read process the current line if it's not empty.
				if (current_line != null)
				{


					
					string[] current_line_split = current_line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
					

					
					//a new file folder will be opened:
					if (current_line_split.Length != 0)
					{
						//Change the current "folder" in the file. 
						/// A folder describes which current PFlender property is saved as text.
						/// It is always labeled with a # + folder name.
						/// The folder "end" tells the reader that it's the end of the file.

						if (current_line_split[0] == "#")
						{
							if (current_line_split[1] == "actors")
							{
								current_folder = "actors";
							}
							if (current_line_split[1] == "keyframes")
							{
								current_folder = "keyframes";
							}
							if (current_line_split[1] == "end")
							{
								current_folder = "end";
							}
						}

						//The following actions will the reader do if the current folder is "actors".
						if (current_folder == "actors")
						{
							
							if (current_line_split[0] == "+")
							{
								current_actor = current_line_split[1];
								name = current_actor;
							}
							//create actor on end of file actorinfo
							if (current_line_split[0] == "-")
							{
								Debug.WriteLine("- noticed");
								actor_manager.Add(new Actor(), current_actor);
								actor_manager.Get(current_actor).keyframes_manager.Add_Keyframe(0, "bridge", new Vector2(positionX, positionY), rotation, new Vector2(scaleX, scaleY), Color.FromArgb(colorA, colorR, colorG, colorB), visibility, name + "_StartProperty");
							}

							if (current_line_split[0] == "type")
							{
								type = current_line_split[2];
							}
							if (current_line_split[0] == "posX")
							{
								positionX = int.Parse(current_line_split[2]);
							}
							if (current_line_split[0] == "posY")
							{
								positionX = float.Parse(current_line_split[2]);
							}
							if (current_line_split[0] == "rot")
							{
								positionX = float.Parse(current_line_split[2]);
							}
							if (current_line_split[0] == "scaleX")
							{
								scaleX = float.Parse(current_line_split[2]);
							}
							if (current_line_split[0] == "scaleY")
							{
								scaleY = float.Parse(current_line_split[2]);
							}
							if (current_line_split[0] == "colA")
							{
								colorA = int.Parse(current_line_split[2]);
							}
							if (current_line_split[0] == "colR")
							{
								colorR = int.Parse(current_line_split[2]);
							}
							if (current_line_split[0] == "colG")
							{
								colorG = int.Parse(current_line_split[2]);
							}
							if (current_line_split[0] == "colB")
							{
								colorB = int.Parse(current_line_split[2]);
							}
							if (current_line_split[0] == "vis")
							{
								if (current_line_split[2] == "t")
								{
									visibility = true;
								}
								else { visibility = false; }

							}

						}
					}
				}
            }
            
		}

	}
}
