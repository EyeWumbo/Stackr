using UnityEngine;
using System.Collections;

public class BlockRow : MonoBehaviour {

	bool isActive = true;
	SimpleBlock[] totalBlocks = new SimpleBlock[7];
	int[] activeBlocks;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private bool getBelow(BlockRow row){
		return false;
	}
}
