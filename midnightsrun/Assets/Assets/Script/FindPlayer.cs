using UnityEngine;
using System.Collections;

public class FindPlayer : MonoBehaviour {

	public Transform player = null;
	public bool triggered = false;
	public Transform blink;

	private SpriteRenderer blinkRightSprite;
	private SpriteRenderer blinkLeftSprite;

	// Use this for initialization
	void Start () {
		blinkLeftSprite = blink.GetChild(0).GetComponent<SpriteRenderer>();
		blinkRightSprite = blink.GetChild(1).GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

		if (triggered && Input.GetKey(KeyCode.E)) {
			SpriteRenderer playerSprite = player.GetComponent<SpriteRenderer> ();
			player.rigidbody2D.isKinematic = true;
			playerSprite.sortingLayerName = "Default";
			player.collider2D.enabled = false;		
			blinkLeftSprite.sortingLayerName = "Foreground";
			blinkRightSprite.sortingLayerName = "Foreground";
		}
		else if (triggered)
		{
			SpriteRenderer playerSprite = player.GetComponent<SpriteRenderer> ();
			playerSprite.sortingLayerName = "Foreground";
			player.rigidbody2D.isKinematic = false;
			player.collider2D.enabled = true;		
			blinkLeftSprite.sortingLayerName = "Default";
			blinkRightSprite.sortingLayerName = "Default";		
		}
}

void OnTriggerEnter2D(Collider2D obj)
	{
		if(obj.gameObject.tag == "Player")
		{
			triggered = true;
			player = obj.gameObject.transform;
		}
	}

void OnTriggerExit2D(Collider2D obj)
	{
		if(obj.gameObject.tag == "Player")
		{
			triggered = false;
			player = null;
		}
	}
}
