using UnityEngine;
using System.Collections;

public class PlayerController: MonoBehaviour {

	//animator
	private Animator animator;

	// standard movement values
	public float maxSpeed = 10f;
	public bool facingRight = false;

	// values for jumping
	public bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 700f;
	public float takenDamage = 0.2f;

	
	// Use this for initialization
	void Start()
	{
		Flip ();
		animator = GetComponent<Animator>();
	}
	
	// FixedUpdate updates at regular intervals
	// For physics calculations
	void FixedUpdate()
	{

		// if grounded = true, on ground
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		animator.SetBool ("Ground", grounded);
		animator.SetFloat ("vSpeed", rigidbody2D.velocity.y);
		
	}

	// Update updates at irregular intervals for maximum accuracy
	void Update()
	{

		// enables sprite movement
		float move = Input.GetAxis ("Horizontal");
		animator.SetFloat ("Speed", Mathf.Abs (move));
		rigidbody2D.velocity= new Vector2 (move * maxSpeed,0);
		
		//Flips Sprite
		if (move > 0 && !facingRight) 
			Flip ();
		else if (move < 0 && facingRight) 
			Flip ();


		// standing on ground and space is press, jump
		if (grounded && Input.GetKeyDown (KeyCode.Space) && Input.GetAxis("Horizontal") > 0) 
		{
			animator.SetBool ("Ground", false);
			if(facingRight)
				rigidbody2D.AddForce(new Vector2(jumpForce,jumpForce));
			else
				rigidbody2D.AddForce(new Vector2(-1 * jumpForce,jumpForce));
			
		}
		else if (grounded && Input.GetKeyDown (KeyCode.Space)) 
		{
			animator.SetBool ("Ground", false);
			if(facingRight)
				rigidbody2D.AddForce(new Vector2(0,jumpForce));
			else
				rigidbody2D.AddForce(new Vector2(0,jumpForce));
			
		}
	}
	
	// Flips Sprite
	void Flip()
	{
		facingRight = !facingRight;
		Vector2 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

	public IEnumerator TakenDamage()
	{
		renderer.enabled = false;
		yield return new WaitForSeconds(takenDamage);
		renderer.enabled = true;
		yield return new WaitForSeconds(takenDamage);
		renderer.enabled = false;
		yield return new WaitForSeconds(takenDamage);
		renderer.enabled = true;
		yield return new WaitForSeconds(takenDamage);
		renderer.enabled = false;
		yield return new WaitForSeconds(takenDamage);
		renderer.enabled = true;
		yield return new WaitForSeconds(takenDamage);
		renderer.enabled = false;
		yield return new WaitForSeconds(takenDamage);
		renderer.enabled = true;
		yield return new WaitForSeconds(takenDamage);

	}
}