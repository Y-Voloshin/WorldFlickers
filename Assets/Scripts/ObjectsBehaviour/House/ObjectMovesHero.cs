using UnityEngine;
using System.Collections;

public class ObjectMovesHero : MonoBehaviour {

	GameObject Hero, HeroBottom;

	public Vector3 StartPos, EndPos;
	public Vector3 Speed = new Vector3 (1, 0, 0);
	public float SpeedX = 1, SpeedY = 1;
	public bool Finished = false;

	public bool HeroOnShip, HeroGrounded;

	// Use this for initialization
	void Start () {
		Hero = GameObject.Find ("Hero");
		HeroBottom = GameObject.Find ("HeroBottom");

		Speed = new Vector3 (SpeedX * Time.deltaTime, SpeedY * Time.deltaTime, 0);

	}
	
	// Update is called once per frame
	void Update () {

		if (!Finished)
		{
			HeroOnShip = GetComponent<Collider>().bounds.Intersects(HeroBottom.GetComponent<Collider>().bounds);
			HeroGrounded = Hero.GetComponent<CharacterController>().isGrounded;

			if (HeroOnShip && HeroGrounded)
			{
				//Баг - работает только при движении слева направо
				if (transform.position.x < EndPos.x)
				{
					transform.position += Speed;
					Hero.transform.position +=Speed;
				}

			}
			else
			{
				if ((transform.position.x - transform.lossyScale.x / 2) > Hero.transform.position.x)
				{
					if (transform.position.x > StartPos.x)
						transform.position -= Speed;
				}
				else
				{
					if (Hero.transform.position.x - transform.position.x > 30)
						Finished = true;
				}
			}
		}
	}
}
