using UnityEngine;
using System.Collections;

public class GlobalVariables: MonoBehaviour
{
	public readonly int TOTAL_ROWS = 24;
	public readonly int TOTAL_COLUMNS = 14;
	public readonly int PAD_X = 1;
	public readonly int PAD_Y = 1;
	public readonly int EASY_PRIZE_ROW = 6;
	public readonly int BEST_PRIZE_ROW = 11;

	public bool INPUT_NORMAL_CLICK;

	void Update()
	{
		INPUT_NORMAL_CLICK = Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0); //new Touch().tapCount > 0;
	}
}
