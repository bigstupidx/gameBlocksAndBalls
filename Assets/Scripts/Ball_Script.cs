using UnityEngine;
using System.Collections;

public class Ball_Script : MonoBehaviour {

	// Private Scripts
	private Game_Controller gameController;

	// Public Variables 
	public Rigidbody rb;
	public bool destroy_Balls;
	public Texture blackball;
	public Texture whiteball;

	// Private Variables
	private bool launched = false;
	private bool up = false;
	private bool down = false;

	// Use this for initialization
	void Start () {
		launched = false;
		// Gets this GameObjects Rigidbody
		rb = GetComponent<Rigidbody> ();
		//sets the texture of the block to black or white depending on the phase the game is in
		if (Game_Controller.Whiteness) {
			GetComponent<Renderer>().material.mainTexture = whiteball;
		} else if (!(Game_Controller.Whiteness)) {
			GetComponent<Renderer>().material.mainTexture = blackball;
		}


		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <Game_Controller>();
		}

	}

	// Function called on-collision 
	void OnCollisionEnter (Collision col) {


		int normal_Block_Points = 1;
		if (Game_Controller.Whiteness) {
			//destroys the object during a collision
			if (col.gameObject.tag == "Normal_Block" || col.gameObject.tag == "Out_of_Bounds" || col.gameObject.tag == "Bad_Block" || col.gameObject.tag == "Extra_Ball_Block") {
				Destroy (this.gameObject);
			}
			if (col.gameObject.tag == "Normal_Block") {
				//rewards points if it hits the correct color of block
				gameController.AddScore (normal_Block_Points);
			}
			if (col.gameObject.tag == "Out_of_Bounds" || col.gameObject.tag == "Bad_Block") {
				//lowers the ball count if it hits the wrong color of block
				gameController.DecrementBall ();
			}
			if (col.gameObject.tag == "Bad_Block") {
				//reduces score if it hits wrong color of block
				gameController.SubtractScore (normal_Block_Points);
			}
		}

		if (!(Game_Controller.Whiteness)) {
			//destroys the object during a collision
			if (col.gameObject.tag == "Normal_Block" || col.gameObject.tag == "Out_of_Bounds" || col.gameObject.tag == "Bad_Block" || col.gameObject.tag == "Extra_Ball_Block") {
				Destroy (this.gameObject);
			}
			if (col.gameObject.tag == "Bad_Block") {
				//rewards points if it hits the correct color of block
				gameController.AddScore (normal_Block_Points);
			}
			if (col.gameObject.tag == "Out_of_Bounds" || col.gameObject.tag == "Normal_Block") {
				//lowers the ball count if it hits the wrong color of block
				gameController.DecrementBall ();
			}
			if (col.gameObject.tag == "Normal_Block") {
				//reduces score if it hits wrong color of block
				gameController.SubtractScore (normal_Block_Points);
			}
		}

		if (col.gameObject.tag == "Extra_Ball_Block") {
			//adds points and increases ball count if it hits a flashing block
			gameController.IncrementBall ();
			gameController.AddScore(normal_Block_Points);
		}

	}

	// Update is called once per frame
	void Update () {
		// Controls Fire Up
	if (Ball_Spawner.sendItUp && launched == false) {
				rb.velocity = new Vector3 (0, 12, 0);
			Ball_Spawner.sendItUp = false;
			Ball_Spawner.new_Ball_Check = false;
			launched = true;

		}

		// Controls Fire Down
		if (Ball_Spawner.sendItDown && launched == false) {
				rb.velocity = new Vector3 (0, -12, 0);
			Ball_Spawner.sendItDown = false;
			Ball_Spawner.new_Ball_Check = false;
			launched = true;
		}

		// Makes ball proper color
		if (Game_Controller.Whiteness) {
			GetComponent<Renderer>().material.mainTexture = whiteball;
		} else if (!(Game_Controller.Whiteness)) {
			GetComponent<Renderer>().material.mainTexture = blackball;
		}
	}

	public void ChangeBallColor () {

		if (Game_Controller.light_Ball) {
			GetComponent<Renderer>().material.mainTexture = whiteball;
			Debug.Log("made it light!");
		}

		if (!(Game_Controller.light_Ball)) {
			GetComponent<Renderer>().material.mainTexture = blackball;
			Debug.Log("made it dark!");
		}
	} 
}