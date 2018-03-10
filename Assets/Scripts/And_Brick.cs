using UnityEngine;
using System.Collections;

public class And_Brick : MonoBehaviour {

	public Vector3 startMarker;
	public Vector3 endMarker;
	public Texture And_Brick_White;

	private bool onScene = true;

	// Use this for initialization
	IEnumerator Start () {
		GetComponent<Renderer>().material.mainTexture = And_Brick_White;
		//sets up the And block to move between two points
		while(onScene) {
			yield return StartCoroutine(MoveObject(transform, startMarker, endMarker, 2.0f));
			yield return StartCoroutine(MoveObject(transform, endMarker, startMarker, 2.0f));
		}
		GetComponent<Rigidbody>().freezeRotation = true;
	}
	
	// Update is called once per frame
	IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time){
		float i = 0.0f;
		float rate = 1.0f / time;
		while (i < 1.0f) {
			i += Time.deltaTime * rate;
			thisTransform.position = Vector3.Lerp(startPos, endPos, i); //moves the and block between the two determined points
			yield return null;
		}
	}
}
