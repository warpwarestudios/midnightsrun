using UnityEngine;
using System.Collections;

public class HeathBarScript : MonoBehaviour {
	
	public UIProgressBar lives;
	public float currentHealth;
	private float fullHealth;
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

	void TakeDamage ()
	{
		currentHealth -= damage;
	}
}
