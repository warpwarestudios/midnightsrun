using UnityEngine;
using System.Collections;

public class HealthBarScript : MonoBehaviour {

	public UIProgressBar lives;
	public PlayerController playerController;
	private float currentHealth = 1f;
	public GameObject player;
	public GameObject gameOver;
	private float fullHealth = 1f;
	private float damage;

	// Use this for initialization
	void Start () {
		
		currentHealth = fullHealth;
	}
	
	// Update is called once per frame
	void Update () {
		lives = gameObject.GetComponent<UIProgressBar> ();
		lives.value = currentHealth;
	}
	
	void TakeDamage (float damage)
	{
		if (currentHealth > 0) 
		{
			player.rigidbody2D.AddForce(new Vector2(-5,-5));
			currentHealth -= damage;


		}
		else 
		{
			player.SetActive(false);
			gameOver.SetActive(true);
		}
	}
}
