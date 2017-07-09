using UnityEngine;
using System.Collections;

public class PaperShip : MonoBehaviour {

	GameObject Hero, HeroBottom, Ship;
	public Vector3 HeroPosDelta, ShipPosDelta;
	// Use this for initialization
	void Start () {
		Hero = GameObject.Find("Hero");
		HeroBottom = GameObject.Find("HeroBottom");
		Ship = GameObject.Find("Ship");

		Ship.transform.position = new Vector3(500, 0, - 30);
		Ship.GetComponent<ObjectMovesHero>().StartPos = Ship.transform.position;
		Ship.GetComponent<ObjectMovesHero>().EndPos = Ship.transform.position;
		Ship.GetComponent<ObjectMovesHero> ().Finished = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<Collider>().bounds.Intersects(HeroBottom.GetComponent<Collider>().bounds))
		{
			Hero.transform.position = transform.position + HeroPosDelta;
			Ship.transform.position = transform.position + ShipPosDelta;
			Ship.GetComponent<ObjectMovesHero>().StartPos = Ship.transform.position;
			Ship.GetComponent<ObjectMovesHero>().EndPos = Ship.transform.position + new Vector3 (17, 0, 0);
			//Ship.GetComponent<ObjectMovesHero>().SpeedX = 1;
			//Ship.GetComponent<ObjectMovesHero>().SpeedY = 0;
			Ship.GetComponent<ObjectMovesHero>().Finished = false;

			transform.position += new Vector3(0, 0, - 30f);
		}
	}
}
