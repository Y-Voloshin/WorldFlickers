using UnityEngine;
using System.Collections;

public class HeroSpeedChanger : MonoBehaviour {


	public bool ChangeSpeed = false, ChangeJumpForce = false, ChangeGravity = false;
	public float Speed, JumpForce, Gravity;

	GameObject Hero;
	// Use this for initialization
	void Start () {
		Hero = GameObject.Find("Hero");
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<Collider>().bounds.Intersects(Hero.GetComponent<Collider>().bounds))
		{
			if (ChangeSpeed)
				Hero.GetComponent<PlayerController>().speed = Speed;
			if (ChangeJumpForce)
				Hero.GetComponent<PlayerController>().jumpSpeed = JumpForce;
			if (ChangeGravity)
				Hero.GetComponent<PlayerController>().gravity = Gravity;

		}
	}
}
