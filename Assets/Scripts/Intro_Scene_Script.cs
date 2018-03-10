using UnityEngine;
using System.Collections;

public class Intro_Scene_Script : MonoBehaviour {

	private int delay = 3;

	// Use this for initialization
	void Start () {

		Game_Controller.game_Count = 0;
		Invoke ("LoadMainMenu", delay);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//loads the menu scene after showing the beautiful onyx logo for 3 seconds
	void LoadMainMenu() {
		Application.LoadLevel (1);
	}
}
