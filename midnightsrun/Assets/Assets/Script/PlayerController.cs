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

	
	// Use this for initialization
	void Start()
	{
		Flip ();
		animator = GetComponent<Animator>();
	}
	
	// FixedUpdate updates at regular intervals
	void FixedUpdate()
	{

		// enables sprite movement
		float move = Input.GetAxis ("Horizontal");
		animator.SetFloat ("Speed", Mathf.Abs (move));
		rigidbody2D.velocity = new Vector2 (move * maxSpeed,0);

		//Flips Sprite
		if (move > 0 && !facingRight) 
			Flip ();
		else if (move < 0 && facingRight) 
			Flip ();
		
	}

	// Update updates at irregular intervals for maximum accuracy
	void Update()
	{
		// if grounded = true, on ground
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		animator.SetBool ("Ground", grounded);
		animator.SetFloat ("vSpeed", rigidbody2D.velocity.y);

		// standing on ground and space is press, jump
		if (grounded && Input.GetKeyDown (KeyCode.Space)) 
		{
			animator.SetBool ("Ground", false);
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
}