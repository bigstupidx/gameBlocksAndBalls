using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Main_Menu_Highscore_Script : MonoBehaviour {

	public Canvas StartMenu;
	public Text HighScoreText;

	// Use this for initialization
	void Start () {
		if (Game_Controller.game_Count == 1) {
			Game_Controller.game_Count = 0;

		}
		GetScoresText ();
	}

	// Loads the Main Menu Scene
	public void MainMenu() {
		Application.LoadLevel (1);
	}

	// Exits the game
	public void ExitGame() {
		Application.Quit ();
	}
	//gets the high score to display on the main menu
	void GetScoresText() {
		int tmp = Game_Controller.highScore;

		HighScoreText.text = "HIGHSCORE: " + tmp;

		Game_Controller.highScore = tmp;
	}

}
