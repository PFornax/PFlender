using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Drawing;
using Keyframes;
using System.Diagnostics.Eventing.Reader;
using System.CodeDom;

namespace Actors
{
    public class Actor
    {
		public Keyframes_Manager keyframes_manager = new Keyframes_Manager();


		
		//Actor information:
		public string name = null;
		public string type = "Cube";
		public List<string> childs = new List<string>();
		//Actor values:
		public Vector2 position = new Vector2(0,0);
		public float rotation = 0f;
		public Vector2 scale = new Vector2(1,1);
		public Color color = Color.FromArgb(255,255,255,255);
		public bool visibility = true;

	}

	public class Actor_Manager
	{
		List<Actor> actors = new List<Actor>();
		

		//Remove an Actor from the current scene
		public void Remove(Actor actor)
		{
			actors.Remove(actor);
		}


		//Add a new Actor to the current scene
		public void Add(Actor actor,string name = null, string type = "Cube")
		{
			actor.keyframes_manager.Init(240);
			actor.type = type;
			actor.name = name;
			actors.Add(actor);
			
		}


		//Get an Actor object by calling it's name.
		public Actor Get(string actor_name)
		{
			foreach (Actor actor in actors)
			{
				if (actor.name == actor_name) return actor; 
			}
			return null;
		}


		//This will be implemented later.
		public void Set_Parent(Actor Parent, Actor Child)
		{

		}


		//Refresh the current values of an Actor( position, scale, rotation ) at an certain frame of the animation.
		//This will apply any changes made by keyframes.
		public void Refresh_Values(Actor actor, int frame)
		{
			var keyframes_list = actor.keyframes_manager.keyframes;
			
			if (keyframes_list[frame] != null )
			{
				
				actor.position = keyframes_list[frame].position;
				actor.scale = keyframes_list[frame].scale;
				actor.rotation = keyframes_list[frame].rotation;
				actor.color = keyframes_list[frame].color;
				actor.visibility = keyframes_list[frame].visibility;
			}
			else
			{
				return;
			}
		}



	}
}
