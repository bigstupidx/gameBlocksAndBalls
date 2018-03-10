using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Menu_Script : MonoBehaviour {

	// Public Variables
	public Canvas start_Menu;
	public Button PlayGameButton;
	public Button OptionsButton;


	// Use this for initialization
	void Start () {
	}

	// Loads the Main Game Scene
	public void PlayGame() {
		Application.LoadLevel (2);
	}

	// Loads the Options Scene (was removed)
	public void Options() {
		Application.LoadLevel (3);
	}

	// Exits the game
	public void ExitGame() {
		Application.Quit ();
	}
}