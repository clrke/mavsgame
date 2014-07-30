using UnityEngine;
using System.Collections;

public class RotationScript : MonoBehaviour {
	
	public float duration;
	public float start;
	public static float rotationY;
	// Use this for initialization
	void Start () {
		duration = Random.Range(5f, 10f);
		start = Time.time;
		rotationY = Random.Range(0, 2) == 0? -1 : 1;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time - start >= duration)
		{
			duration = Random.Range(10f, 20f);
			start = Time.time;
			rotationY = -rotationY;
		}
		else
		{
			gameObject.transform.Rotate(new Vector3(0, rotationY, 0) * Time.deltaTime * 50);
		}
	}
}
