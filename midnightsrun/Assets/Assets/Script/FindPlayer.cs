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
			playerSprite.sortingLayerName = "Default";
			player.rigidbody2D.IsSleeping();			
			blinkLeftSprite.sortingLayerName = "Foreground";
			blinkRightSprite.sortingLayerName = "Foreground";
		}
		else if (triggered)
		{
			SpriteRenderer playerSprite = player.GetComponent<SpriteRenderer> ();
			playerSprite.sortingLayerName = "Foreground";
			player.rigidbody2D.IsAwake();
			blinkLeftSprite.sortingLayerName = "Default";
			blinkRightSprite.sortingLayerName = "Default";		
		}
}

void OnTriggerEnter2D(Collider2D obj)
	{
		triggered = true;
		if(obj.gameObject.tag == "Player")
		{
			player = obj.gameObject.transform;
		}
	}
	void OnTriggerExit2D(Collider2D obj)
	{
		triggered = false;
		if(obj.gameObject.tag == "Player")
		{
			player = null;
		}
	}
}
