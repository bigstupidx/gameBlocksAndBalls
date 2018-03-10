using UnityEngine;
using System.Collections;

public class Bottom_Block_Spawner : MonoBehaviour {

	// Public Variables
	public GameObject Bottom_Block;
	public GameObject Bad_Bottom_Block;
	public GameObject Extra_Ball_Block_Bottom;
	public Vector3 spawnLocation = new Vector3 (1, 1, 0);
	public float spawnTime = 2;
	public int good_Or_Bad = 0;
	
	// Use this for initialization
	void Start () {
		//runs the blocks color randomizer every set interval of time
		InvokeRepeating("add_Block", spawnTime, spawnTime);
	}
	
	// randomly determines which type of block to add
	void add_Block() {
		good_Or_Bad = Random.Range (1, 50);
	}
	
	// Update is called once per frame
	void Update () {
		//spawns normal bottom block
		if (good_Or_Bad < 25  && good_Or_Bad >= 1) {
			Instantiate (Bottom_Block, spawnLocation, Quaternion.identity);
			good_Or_Bad = 0;
		}

		//spawns bad bottom block
		else if (good_Or_Bad >= 25 && good_Or_Bad <= 48) {
			Instantiate (Bad_Bottom_Block, spawnLocation, Quaternion.identity);
			good_Or_Bad = 0;
		}

		//spawns extra balls (flashing) block
		else if (good_Or_Bad == 49) {
			Instantiate (Extra_Ball_Block_Bottom, spawnLocation, Quaternion.identity);
			good_Or_Bad = 0;
		}
	}

	//switches which blocks are considered bad and good, so the points are added for hitting the correct color of block
	public void SwapBottomBlocks() {
		GameObject tmp = Bottom_Block;
		Bottom_Block = Bad_Bottom_Block;
		Bad_Bottom_Block = tmp;
	}
}
