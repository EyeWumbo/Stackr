using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

	int[][] rowContainer = new int[12][7];

	// Use this for initialization
	void Start () {
	
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
