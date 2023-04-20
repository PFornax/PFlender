using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using Keyframes;
using Actors;


namespace PFlender
{
	public partial class Main_Application_Form : Form
	{

	Actor_Manager actor_manager = new Actor_Manager();
	
		public Main_Application_Form()
		{
			InitializeComponent();


			//TEST
			actor_manager.Add(new Actor(), "Birne");
			actor_manager.Add(new Actor(), "Apfel");
			actor_manager.Get("Birne").keyframes_manager.Add_Keyframe(10, "bezier", new Vector2(2, 1), 45, new Vector2(2, 1), Color.FromArgb(1, 1, 1, 1), true, "Birnenkey");
			actor_manager.Get("Apfel").keyframes_manager.Add_Keyframe(23, "bezier", new Vector2(2, 111), 3, new Vector2(1, 1), Color.FromArgb(1, 1, 1, 1), true, "Apfelkey");
			actor_manager.Get("Birne").keyframes_manager.Debug_Keyframes();
			actor_manager.Get("Apfel").keyframes_manager.Debug_Keyframes();


		}
	}
}
