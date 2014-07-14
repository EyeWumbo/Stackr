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

	public void assignAssetToBlock(int y_pos){
		int x_pos = 1;
		GameObject obj = transform.gameObject;
		int margin =  (int)(Camera.main.pixelWidth * 0.1 / 8), size = (int)(Camera.main.pixelWidth * 0.9 / 7 / Screen.height);
		transform.position = new Vector2(
			(x_pos * margin + (x_pos - 1) * size),
			 y_pos * margin + (y_pos - 1) * size
		);
		foreach(Transform box in obj.transform){
			box.GetComponent<SimpleBlock>().receiveAssetForBlock(x_pos, y_pos);
			x_pos ++;
		}
	}

	private bool getBelow(BlockRow row){
		return false;
	}
}
