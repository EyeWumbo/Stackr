using UnityEngine;
using System.Collections;

public class AndroidTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Space) || Input.touchCount > 0)
		{
			transform.renderer.material.color = new Color(	transform.renderer.material.color.r + 1,
		                  									transform.renderer.material.color.g + 1,
			                    	            			transform.renderer.material.color.b + 1);
		}
	}
}
