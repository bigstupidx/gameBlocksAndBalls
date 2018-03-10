using UnityEngine;
using System.Collections;

public class Options_Brick : MonoBehaviour {

	// Public Variables
	public Transform startMarker;
	public Transform endMarker;
	public Texture Options_Brick_Black;
	public float speed = 5.0f;

	// Private Variables
	private float startTime;
	private float journeyLength;

	// Use this for initialization
	void Start () {
		GetComponent<Renderer>().material.mainTexture = Options_Brick_Black;
		startTime = Time.time;
		journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
	}
	
	// Update is called once per frame
	void Update () {
		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;
		transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
	}

/*	void OnMouseOver() {
		if (Input.GetMouseButtonDown(0)) {
			Application.LoadLevel(4);
		}
	}
*/
}
