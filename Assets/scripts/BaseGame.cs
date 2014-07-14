using UnityEngine;
using System.Collections;

public class BaseGame : MonoBehaviour {

	BlockRow[] rowContainer = new BlockRow[7];
	int currentBlocks = 4;
	GameObject gameDisplay;

	// Use this for initialization
	void Start () {
		gameDisplay = GameObject.FindGameObjectWithTag("ForegroundLevel");
		int dimension = 64, margin = 16, x_pos = 1, y_pos = 1;
		foreach(Transform child in gameDisplay.transform){
			foreach(Transform box in child){

			}
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
