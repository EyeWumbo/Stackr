using UnityEngine;
using System.Collections;

public class PrizeRow : CustomGUI {

	void Start()
	{
		CustomLogicVisibility(false);
	}

	void Update()
	{
		Rescale();

		if (Input.GetKeyDown(KeyCode.Q))
		{
			CustomLogicVisibility(true);
		}
		if (Input.GetKeyDown(KeyCode.W))
		{
			CustomLogicVisibility(false);
		}
		LogicFade();
	}

	public void ReceiveData(int row, int column, int rowsAsHeight, int columnsAsWidth, int layer)
	{
		x = column;
		y = row;
		rX = columnsAsWidth;
		rY = rowsAsHeight;
		l = layer;
	}
	
}
