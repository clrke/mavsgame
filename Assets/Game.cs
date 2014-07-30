using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
	
	public static int invert = 1;
	public static float highscore = 0;
	public PhysicMaterial[] physicMaterials;
	private static int currentPM = 0;
	
	// Use this for initialization
	void Start () {
		collider.material = physicMaterials[currentPM];
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetButtonUp("Jump"))
			Time.timeScale = Time.timeScale == 1 ? 0 : 1;
		
	}
	
	void OnGUI ()
	{
		GUI.Box(new Rect(Screen.width-100, 0, 100, 20), Time.timeSinceLevelLoad.ToString(".##"));
		
		if(Time.timeScale == 0)
		{
			GUI.BeginGroup(new Rect(0, 0, 300, 180));
			{
				GUI.Box(new Rect(0, 0, 300, 180), "Menu");
				if(GUI.Button(new Rect(20, 30, 260, 20), "Resume"))
					Time.timeScale = 1;
				if(GUI.Button(new Rect(20, 55, 260, 20), "Restart"))
				{
					Application.LoadLevel(Application.loadedLevel);
					Time.timeScale = 1;
				}
				if(GUI.Button(new Rect(20, 80, 260, 20), "Inverted: " + (invert == -1? "yes" : "no")))
					invert = -invert;
				if(GUI.Button(new Rect(20, 105, 260, 20), "Physics material: " + collider.material.name.Split(' ')[0]))
				{
					currentPM = (currentPM + 1) % physicMaterials.Length;
					collider.material = physicMaterials[currentPM];
				}
				GUI.Box(new Rect(20, 130, 260, 30), "Highscore: " + highscore.ToString(".##"));
			}
			GUI.EndGroup();
			
		}
	}
}
