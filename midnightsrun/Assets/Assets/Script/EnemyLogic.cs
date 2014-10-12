using UnityEngine;
using System.Collections;

public class EnemyLogic : MonoBehaviour {

	public Transform sightStart, sightEnd;
	private bool spotted = false;
	public GameObject exclamation;
	public bool staticPatrol;
	private bool facingRight;

	public float aggroMoveSpeed = 4f;
	public float aggroMaxDist = 10f;
	public float aggroMinDist  = 5f;
	public Transform player;




	void Start ()
	{
		if (staticPatrol) 
		{
			InvokeRepeating ("Patrol", 0f, Random.Range (2f, 6f));
		}
	}
	// Update is called once per frame
	void Update () {
		Raycasting();
		Behaviours();
	}

	void Raycasting()
	{
		Debug.DrawLine (sightStart.position, sightEnd.position, Color.green);
		spotted = Physics2D.Linecast (sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer("Player"));
	}

	void Behaviours()
	{
		if (spotted == true) 
		{
			exclamation.SetActive (true);
				
		} 
		else 
		{
			exclamation.SetActive (false);
		}
	}

	void Patrol()
	{
				facingRight = !facingRight;

				if (facingRight == true) {
						transform.eulerAngles = new Vector2 (0, 0);
				} else {
						transform.eulerAngles = new Vector2 (0, 180);
				}
	}


	
}
