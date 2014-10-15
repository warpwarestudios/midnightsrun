using UnityEngine;
using System.Collections;

public class CandyPoints : MonoBehaviour {

	public UILabel counterlabel;
	private int store;
	void Start()
	{
		counterlabel = GameObject.Find("CandyCounter").GetComponent<UILabel> ();
	}
	void OnCollisionEnter2D(Collision2D collision) 
	{
		Debug.Log("Collision Detected"); //test


		if (collision.gameObject.tag == "Player") 
		{
			Destroy (gameObject);
			store = int.Parse(counterlabel.text);
			counterlabel.text = (store+1).ToString();
		}
	}
}
