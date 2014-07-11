using UnityEngine;
using System.Collections;

public class BlockRow : MonoBehaviour {

	bool isActive = true;
	SimpleBlock[] totalBlocks = SimpleBlock[7];
	int[] activeBlocks;

	public BlockRow(int numBlocks, float speed){
		for(int i = 0; i < 7; i ++){
			totalBlocks = new SimpleBlock();
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private bool getBelow(BlockRow row){

	}
}
