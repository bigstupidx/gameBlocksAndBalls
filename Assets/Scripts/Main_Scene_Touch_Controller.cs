using UnityEngine;
using System.Collections;

public class Main_Scene_Touch_Controller : MonoBehaviour {

	public float timeBeforePress = 1;
	public bool pressActive = false;
	// Use this for initialization
	void Start () {
		timeBeforePress = 1;
		pressActive = false;
	}
	
	// Update is called once per frame
	void Update () {
		//prevents accidental touches on screen as soon as the game begins
		if (timeBeforePress > 0) {
			timeBeforePress -= Time.deltaTime;
		}
		if (timeBeforePress <= 0) {
			pressActive = true;
		}

		//touch controls
		if ( Input.touchCount != 0 && Input.GetTouch(0).phase == TouchPhase.Began)
		{
			Touch touch = Input.touches[0];
			Ray ray = Camera.main.ScreenPointToRay(touch.position);
			RaycastHit hit;
			
			if ( Physics.Raycast(ray, out hit, 100f ) )
			{
				Debug.Log(hit.transform.gameObject.name);
				//tells the ball to shoot upwards if the top half of the screen is touched
				if(hit.transform.gameObject.name == "Button Top") {
				Ball_Spawner.SpawnUp();
				}
				//tells the ball to shoot downward if the bottom half of the screen is touched
				if(hit.transform.gameObject.name == "Button Bottom") {
					Ball_Spawner.SpawnDown();
				}
			}
		}
		//mouse controls
		if (Input.GetMouseButtonDown (0) && pressActive == true && Input.touchCount == 0) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			
			if ( Physics.Raycast(ray, out hit, 100f ) )
			{
				Debug.Log(hit.transform.gameObject.name);
				//click on top half shoots ball up
				if(hit.transform.gameObject.name == "Button Top") {
					Ball_Spawner.SpawnUp();
				}
				//click on bottom half shoots ball down
				if(hit.transform.gameObject.name == "Button Bottom") {
					Ball_Spawner.SpawnDown();
				}
			}
		}

}

}
