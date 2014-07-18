using UnityEngine;
using System.Collections;

public class SimpleBlock : MonoBehaviour {

	public bool isActive = false;
	private int x;
	private int y;

	void Update ()
	{
		rescale();
	}

	public void ReceiveAssetForBlock(int x_pos, int y_pos)
	{
		x = x_pos;
		y = y_pos;
	}

	public void ChangeActive(bool changeTo)
	{
		isActive = changeTo;
		GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Block" + (changeTo?1:0).ToString());
	}

	//Manages the rescaling based on different screen sizes
	private void rescale()
	{
		//Get resources
		SpriteRenderer sr = GetComponent<SpriteRenderer>();
		if (sr == null) return;
		transform.localScale = new Vector3(1,1,1);

		//Find dimensions of sprite when rendered
		float spriteWidth = sr.sprite.bounds.size.x;
		float spriteHeight = sr.sprite.bounds.size.y;

		//Find dimensions of camera view when rendered
		float workingHeight = Camera.main.orthographicSize * 2f - Camera.main.GetComponent<GlobalVariables>().PAD_Y;
		float workingWidth = workingHeight / Screen.height * Screen.width - Camera.main.GetComponent<GlobalVariables>().PAD_X;

		float scale = 0;
		if (workingWidth/workingHeight > (float)Camera.main.GetComponent<GlobalVariables>().TOTAL_COLUMNS/Camera.main.GetComponent<GlobalVariables>().TOTAL_ROWS) //Too wide, center by X
		{
			//Resize sprite
			scale = workingHeight / spriteHeight / Camera.main.GetComponent<GlobalVariables>().TOTAL_ROWS;
			transform.localScale = new Vector2(scale, scale);

			//Reposition sprite
			transform.position =	new Vector2(x * workingHeight / Camera.main.GetComponent<GlobalVariables>().TOTAL_ROWS, y * workingHeight / Camera.main.GetComponent<GlobalVariables>().TOTAL_ROWS) - 
									new Vector2(workingWidth / 2, workingHeight / 2) +
									new Vector2((workingWidth - Camera.main.GetComponent<GlobalVariables>().TOTAL_COLUMNS * scale * spriteWidth)/2, 0);
		}
		else //Too tall, center by Y
		{
			//Resize sprite
			scale = workingWidth / spriteWidth / Camera.main.GetComponent<GlobalVariables>().TOTAL_COLUMNS;
			transform.localScale = new Vector2(scale, scale);

			//Reposition sprite
			transform.position =	new Vector2(x * workingWidth / Camera.main.GetComponent<GlobalVariables>().TOTAL_COLUMNS, y * workingWidth / Camera.main.GetComponent<GlobalVariables>().TOTAL_COLUMNS) -
									new Vector2(workingWidth / 2, workingHeight / 2) +
									new Vector2(0, (workingHeight - Camera.main.GetComponent<GlobalVariables>().TOTAL_ROWS * scale * spriteHeight)/2);
		}
	}
}
