using UnityEngine;
using System.Collections;

public class SmoothCamera2d : MonoBehaviour {
	
	public float dampTime = 0.15f;
	private Vector3 velocity = Vector3.zero;
	public Transform target;
	public float height;
	private Vector3 pos;
	
	// Update is called once per frame
	void Update () 
	{
		if (target)
		{
			pos = target.position + new Vector3(0, height, 0);
			Vector3 point = camera.WorldToViewportPoint(pos);
			Vector3 delta = pos - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
			Vector3 destination = pos + delta;
			transform.position = Vector3.SmoothDamp(pos, destination, ref velocity, dampTime);
		}
		
	}
}