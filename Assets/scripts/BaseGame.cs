using UnityEngine;
using System.Collections;

public class BaseGame : GlobalVariables {

	public GameObject[] rowContainer = new GameObject[0];
	public GameObject easyPrize;
	public GameObject bestPrize;
	public int currentBlocks;
	public int currentRow;
	public ArrayList inputLog = new ArrayList();

	void Start()
	{
		Identify();
		Reset();
	}

	void Identify()
	{
		print(SystemInfo.deviceUniqueIdentifier);
	}

	void Reset()
	{
		//Initial variables
		currentBlocks = 4;
		currentRow = -1;

		//Set up BlockRows
		if (rowContainer.Length > 0)
		{
			for (int i = 0; i < rowContainer.Length; i++)
			{
				Destroy(rowContainer[i].gameObject);
			}
		}
		CancelInvoke();
		System.Array.Resize(ref rowContainer, TOTAL_ROWS);
		for (int i = 0; i < rowContainer.Length; i++)
		{
			rowContainer[i] = (GameObject)Instantiate(Resources.Load("BlockRow"));
			rowContainer[i].name = "BlockRow" + i.ToString();
			rowContainer[i].transform.parent = transform;
			rowContainer[i].GetComponent<BlockRow>().AssignAssetToBlock(i);
		}

		//Set up Prize lines
		if (easyPrize != null)
		{
			Destroy(easyPrize);
		}
		if (bestPrize != null)
		{
			Destroy(bestPrize);
		}
		easyPrize = (GameObject)Instantiate(Resources.Load("EasyPrize"));
		easyPrize.name = "EasyPrize";
		easyPrize.transform.parent = transform;
		easyPrize.GetComponent<PrizeRow>().ReceiveData(EASY_PRIZE_ROW,0,1,TOTAL_COLUMNS, -1);
		
		bestPrize = (GameObject)Instantiate(Resources.Load("BestPrize"));
		bestPrize.name = "BestPrize";
		bestPrize.transform.parent = transform;
		bestPrize.GetComponent<PrizeRow>().ReceiveData(BEST_PRIZE_ROW,0,1,TOTAL_COLUMNS, -1);

		//Set up game and start
		NextRow();
		InvokeRepeating("UpdateRow", 0, 0.1F);
	}

	void FixedUpdate()
	{
		if (Camera.main.GetComponent<GlobalVariables>().INPUT_NORMAL_CLICK)
		{
			inputLog.Add(Time.time);
			NextRow();
		}

		if (Input.GetKeyDown(KeyCode.A))
		{
			Reset();
			for (int i = 0; i < inputLog.Count; i++)
			{
				Invoke("NextRow",(float)inputLog[i]);
			}
		}
	}

	void UpdateRow()
	{
		rowContainer[currentRow].GetComponent<BlockRow>().UpdateRow();
	}

	void NextRow()
	{
		if (currentRow > 0)
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