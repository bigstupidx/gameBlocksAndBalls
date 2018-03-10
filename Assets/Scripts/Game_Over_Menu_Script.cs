using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Game_Over_Menu_Script : MonoBehaviour {

	public Canvas GameOverMenu;
	public Text HighScoreText;
	public Text ScoreText;

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

	void GetScoresText() {
		//if your score is higher than the highscore, your score becomes the new highscore
		int tmp = Game_Controller.highScore;
		if (Game_Controller.highScore < Game_Controller.score) {
			tmp = Game_Controller.score;
			//displays the new highscore that was achieved
			HighScoreText.text = "NEW HIGHSCORE! HIGHSCORE: " + tmp;

		}
		else {
			//shows the current highscore and your not-so-high score
			HighScoreText.text = "HIGHSCORE: " + tmp + "\t\tSCORE: " + Game_Controller.score;
		}
		//lets the game controller and save manager know what your score was
		Game_Controller.highScore = tmp;
		Save_Manager.manager.savedHighscore = tmp;
		Save_Manager.manager.Save();
	}

}
