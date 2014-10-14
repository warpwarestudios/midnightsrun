using UnityEngine;
using System.Collections;

public class EnemyLogic : MonoBehaviour {

	public Transform sightStart, sightEnd;
	private bool spotted = false;
	public GameObject exclamation;
	public GameObject player;
	public bool staticPatrol;
	private bool facingRight;
	private float playerPosX;
	public float aggroVelocity = 2; 




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

		playerPosX = player.transform.position.x;

				
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
