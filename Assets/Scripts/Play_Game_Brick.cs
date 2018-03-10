﻿using UnityEngine;
using System.Collections;

public class Play_Game_Brick : MonoBehaviour {

	public Transform startMarker;
	public Transform endMarker;
	public float speed = 5.0f;
	public Texture Play_Game_Brick_Black;

	private float startTime;
	private float journeyLength;

	// Use this for initialization
	void Start () {
		//gets texture for play brick
		GetComponent<Renderer>().material.mainTexture = Play_Game_Brick_Black;
		startTime = Time.time;
		journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
	}
	
	// Update is called once per frame
	void Update () {
		//makes smooth movement from start position to end position
		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;
		transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
	}

}
