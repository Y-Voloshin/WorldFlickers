using UnityEngine;
using System.Collections;
using System;

public class HeroWalkAnimation : MonoBehaviour {

	Vector3 RightScale, LeftScale;

	// Use this for initialization
	void Start () {
		RightScale = transform.localScale;
		LeftScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
	}
	
	// Update is called once per frame
	void Update () {
		bool right = Input.GetKey(GameSettings.MoveRight) || GameSettings.Hero.GetComponent<PlayerController>().AlwaysRun;
		bool left = Input.GetKey(GameSettings.MoveLeft);
		
		bool up = Input.GetKeyDown(GameSettings.Jump);
		//bool down = Input.GetKeyDown(GameSettings);


		if (right)
			transform.localScale = RightScale;
		if (left)
			transform.localScale = LeftScale;

		if (right || left)
		
			aniSprite(8, 1, 1, 0, 6, 6);

		if (!(right||left||up))
			GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0,0);



	}

	void aniSprite (int columnSize, int rowSize, int colFrameStart, int rowFrameStart, int totalFrames, int framesPerSecond)// function for animating sprites
	{
		
		int index = Convert.ToInt32(Time.time * framesPerSecond);// time control fps
		index = index % totalFrames;// modulate to total number of frames
		
		Vector2 size = new Vector2 ( Convert.ToSingle(1.0 / columnSize), Convert.ToSingle(1.0 / rowSize));// scale for column and row size
		size.y = GetComponent<Renderer>().material.mainTextureScale.y;
		
		
		int u = index % columnSize;// u gets current x coordinate from column size
		int v = index / columnSize;// v gets current y coordinate by dividing by column size
		
		
		//float a = 
		
		Vector2 offset = new Vector2(Convert.ToSingle((u + colFrameStart) * size.x), Convert.ToSingle((1.0 - size.y) - (v + rowFrameStart) * size.y)); // offset equals column and row
		
		GetComponent<Renderer>().material.mainTextureOffset = offset;// texture offset for diffuse map
		//renderer.material.mainTextureScale  = size;	// texture scale  for diffuse map
		
		GetComponent<Renderer>().material.SetTextureOffset ("_BumpMap", offset);// texture offset for bump (normal map)
		GetComponent<Renderer>().material.SetTextureScale  ("_BumpMap", size);// texture scale  for bump (normal map) 
		
		
	}
}
