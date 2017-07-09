using UnityEngine;
using System.Collections;

public class SolidTopObject : MonoBehaviour {

	GameObject Hero, HeroBottom;
	// Use this for initialization
	void Start () {
		Hero = GameObject.Find("Hero");
		HeroBottom = GameObject.Find("HeroBottom");
	}
	
	// Update is called once per frame
	void Update () {
		
		if (GetComponent<Collider>().bounds.Intersects(HeroBottom.GetComponent<Collider>().bounds))
		{
			if ((Hero.GetComponent<CharacterController>().isGrounded || (Hero.GetComponent<CharacterController> ().velocity.y <=0))&& HeroIsAbove())
				GetComponent<Collider>().isTrigger = false;
			else
			{
				if (!GetComponent<Collider>().bounds.Intersects(Hero.GetComponent<Collider>().bounds))
					GetComponent<Collider>().isTrigger = false;
				else { GetComponent<Collider>().isTrigger = true; }
			}
		}
		else { GetComponent<Collider>().isTrigger = true; }
	}

	bool HeroIsAbove()
	{
		return Hero.GetComponent<Collider>().bounds.min.y > GetComponent<Collider>().bounds.max.y;
	}
}
