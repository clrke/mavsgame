using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	
	public float speed;
	private Vector3 rotation;
	// Use this for initialization
	void Start () {	
		rotation = new Vector3();
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.timeScale > 0)
		{
			rotation += new Vector3(Random.Range(-1, 2), 0, Random.Range(-1, 2))/50;
			rotation = new Vector3(Mathf.Min(rotation.x, 1), 0, Mathf.Min(rotation.z, 1));
			rotation = new Vector3(Mathf.Max(rotation.x, -1), 0, Mathf.Max(rotation.z, -1));
			
			transform.Rotate(rotation);
			transform.Rotate(new Vector3(Input.GetAxis("Vertical"), 0, -Input.GetAxis("Horizontal")) * 2 * Game.invert); 
		}
	}
}
