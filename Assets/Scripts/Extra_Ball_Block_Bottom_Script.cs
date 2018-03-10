using UnityEngine;
using System.Collections;

public class Extra_Ball_Block_Bottom_Script : MonoBehaviour {
		
	public Rigidbody rb;
	public Texture Light_Tex;
	public Texture Dark_Tex;
	public MeshRenderer rend;
	public float flash_Time;
	public bool isLight;
		
	// Use this for initialization
	void Start () {
		flash_Time = 0.2f;
		rb.GetComponent<Rigidbody> ();
		GetComponent<Rigidbody>().freezeRotation = true;
		rend.GetComponent<MeshRenderer> ();
		isLight = true;
		InvokeRepeating ("ChangeEmUpBottom", flash_Time, flash_Time);
	}
		
	// Update is called once per frame
	void Update () {
		//sets block speed
		rb.velocity = new Vector3(Game_Controller.ball_Speed, 0, 0);
	}

	//destroys on collision
	void OnCollisionEnter (Collision col) {
		if (col.gameObject.tag == "Ball" || col.gameObject.tag == "Out_of_Bounds") {
			Destroy (this.gameObject);
		}
	}
		
	//alternates the colors of the flashing block
	void ChangeEmUpBottom() {
		if (isLight) {
			rend.material.mainTexture = Dark_Tex;
			isLight = false;
		} else {
			rend.material.mainTexture = Light_Tex;
			isLight = true;
		}
	}
}
