using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Drawing;
using System.Diagnostics;

namespace Keyframes
{
    public class Keyframe
    {
        //Key information.
        //If a key type is not set, it's default type will be bridge.
        //Bridges are auto generated frames which set the current information in between two real realkeyframes.
        //Therefore not seeable or changeable by hand.
        public int current_frame;
        public string type = "bridge";
        public string name = null;
        

        //Actor values or changes:
        public Vector2 position;
        public float rotation;
        public Vector2 scale;
        public Color color;
        public bool visibility = true;
    }




    public class Keyframes_Manager
    {
        public List<Keyframe> keyframes = new List<Keyframe>();
        public List<Keyframe> bridge_keyframes = new List<Keyframe>();


        //initializes 
        public void Init(int animation_numOfFrames)
        {
            for (int frame = 0; frame <= animation_numOfFrames; frame++)
            {
                keyframes.Add(null); 
                bridge_keyframes.Add(null);
            }
        }

        // Refresh has currently a bug.
        public void Refresh()
        {
            //Removes unused place in keyframes.
            int last_real_key = 0;


            //Finds last mention of a keyframe in the list.
            for (int frame = 0; frame < keyframes.Count; frame++)
            {
                if (keyframes[frame] != null)
                {
                    last_real_key = frame++;
                }
            }


            //Deletes all unnecessary null states.
            while (keyframes.Count > last_real_key)
            {
                keyframes.RemoveAt(last_real_key);
            }

        }

        //set the length of the keyframes list, wheter it will be filled with nulls or keys.
        public void Set_Length(int length)
        {
            while (keyframes.Count < length) 
            {
                keyframes.Add(null);
            }
        }

        //Add a new Keyframe to an Actor at an specific frame.
		public void Add_Keyframe(int frame, string type, Vector2 position, float rotation, Vector2 scale, Color color, bool visibility = true, string name = null)
		{
            keyframes.RemoveAt(frame);


            Keyframe new_keyframe = new Keyframe();

            new_keyframe.current_frame = frame;
            new_keyframe.type = type;
            new_keyframe.name = name;
            new_keyframe.position = position;
            new_keyframe.rotation = rotation;
            new_keyframe.scale = scale;
            new_keyframe.color = color;
            new_keyframe.visibility = visibility;

            keyframes.Insert(frame, new_keyframe);
        }

        //Debug the current keys of an Actor.
        public void Debug_Keyframes()
        {
            foreach (var keyframe in keyframes)
            {
                if (keyframe != null)
                {
                    Debug.WriteLine($"{keyframe.current_frame} | {keyframe.name}  {keyframe.type}  {keyframe.position}  {keyframe.rotation}  {keyframe.scale}  {keyframe.color}  {keyframe.visibility}");
                }
                else
                {
                    Debug.WriteLine("");
                }
            }
        }





		//public void Change_Keyframe(int frame = -1, string type, string name = null, Vector2 position = , float rotation =, Vector2 scale, Color color, bool visibility = true)
		//{

  //          //DEBUGGING
  //          try 
  //          {
  //              if (frame <= keyframes.Count)
  //              {
  //                  if (keyframes[frame] == null) 
  //                  {Debug.WriteLine($"Missing object | keyframe to change at frame {frame} could not be found. There might be a need to add one there.");     return; }
  //              }
  //              else
  //              {
		//			{Debug.WriteLine($"Out of Index | keyframe to change at frame {frame} could not be found. The wished frame is currently out of keyframes index."); return; }
		//		}
		//		if (frame == -1)
		//		{ Debug.WriteLine($"Missing Information | keyframe couldn't be changed because of the missing value frame."); return; }
		//	}
  //          finally { }
            
            




  //          Keyframe changed_keyframe;
  //          if (type != null) { }
  //          changed_keyframe.type = type;



            
			

		//}
	}
}
