using UnityEngine;
using System.Collections;

public class CollideMovement : MonoBehaviour {
	
	public float velocity = 0.01f;
	

	

	
	public Transform sightStart;
	public Transform sightEnd;
	
	private bool colliding;

	public LayerMask detectWhat;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{

			rigidbody2D.velocity = new Vector2 (velocity, rigidbody2D.velocity.y);
			
			colliding = Physics2D.Linecast (sightStart.position, sightEnd.position, detectWhat);
			
			if (colliding) 
			{
				transform.localScale = new Vector2 (transform.localScale.x * -1, transform.localScale.y);
				velocity *= -1;
			}
	}
}
