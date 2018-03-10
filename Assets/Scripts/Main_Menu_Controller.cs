using UnityEngine;
using System.Collections;

public class Main_Menu_Controller : MonoBehaviour {

	public GameObject Play_Game_Brick;
	public GameObject gaObject;
	// Options Brick
	// public GameObject Options_Brick;
	public GameObject And_Brick;

	private Vector3 Play_Game_Brick_Starting_Location;
	// Options Brick
	// private Vector3 Options_Brick_Starting_Location;
	private Vector3 And_Brick_Starting_Location;

	// Use this for initialization
	void Start () {
		//sets starting location of play game button
		Play_Game_Brick_Starting_Location = new Vector3(10,0,0);

		// Options Brick
		// Options_Brick_Starting_Location = new Vector3(-10,-2,0);

		//sets starting location of the And brick
		And_Brick_Starting_Location = new Vector3(-2,2,0);

		//spawns the bricks/buttons
		Instantiate (Play_Game_Brick, Play_Game_Brick_Starting_Location, Quaternion.Euler (90, 0, 0));
		// Options Brick 
		// Instantiate (Options_Brick, Options_Brick_Starting_Location, Quaternion.Euler (90, 0, 0));
		Instantiate (And_Brick, And_Brick_Starting_Location, Quaternion.Euler (90,0,0));
	}
	
	// Update is called once per frame
	void Update () {
	}
}
