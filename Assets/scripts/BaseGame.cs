using UnityEngine;
using System.Collections;

public class BaseGame : MonoBehaviour {

	BlockRow[] rowContainer = new BlockRow[7];
	int currentBlocks = 4;
	GameObject gameDisplay;

	// Use this for initialization
	void Start () {
		gameDisplay = transform.gameObject;
		for(int i = 0; i < 12; i ++){
			GameObject obj = (GameObject) Instantiate (Resources.Load ("BlockRow"));
			obj.name = "BlockRow";
			obj.transform.parent = gameDisplay.transform;
			obj.GetComponent<BlockRow>().assignAssetToBlock(i);
		}
	}
	
	// Update is called once per frame
	void Update () {
		//Apply update logic to BaseGame.
//		foreach (Touch t in Input.touches){
//			Debug.Log ("Screen was pressed");
//		}
		Touch t = new Touch();
		if(t.tapCount > 0){
			Debug.Log ("SHIEEEET");
		}
	}
}
