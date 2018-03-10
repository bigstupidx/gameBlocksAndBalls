using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Game_Controller : MonoBehaviour {

	// Private Scripts
	private Ball_Spawner ballSpawner;
	private Bottom_Block_Spawner bottomBlockSpawner;
	private Top_Block_Spawner topBlockSpawner;
	private Ball_Script ballScript;
	//private GoogleAnalyticsV4 ga;

	// Public Variables
	public float speed_Incrementer;
	public GameObject ballSpawnerObject;
	public GameObject bottomBlockSpawnerObject;
	public GameObject topBlockSpawnerObject;
	public GameObject ballScriptObject;
	public GameObject gaObject;
	public int colorTimer;
	public Text score_Text;
	public Text ball_Text;
	
	// Static Variables
	public static int highScore;
	public static bool game_Over;
	public static float ball_Speed;
	public static int game_Count;
	public static bool light_Ball;
	public static bool block_Swap;
	public static bool Whiteness;
	public static int score;
	
	// Private Variables
	private int balls_Left;
	private bool spawnDarkBall;
	private bool spawnLightBall;

	// Use this for initialization
	void Start () {
		// Setting Variables
		Whiteness = true;
		colorTimer = 0;
		spawnDarkBall = false;
		spawnLightBall = true;
		balls_Left = 3;
		score = 0;
		ball_Speed = 2.5f;
		speed_Incrementer = 0.01f;
		game_Over = false;

		// Calling functions
		UpdateBalls ();
		UpdateScore ();
		InvokeRepeating ("blockSpeedUpdater", 1, 1);
		InvokeRepeating ("colorTimerIncrementor", 1, 1);

		// Assign Ball Spawner Script
		ballSpawnerObject = GameObject.FindWithTag ("Ball_Spawner");
		if (ballSpawnerObject != null) {
			ballSpawner = ballSpawnerObject.GetComponent <Ball_Spawner> ();
		}

		// Assign Bottom Block Spawner Script
		bottomBlockSpawnerObject = GameObject.FindWithTag ("Bottom_Block_Spawner");
		if (bottomBlockSpawnerObject != null) {
			bottomBlockSpawner = bottomBlockSpawnerObject.GetComponent <Bottom_Block_Spawner> ();
		}

		// Assign Top Block Spawner Script
		topBlockSpawnerObject = GameObject.FindWithTag ("Top_Block_Spawner");
		if (topBlockSpawnerObject != null) {
			topBlockSpawner = topBlockSpawnerObject.GetComponent <Top_Block_Spawner> ();
		}

		ballScriptObject = GameObject.FindWithTag ("Ball");
		if (ballScriptObject != null) {
			ballScript = ballScriptObject.GetComponent <Ball_Script> ();
		}
	}

	// Function for changing the colors
	void colorTimerIncrementor() {
		colorTimer += 1;
		if (colorTimer == 10) {
			colorTimer = 0;

			// Assign Ball_Script

		ballScriptObject = GameObject.FindWithTag ("Ball");
			if (ballScriptObject != null) {
				ballScript = ballScriptObject.GetComponent <Ball_Script> ();
			}

			if (spawnDarkBall) {
				Whiteness = true;
				spawnDarkBall = false;
				spawnLightBall = true;
				light_Ball = true;
				bottomBlockSpawner.SwapBottomBlocks ();
				topBlockSpawner.SwapTopBlocks();
				ballScript.ChangeBallColor();
			}
			else {
				Whiteness = false;
				spawnDarkBall = true;
				spawnLightBall = false;
				light_Ball = false;
				bottomBlockSpawner.SwapBottomBlocks ();
				topBlockSpawner.SwapTopBlocks();
				ballScript.ChangeBallColor();
			}

		}

	}

	// Called every frame
	void Update () {

		// This prevents balls from spawning when ball count is at 0
		if (balls_Left >= 1 && spawnDarkBall) {
			ballSpawner.NewDarkBall ();
		} else if (balls_Left >= 1 && spawnLightBall) {
			ballSpawner.NewLightBall ();
		}

		// Prevents ball count from being less than 0
		if (balls_Left < 0) {
			balls_Left = 0;
			UpdateBalls();
		}

		// Activates fail state
		if (balls_Left == 0) {
			game_Over = true;
			Application.LoadLevel(3);
			game_Count++;
		}
	}

	// Function called to add to score
	public void AddScore (int x) {
		score += x;
		UpdateScore ();
	}

	// Function called to decrement the ball count
	public void DecrementBall () {
		balls_Left--;
		UpdateBalls ();
	}

	//Increases ball count
	public void IncrementBall() {
		balls_Left++;
		UpdateBalls ();
	}

	//Reduces score
	public void SubtractScore (int x) {
		if (score > 0) {
			score -= x;
			UpdateScore ();
		}
	}

	// Function called to update score text
	public void UpdateScore() {
		score_Text.text = "SCORE: " + score;
	}

	// Function called to update the balls left text
	void UpdateBalls() {
		ball_Text.text = "BALLS LEFT: " + balls_Left;
	}

	// Block speed updater
	void  blockSpeedUpdater() {
		ball_Speed += speed_Incrementer;
	}
}
