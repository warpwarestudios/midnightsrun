using UnityEngine;
using System.Collections;

public class DamagePlayer : MonoBehaviour {

	public HealthBarScript healthBarScript;
	private float damage = 0.1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			healthBarScript.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
			healthBarScript.playerController.SendMessage("TakenDamage", SendMessageOptions.DontRequireReceiver);
		}
	}
}
