using UnityEngine;
using System.Collections;
using System;

public class GirlAnimationalwaysWalk1 : MonoBehaviour {

	bool up, down, right, left;
	public int framesPerSecond = 5;
	public bool LookLeft;
	GameObject Hero;

	Vector3 LeftLocalScale, RightLocalScale;

	float FrameOffsetX = 0.1111f;

	float[] FrameOffsetsY = new float[13];
	// Use this for initialization
	void Start () {
		FrameOffsetsY[0] = 0.515f;
		FrameOffsetsY[1] = 0.515f;
		FrameOffsetsY[2] = 0.515f;
		FrameOffsetsY[3] = 0.515f;
		FrameOffsetsY[4] = 0.515f;
		FrameOffsetsY[5] = 0.515f;
		FrameOffsetsY[6] = 0.515f;
		FrameOffsetsY[7] = 0.515f;
		FrameOffsetsY[8] = 0.515f;
		FrameOffsetsY[9] = 0.08f;
		FrameOffsetsY[10] = 0.011f;
		FrameOffsetsY[11] = 0.22f;
		FrameOffsetsY[12] = 0.015f;

		Hero = GameObject.Find("Hero2");

		framesPerSecond = 10;

		LeftLocalScale = transform.localScale;
		RightLocalScale = transform.localScale;

		LeftLocalScale = new Vector3(-LeftLocalScale.x, LeftLocalScale.y, LeftLocalScale.z);
	}
	
	// Update is called once per frame
	void Update () {
		if (!Hero.GetComponent<GirlController>().Locked)
		{
			//up = Input.GetKeyDown(KeyCode.UpArrow);
			//down = Input.GetKeyDown(KeyCode.DownArrow);
			//right = Input.GetKey(KeyCode.RightArrow);
			//left = Input.GetKey(KeyCode.LeftArrow);

			/*
			if (Girl.GetComponent<GirlBehaviour>().Hidden)
				renderer.material.mainTextureOffset = new Vector2(6 * FrameOffsetX, FrameOffsetsY[6]);
			*/


			//if (right)
			//{
				LookLeft = false;
				aniRun();
			//}
			//if (left)
			//{
				LookLeft = true;
				aniRun();
			//}
			if (Hero.GetComponent<GirlController>().jump)
				GetComponent<Renderer>().material.mainTextureOffset = new Vector2(1 * FrameOffsetX, FrameOffsetsY[10]);

			//if (! (right || left || Hero.GetComponent<GirlController>().jump))
			//	renderer.material.mainTextureOffset = new Vector2(1 * FrameOffsetX, FrameOffsetsY[1]);
		}
		else
		{
			GetComponent<Renderer>().material.mainTextureOffset = new Vector2(4 * FrameOffsetX, FrameOffsetsY[12]);
		}

	}

	void aniRun ()// function for animating sprites
	{
		Vector2 offset;
		int index = Convert.ToInt32(Time.time * framesPerSecond);// time control fps
		index = index % 5 + 3;// modulate to total number of frames


		// scale for column and row size
		//size.y = renderer.material.mainTextureScale.y;


		offset = new Vector2(Convert.ToSingle(index * FrameOffsetX), FrameOffsetsY[index]);
			
		GetComponent<Renderer>().material.mainTextureOffset = offset;// texture offset for diffuse map

		//float a = 
		if (LookLeft)
			transform.localScale = LeftLocalScale; // offset equals column and row
		else
			transform.localScale = RightLocalScale;

		GetComponent<Renderer>().material.mainTextureOffset = offset;// texture offset for diffuse map

		//renderer.material.mainTextureOffset = offset;// texture offset for diffuse map

		//renderer.material.SetTextureOffset ("_BumpMap", offset);// texture offset for bump (normal map)
		
		
	}
}
