using UnityEngine;
using System.Collections;

public class PrizeRow : CustomGUI {

	void Start()
	{
		renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, 0);
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
