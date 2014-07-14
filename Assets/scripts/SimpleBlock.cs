using UnityEngine;
using System.Collections;

public class SimpleBlock : MonoBehaviour {

	bool isActive = true;
	bool isBackground = true;

	// Use this for initialization
	void Start () {

	}

	public void receiveAssetForBlock(int x_pos, int y_pos){
		int margin =  (int)(Camera.main.pixelWidth * 0.1 / 8), size = (int)(Camera.main.pixelWidth * 0.9 / 7 / Screen.height);
		transform.position = new Vector2(
			(x_pos * margin + (x_pos - 1) * size),
			y_pos * margin + (y_pos - 1) * size
		);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
