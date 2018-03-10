using UnityEngine;
using System.Collections;

public class Main_Menu_Touch_Controller : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//touch controls
		if ( Input.touchCount != 0 && Input.GetTouch(0).phase == TouchPhase.Began)
		{
			Touch touch = Input.touches[0];
			Ray ray = Camera.main.ScreenPointToRay(touch.position);
			RaycastHit hit;

			//if player taps the play game brick, load the main scene to play the game
			if ( Physics.Raycast(ray, out hit, 100f ) )
			{
				Debug.Log(hit.transform.gameObject.name);
				if(hit.transform.gameObject.name == "Play_Game_Brick(Clone)") {
					Application.LoadLevel(2);
				}
			}
		}

		//mouse controls
		if (Input.GetMouseButtonDown (0) && Input.touchCount == 0) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			//if mouse clicks play game button, load the main scene to play the game
			if ( Physics.Raycast(ray, out hit, 100f ) )
			{
				Debug.Log(hit.transform.gameObject.name);
				if(hit.transform.gameObject.name == "Play_Game_Brick(Clone)") {
					Application.LoadLevel(2);
				}
			}
		}

}

}
