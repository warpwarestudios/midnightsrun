using UnityEngine;
using System.Collections;

public class CandyPoints : MonoBehaviour {

	public UILabel counterlabel;
	private int store;

	void OnCollisionEnter(Collision collision) 
	{
		Debug.Log("Collision Detected"); //test

		counterlabel = GameObject.Find ("CandyCounter").GetComponent<UILabel> ();

		if (collision.gameObject.name == "Midnight") 
		{
			Destroy (gameObject);
			store = int.Parse(counterlabel.text);
			counterlabel.text = (store+1).ToString();
		}
	}
}
