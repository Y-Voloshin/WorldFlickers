using UnityEngine;
using System.Collections;

public class CloudCollisionArea : MonoBehaviour {

	public bool Solid = false;
	GameObject Hero, HeroBottom;
	// Use this for initialization
	void Start () {
		Hero = GameObject.Find("Hero");
		HeroBottom = GameObject.Find("HeroBottom");
	}
	
	// Update is called once per frame
	void Update () {
		if (Solid)
		{
			if (GetComponent<Collider>().bounds.Intersects(HeroBottom.GetComponent<Collider>().bounds))
			{
				GetComponent<Collider>().isTrigger = false;
				if (Hero.GetComponent<CharacterController>().isGrounded || (Hero.GetComponent<CharacterController> ().velocity.y <=0))
					GetComponent<Collider>().isTrigger = false;
				else
				{
					if (!GetComponent<Collider>().bounds.Intersects(Hero.GetComponent<Collider>().bounds))
						GetComponent<Collider>().isTrigger = false;
					//else { collider.isTrigger = true; }
				}
			}
			else { GetComponent<Collider>().isTrigger = true; }
		}
		else GetComponent<Collider>().isTrigger = true;
	
	}
}
