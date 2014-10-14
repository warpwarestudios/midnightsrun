using UnityEngine;
using System.Collections;

public class EnemyLogic : MonoBehaviour {

	public Transform sightStart, sightEnd;
	private bool spotted = false;
	public GameObject exclamation;
	public GameObject player;
	private float enemyPosX;
	public bool staticPatrol;
	private bool facingRight;
	private float playerPosX;
	public float moveSpeed = 2; 
	public float chaseSpeed = 3.5f;
	private float rand;
	private float timer;




	void Start ()
	{
		rand = Random.Range (2f, 6f);
		enemyPosX = this.transform.position.x;
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
		if (!spotted) 
		{
			timer += Time.deltaTime;
			if (timer >= rand) 
			{
				Flip ();
				rand = Random.Range (2f, 6f);
				timer = 0f;
			}
		}
		
		if (!spotted) 
		{

			if (facingRight)
			{
				rigidbody2D.velocity= new Vector2 (-moveSpeed,0);
			}
			else if (!facingRight)
			{
				rigidbody2D.velocity= new Vector2 (moveSpeed,0);
			}

		}

		if (spotted) 
		{
			exclamation.SetActive (true);
			// move towards
			if (facingRight)
			{
				rigidbody2D.velocity= new Vector2 (-chaseSpeed,0);
			}
			else if (!facingRight)
			{
				rigidbody2D.velocity= new Vector2 (chaseSpeed,0);
			}
				
		} 
		else 
		{
			exclamation.SetActive (false);
		}
	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector2 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}


	
}
