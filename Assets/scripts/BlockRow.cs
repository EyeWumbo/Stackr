using UnityEngine;
using System.Collections;

public class BlockRow : GlobalVariables {

	public GameObject[] rowBlocks = new GameObject[0];
	public bool isActive = true;
	public bool movingRight = true;

	//Treat this as the start function for BlockRow because it requires y_pos
	public void AssignAssetToBlock(int y_pos){
		System.Array.Resize(ref rowBlocks, TOTAL_COLUMNS);
		for (int i = 0; i < rowBlocks.Length; i++)
		{
			rowBlocks[i] = (GameObject)Instantiate(Resources.Load("SimpleBlock"));
			rowBlocks[i].name = "SimpleBlock" + i.ToString();
			rowBlocks[i].transform.parent = transform;
			rowBlocks[i].GetComponent<SimpleBlock>().ReceiveAssetForBlock(i, y_pos, 1, 1, 0);

			SetActiveInRow(i, false);
		}
	}

	public int GetActiveInRow()
	{
		int x = 0;
		for (int i = 0; i < rowBlocks.Length; i++)
		{
			x += (rowBlocks[i].GetComponent<SimpleBlock>().isActive)?1:0;
		}
		return x;
	}
	
	public void SetActiveInRow(int index, bool changeTo)
	{
		rowBlocks[index].GetComponent<SimpleBlock>().ChangeActive(changeTo);
	}

	public void UpdateRow()
	{
		if (movingRight) //Moving right
		{
			moveRight();
		}
		else //Moving left
		{
			moveLeft();
		}
	}

	void moveRight()
	{
		int startIndex = 0;
		int endIndex = 0;
		if (rowBlocks[rowBlocks.Length-1].GetComponent<SimpleBlock>().isActive)
		{
			movingRight = false;
			moveLeft();
		}
		else
		{
			while (startIndex < rowBlocks.Length)
			{
				if (rowBlocks[startIndex].GetComponent<SimpleBlock>().isActive)
				{
					break;
				}
				startIndex++;
			}
			endIndex = startIndex;
			while (endIndex < rowBlocks.Length)
			{
				if (!rowBlocks[endIndex].GetComponent<SimpleBlock>().isActive)
				{
					break;
				}
				endIndex++;
			}
			rowBlocks[startIndex].GetComponent<SimpleBlock>().ChangeActive(false);
			rowBlocks[endIndex].GetComponent<SimpleBlock>().ChangeActive(true);
		}
	}

	void moveLeft()
	{
		int startIndex = rowBlocks.Length - 1;
		int endIndex = rowBlocks.Length - 1;
		if (rowBlocks[0].GetComponent<SimpleBlock>().isActive)
		{
			movingRight = true;
			moveRight();
		}
		else
		{
			while (startIndex >= 0)
			{
				if (rowBlocks[startIndex].GetComponent<SimpleBlock>().isActive)
				{
					break;
				}
				startIndex--;
			}
			endIndex = startIndex;
			while (endIndex >= 0)
			{
				if (!rowBlocks[endIndex].GetComponent<SimpleBlock>().isActive)
				{
					break;
				}
				endIndex--;
			}
			rowBlocks[startIndex].GetComponent<SimpleBlock>().ChangeActive(false);
			rowBlocks[endIndex].GetComponent<SimpleBlock>().ChangeActive(true);
		}
	}
}
