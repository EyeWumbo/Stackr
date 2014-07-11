using UnityEngine;
using System.Collections;

public class BaseGame : MonoBehaviour {

	int[] rowContainer = new BlockRow[7];
	int currentBlocks = 4;

	// Use this for initialization
	void Start () {
		rowContainer[0] = new BlockRow();
	}
	
	// Update is called once per frame
	void Update () {
		//Apply update logic to BaseGame.
//		foreach (Touch t in Input.touches){
//			Debug.Log ("Screen was pressed");
//		}
		if(Touch.tapCount > 0){
			Debug.Log ("SHIEEEET");
		}
	}
}
