using UnityEngine;
using System.Collections;

public class Apple : MonoBehaviour {

	GameObject Hero, Target, Dog;
	Vector3 Speed, StartPos;
	bool Moving = false;
	public float SpeedF = 2;
	// Use this for initialization
	void Start () {
		StartPos = transform.position;
		Target = GameObject.Find("AppleTarget");
		Hero = GameObject.Find("Hero");
		Dog = GameObject.Find("NeighbourDog");

		float xdist = Target.transform.position.x - transform.position.x;
		float ydist = Target.transform.position.y - transform.position.y;

		float div = Mathf.Max(Mathf.Abs(xdist), Mathf.Abs(ydist));

		xdist = xdist / div;
		ydist = ydist / div;

		Speed = new Vector3(xdist * Time.deltaTime * SpeedF, ydist * Time.deltaTime * SpeedF, 0);
	}
	
	// Update is called once per frame
	void Update () {

		if (Moving)
		{
			ExecuteMove();
		}
		else
		{
			if (Input.GetKeyDown(GameSettings.Use))
				if (Hero.GetComponent<Collider>().bounds.Intersects(GetComponent<Collider>().bounds))
					Activate();
		}
	}

	void ExecuteMove()
	{
		transform.position += Speed;
		if (GetComponent<Collider>().bounds.Intersects(Target.GetComponent<Collider>().bounds))
		{
			Moving = false;
			transform.position = StartPos;
			Dog.GetComponent<NeighbourDog>().Activate();
		}
	}

	void Activate()
	{
		Moving = true;
	}
}
