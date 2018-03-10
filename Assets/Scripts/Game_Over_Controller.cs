using UnityEngine;
using System.Collections;
using System;
//using GoogleMobileAds;
//using GoogleMobileAds.Api;

public class Game_Over_Controller : MonoBehaviour {
	
	public GameObject Play_Game_Brick;
	public GameObject And_Brick;
	public GameObject gaObject;

	public static int gameOverCount = 0;

	public static bool showAd;
	
	private Vector3 Play_Game_Brick_Starting_Location;
	private Vector3 And_Brick_Starting_Location;
	
	// Use this for initialization
	void Start () {
		//tracks the number of times the game over scene was reached
		Debug.Log ("goc" + gameOverCount);
		Debug.Log (Application.loadedLevel);
		//sets spawning locations and spawns play game block and the And block
		Play_Game_Brick_Starting_Location = new Vector3 (10, 0, 0);
		And_Brick_Starting_Location = new Vector3 (-2, 2, 0);
		Instantiate (Play_Game_Brick, Play_Game_Brick_Starting_Location, Quaternion.Euler (90, 0, 0));
		Instantiate (And_Brick, And_Brick_Starting_Location, Quaternion.Euler (90, 0, 0));
		//if it is not time to show an ad, increase the game over count (iOS version is currently ad free)
		if(gameOverCount != 13) {
			gameOverCount ++;
		}
	}
}