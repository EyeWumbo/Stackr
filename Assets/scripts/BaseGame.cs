using UnityEngine;
using System.Collections;

public class BaseGame : GlobalVariables {

	public GameObject[] rowContainer = new GameObject[0];
	public GameObject easyPrize;
	public GameObject bestPrize;
	public int currentBlocks = 4;
	public int currentRow = -1;

	void Start()
	{
		//Set up BlockRows
		System.Array.Resize(ref rowContainer, TOTAL_ROWS);
		for (int i = 0; i < rowContainer.Length; i++)
		{
			rowContainer[i] = (GameObject)Instantiate(Resources.Load("BlockRow"));
			rowContainer[i].name = "BlockRow" + i.ToString();
			rowContainer[i].transform.parent = transform;
			rowContainer[i].GetComponent<BlockRow>().AssignAssetToBlock(i);
		}
		NextRow();
		InvokeRepeating("UpdateRow", 0, 0.1F);


		//Set up Prize lines
		easyPrize = (GameObject)Instantiate(Resources.Load("EasyPrize"));
		easyPrize.name = "EasyPrize";
		easyPrize.transform.parent = transform;
		easyPrize.GetComponent<PrizeRow>().ReceiveData(EASY_PRIZE_ROW,0,1,TOTAL_COLUMNS);

		bestPrize = (GameObject)Instantiate(Resources.Load("BestPrize"));
		bestPrize.name = "BestPrize";
		bestPrize.transform.parent = transform;
		bestPrize.GetComponent<PrizeRow>().ReceiveData(BEST_PRIZE_ROW,0,1,TOTAL_COLUMNS);
	}

	void Update ()
	{
		if (Camera.main.GetComponent<GlobalVariables>().INPUT_NORMAL_CLICK)
		{
			NextRow();
		}
		if (Input.GetKey(KeyCode.E))
		{
			print(rowContainer[currentRow].GetComponent<BlockRow>().GetActiveInRow());
		}
	}

	void UpdateRow()
	{
		rowContainer[currentRow].GetComponent<BlockRow>().UpdateRow();
	}

	void NextRow()
	{
		if (currentRow>0)
		{
			StackLogic();
			currentBlocks = rowContainer[currentRow].GetComponent<BlockRow>().GetActiveInRow();
		}
		currentRow++;
		for (int i = 0; i < currentBlocks; i++)
		{
			rowContainer[currentRow].GetComponent<BlockRow>().SetActiveInRow(i,true);
		}

	}

	void StackLogic()
	{
		for (int i = 0; i < rowContainer[currentRow].GetComponent<BlockRow>().rowBlocks.Length; i++)
		{
			if (rowContainer[currentRow].GetComponent<BlockRow>().rowBlocks[i].GetComponent<SimpleBlock>().isActive)
			{
				rowContainer[currentRow].GetComponent<BlockRow>().rowBlocks[i].GetComponent<SimpleBlock>().ChangeActive(
					rowContainer[currentRow-1].GetComponent<BlockRow>().rowBlocks[i].GetComponent<SimpleBlock>().isActive
						);
			}
		}
	}
}