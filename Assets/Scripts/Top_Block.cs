using UnityEngine;
using System.Collections;

public class Top_Block : MonoBehaviour {

	public Rigidbody rb;
	public Texture Top_Block_White;
	
	// Use this for initialization
	void Start () {
		GetComponent<Renderer>().material.mainTexture = Top_Block_White;
		rb.GetComponent<Rigidbody> ();
		GetComponent<Rigidbody>().freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update () {
		//sets speed of block
		rb.velocity = new Vector3(-Game_Controller.ball_Speed, 0, 0);
	}

	void OnCollisionEnter (Collision col) {
		//destroys blocks if it is hit by a ball or goes off screen
		if (col.gameObject.tag == "Ball" || col.gameObject.tag == "Out_of_Bounds") {
			Destroy (this.gameObject);
		}
	}
}
