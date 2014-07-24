using UnityEngine;
using System.Collections;

public class SimpleBlock : CustomGUI {

	public bool isActive = false;

	void Update()
	{
		Rescale();
	}

	public void ReceiveAssetForBlock(int row, int column, int rowsAsHeight, int columnsAsWidth, int layer)
	{
		x = row;
		y = column;
		rX = columnsAsWidth;
		rY = rowsAsHeight;
		l = layer;
	}

	public void ChangeActive(bool changeTo)
	{
		isActive = changeTo;
		GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Block" + (changeTo?1:0).ToString());
	}
}
