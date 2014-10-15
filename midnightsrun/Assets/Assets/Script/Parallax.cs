using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {

	private float X;
	public int offset;
	public bool FollowCamera;
	// Use this for initialization
	void Start () {
		X = Camera.main.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (FollowCamera) 
		{
			transform.position = new Vector2((Camera.main.transform.position.x - X) / offset, 0);
		} 
		else 
		{
			transform.position = new Vector2((X - Camera.main.transform.position.x) / offset, 0);
		}
	}
}
