using UnityEngine;
using System.Collections;

public class Bad_Bottom_Block : MonoBehaviour {

	public Rigidbody rb;
	public Texture Bottom_Block_Black;
	
	// Use this for initialization
	void Start () {
		//gets rigidbody component and sets the texture of the prefab
		rb.GetComponent<Rigidbody> ();
		GetComponent<Renderer>().material.mainTexture = Bottom_Block_Black;
		GetComponent<Rigidbody>().freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update () {
		//sets the speed of the block
		rb.velocity = new Vector3(Game_Controller.ball_Speed, 0, 0);
	}
	
	void OnCollisionEnter (Collision col) {
		//destroys the block if it hits a ball or goes off screen
		if (col.gameObject.tag == "Ball" || col.gameObject.tag == "Out_of_Bounds") {
			Destroy (this.gameObject);
		}
	}
}
