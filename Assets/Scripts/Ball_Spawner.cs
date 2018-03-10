using UnityEngine;
using System.Collections;

public class Ball_Spawner : MonoBehaviour {

	// Private Scripts
	private Game_Controller gameController;

	// Public Variables
	public float timeLeft = 0.2f; 
	public Rigidbody rbdb;
	public Rigidbody rblb;
	public Vector3 ball_Spawn_Location = new Vector3 (0, 0, 0);
	public int colorTimer;

	public static bool sendItUp;
	public static bool sendItDown;
	public static bool new_Ball_Check = true;

	private bool spawnDarkBall;
	
	// Use this for initialization
	void Start () {
		colorTimer = 0;
		timeLeft = 0.2f;
		spawnDarkBall = false;
		Instantiate(rblb, ball_Spawn_Location, Quaternion.Euler(90, 0, 0));
		InvokeRepeating ("colorTimerIncrementor", 1, 1);
		new_Ball_Check = true;
	}
	
	// Update is called once per frame
	void Update () {
		//counts down time to spawn a new ball if one was recently shot down or up
		if (new_Ball_Check == false) {
			timeLeft -= Time.deltaTime;
		}
	}
	//alternates color every ten seconds
	void colorTimerIncrementor() {
		colorTimer += 1;
		if (colorTimer == 10) {
			colorTimer = 0;
			if (spawnDarkBall) {
				spawnDarkBall = false;;
			}
			else {
				spawnDarkBall = true;
			}
		}
	}

	// Controls the spawn ball timer and spawns a new dark ball
	public void NewDarkBall () {
		if (timeLeft < 0) {
			Instantiate (rbdb, ball_Spawn_Location, Quaternion.Euler(90, 0, 0));
			new_Ball_Check = true;
			timeLeft = 0.2f;
		}
	}
	//spawns a new light ball and resets the spawn timer
	public void NewLightBall () {
		if (timeLeft < 0) {
			Instantiate (rblb, ball_Spawn_Location, Quaternion.Euler(90, 0, 0));
			new_Ball_Check = true;
			timeLeft = 0.2f;
		}
	}
	//tells ball to shoot upwards
	public static void SpawnUp() {
		sendItUp = true;
	}
	//tells ball to shoot downwards
	public static void SpawnDown() {
		sendItDown = true;

	}
	
}