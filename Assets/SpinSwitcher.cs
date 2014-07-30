using UnityEngine;
using System.Collections;

public class SpinSwitcher : MonoBehaviour {
	
	float startTime;
	float duration;
	public static int invert = 1;
	
	// Use this for initialization
	void Start () {
		startTime = Time.time;
		duration = Random.Range(5f, 10f);
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time - startTime >= duration)
		{
			duration = Random.Range(5f, 10f);
			startTime = Time.time;
			invert = -invert;
		}
	}
}
