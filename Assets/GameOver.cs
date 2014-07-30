using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
	public Texture2D theTexture;
	private bool fadeOut;
	private float startTime;
	// Use this for initialization
	void Start () {
		fadeOut = false;
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(fadeOut)
		{
			gameObject.transform.Rotate(new Vector3(0, RotationScript.rotationY, 0) * 100);
			if(Time.time - startTime > 1)
			{
				if(Time.timeSinceLevelLoad > Game.highscore)
					Game.highscore = Time.timeSinceLevelLoad;
				
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
	
	void OnGUI() 
	{
		// interpolate the alpha of the GUI from 1(fully visible) 
		// to 0(invisible) over time
		float a = Mathf.Lerp(fadeOut ? 0f : 1f, fadeOut ? 1f : 0f, (Time.time-startTime));
		GUI.color = new Color(Color.white.r, Color.white.g, Color.white.b, a);
		
		// draw the texture to fill the screen
		GUI.DrawTexture(new Rect(0,0,Screen.width, Screen.height), theTexture);
	}
	
	void OnCollisionEnter(Collision col)
	{
		if(col.transform.name == "Sphere")
		{
			Destroy(col.gameObject);
			fadeOut = true;
			startTime = Time.time;
		}
	}
}
