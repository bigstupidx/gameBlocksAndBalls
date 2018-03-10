using UnityEngine;
using System.Collections;

public class Top_Block_Spawner : MonoBehaviour {

	// Public Variables
	public GameObject Top_Block;
	public GameObject Bad_Top_Block;
	public GameObject Extra_Ball_Block_Top;
	public Vector3 spawnLocation = new Vector3 (1, 1, 0);
	public float spawnTime = 2;
	public int good_Or_Bad = 0;

	// Use this for initialization
	void Start () {
		//runs the blocks color randomizer every set interval of time
		InvokeRepeating("add_Block", spawnTime, spawnTime);
	}

	// Use for adding a block
	void add_Block() {
		// randomly determines which type of block to add
		good_Or_Bad = Random.Range (1, 50);
	}
	
	// Update is called once per frame
	void Update () {
		if (good_Or_Bad < 25  && good_Or_Bad >= 1) {
			//spawns normal top block
			Instantiate (Top_Block, spawnLocation, Quaternion.identity);
			good_Or_Bad = 0;
		}
		
		else if (good_Or_Bad >= 25 && good_Or_Bad <= 48) {
			//spawns bad top block
			Instantiate (Bad_Top_Block, spawnLocation, Quaternion.identity);
			good_Or_Bad = 0;
		}
		
		else if (good_Or_Bad == 49) {
			//spawns extra balls (flashing) block
			Instantiate (Extra_Ball_Block_Top, spawnLocation, Quaternion.identity);
			good_Or_Bad = 0;
		}
	}

	//switches which blocks are considered bad and good, so the points are added for hitting the correct color of block
	public void SwapTopBlocks() {
		GameObject tmp = Top_Block;
		Top_Block = Bad_Top_Block;
		Bad_Top_Block = tmp;
	}
}
