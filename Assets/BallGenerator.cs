using UnityEngine;
using System.Collections;

public class BallGenerator : MonoBehaviour {
	
	public GameObject ball;
	private float startTime;
	private bool fadeIn;
	private bool fadeOut;
	public Texture2D theTexture;
	
	// Use this for initialization
	void Start () {
		fadeIn = true;
		startTime = Time.time;	
	}
	
	// Update is called once per frame
	void Update () {
		if(fadeOut)
		{
			if(Time.time - startTime > 1)
				Application.LoadLevel("main");
		}
		else if(fadeIn)
		{
			if(Time.time - startTime > 1)
				fadeIn = false;
		}
		else if(Time.time - startTime > 0.2f)
		{
			startTime = Time.time;
			GameObject clone = (GameObject) Instantiate(ball, new Vector3(Random.Range(-5, 6), 20, 0), ball.transform.rotation);
			clone.AddComponent<Rigidbody>();
			clone.AddComponent<BallDestroyer>();
		}
	}
	
	void OnGUI () {
		GUI.BeginGroup(new Rect(Screen.width/2 - 150, Screen.height/2 - 60, 300, 120));
		{
			GUI.Box(new Rect(0, 0, 300, 120), "");
			if(GUI.Button(new Rect(20, 15, 260, 40), "Start"))
			{
				fadeOut = true;
				startTime = Time.time;
			}
			if(GUI.Button(new Rect(20, 65, 260, 40), "Exit"))
				Application.Quit();
		}
		GUI.EndGroup();
		
		if(fadeIn || fadeOut)
		{
			// interpolate the alpha of the GUI from 1(fully visible) 
			// to 0(invisible) over time
			float a = Mathf.Lerp(fadeOut ? 0f : 1f, fadeOut ? 1f : 0f, (Time.time-startTime));
			if(fadeIn)
				GUI.color = new Color(Color.black.r, Color.black.g, Color.black.b, a);
			else
				GUI.color = new Color(Color.white.r, Color.white.g, Color.white.b, a);
			
			// draw the texture to fill the screen
			GUI.DrawTexture(new Rect(0,0,Screen.width, Screen.height), theTexture);
		}
	}
}
