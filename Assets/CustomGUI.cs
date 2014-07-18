using UnityEngine;
using System.Collections;

public class CustomGUI : GlobalVariables
{
	/*
	 * CustomGUI
	 * Inherit from this class for resizing options for applications that require
	 * a fixed XY scale but is used on multiple screen resolutions.
	 * Includes a fade in/fade out scaling method for interactive boxes.
	 * 
	 * Rescale sprite (for x):
	 * 1. (working height / sprite height / total rows * rows as width) to find the needed normal scaling ratio
	 * 		whether to use height or width depends on whether the screen is too wide or too tall
	 * 2. (1.2f - renderer.material.color.a * 0.2f) alpha scale to further multiply for new scaling
	 * 		this becomes 1.0f when alpha is 1, and 1.2f when alpha is 0
	 * 
	 * Reposition sprite (for x):
	 * 1. (+ 0) to put bottom left of sprite on center of screen
	 * 2. (- working width / 2) to hinge the sprite to the bottom left of screen with initial padding
	 * 3. (+ working width - full sprite width / 2) for the extra padding when screen is too wide or tall
	 * 4. (+ row# * ratio of working width to columns) to position the sprite correctly in its framework
	 * 5. (+ (1-alphaScale) * spriteWidth * scale.x / 2) to change position based on new alpha sizing
	 * 
	 * 
	 * 
	 * Author: Wesley Wu
	 */

	public int x;
	public int y;
	public int rX;
	public int rY;
	float reveal = 1; // 0:hide  1:show

	//Called from outside and takes in <bool toShow> parameter,  true:show  false:hide
	public void CustomLogicVisibility(bool toShow)
	{
		reveal = toShow?1:0;
	}
	
	//Manages the fading in and out for this object depending on the rate <float reveal>
	public void LogicFade()
	{
		renderer.material.color += new Color(0, 0, 0, (reveal - renderer.material.color.a) / 5);
		if (renderer.material.color.a > 0.99f)
		{
			renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, 1);
		}
		else if (renderer.material.color.a < 0.01f)
		{
			renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, 0);
		}
	}
	
	//Manages the rescaling based on different screen sizes
	public void Rescale()
	{
		//Gather resources
		SpriteRenderer sr = GetComponent<SpriteRenderer>();
		if (sr == null) return;
		transform.localScale = new Vector3(1,1,1);
		
		//Find dimensions of sprite resource
		float spriteWidth = sr.sprite.bounds.size.x;
		float spriteHeight = sr.sprite.bounds.size.y;
		
		//Find dimensions of working view (camera - padding) when rendered
		float workingHeight = Camera.main.orthographicSize * 2f - PAD_Y;
		float workingWidth = workingHeight / Screen.height * Screen.width - PAD_X;
		
		Vector2 scale = new Vector2(0,0); //scale is a ratio between camera and sprite size, to be multiplied back to sprite
		float alphaScale = 1.2f - renderer.material.color.a * 0.2f;
		
		if (workingWidth/workingHeight > (float)TOTAL_COLUMNS / TOTAL_ROWS) //Too wide, center by X
		{
			//Resize sprite
			scale.x = workingHeight / spriteHeight / TOTAL_ROWS * rX;
			scale.y = workingHeight / spriteHeight / TOTAL_ROWS * rY;
			transform.localScale = new Vector2(scale.x * alphaScale, scale.y * alphaScale);
			
			transform.position = new Vector3(x * workingHeight / TOTAL_ROWS + ((1-alphaScale) * scale.x - TOTAL_COLUMNS * scale.x / rX) * spriteWidth * 0.5f,
			                                 workingHeight * ((float)y / TOTAL_ROWS - 0.5f) + (1-alphaScale) * spriteHeight * scale.y * 0.5f,
			                                 -1);
		}
		else //Too tall, center by Y
		{
			scale.x = workingWidth / spriteWidth / TOTAL_COLUMNS * rX;
			scale.y = workingWidth / spriteWidth / TOTAL_COLUMNS * rY;
			transform.localScale = new Vector2(scale.x * alphaScale, scale.y * alphaScale);

			transform.position = new Vector3(-workingWidth/2 - x*workingWidth/TOTAL_COLUMNS + (1-alphaScale) * spriteWidth * scale.x / 2, -workingHeight/2 + y*workingWidth/TOTAL_COLUMNS + (workingHeight - TOTAL_ROWS * scale.y / rY * spriteHeight)/2 + (1-alphaScale) * spriteHeight * scale.y / 2, -1);
		}
	}
}
