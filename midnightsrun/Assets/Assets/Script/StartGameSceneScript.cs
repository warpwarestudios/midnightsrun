using UnityEngine;
using System.Collections;

public class StartGameSceneScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnClick () {
		Application.LoadLevel ("Main Game");
	}
}
