using UnityEngine;
using System.Collections;

public class HealthBarScript : MonoBehaviour {

	public UIProgressBar lives;
	public float currentHealth = 1;
	private float fullHealth = 1;
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
		if(currentHealth > 0)
		currentHealth -= damage;
	}
}
