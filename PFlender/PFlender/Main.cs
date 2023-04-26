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
using System.Diagnostics;
using file_reader;
using file_editor;
using System.IO;

namespace PFlender
{
	public partial class Main_Application_Form : Form 
	{
	
		Timer timer = new Timer();

		File_Reader file_reader = new File_Reader();
		File_Writer file_writer = new File_Writer();

		int frame = 0;
		private DateTime lastTime = DateTime.MinValue;
		Actor_Manager actor_manager = new Actor_Manager();
	
		public Main_Application_Form()
		{
			InitializeComponent();

			//TEST
			//actor_manager.Add(new Actor(), "Birne");
			//actor_manager.Add(new Actor(), "Apfel");
			//actor_manager.Get("Birne").keyframes_manager.Add_Keyframe(10, "bezier", new Vector2(2, 1), 45, new Vector2(2, 1), Color.FromArgb(1, 1, 1, 1), true, "Birnenkey");
			//actor_manager.Get("Apfel").keyframes_manager.Add_Keyframe(23, "bezier", new Vector2(2, 111), 3, new Vector2(1, 1), Color.FromArgb(1, 1, 1, 1), true, "Apfelkey");
			//actor_manager.Get("Birne").keyframes_manager.Debug_Keyframes();
			//actor_manager.Get("Apfel").keyframes_manager.Debug_Keyframes();
			timer.Start();
			timer.Tick += new EventHandler(timer1_Tick);
			timer.Interval = 1;
			file_reader.Read_File(actor_manager);
			actor_manager.Get("actor1").keyframes_manager.Debug_Keyframes();
			actor_manager.Get("act2").keyframes_manager.Debug_Keyframes();
			file_writer.Write_File("createtest");
			

		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			frame++;

			if (DateTime.Now - lastTime >= TimeSpan.FromSeconds(1))
			{
				//Debug.WriteLine(frame);
				frame = 0;
				
				lastTime = DateTime.Now;
			}

			
				
			
		}

	}
}
