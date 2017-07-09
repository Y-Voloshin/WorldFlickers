using UnityEngine;
using System.Collections;

public class FallOnTouchObject : MonoBehaviour {

	bool active = true;
	public float yDist, rotAngle = 270f;
	GameObject Hero;

	// Use this for initialization
	void Start () {
		yDist = -(transform.localScale.y - transform.localScale.x) / 2;
		Hero = GameObject.Find ("Hero");
	}
	
	// Update is called once per frame
	void Update () {
		if (active)
		if (Input.GetKeyDown(GameSettings.Use))
				if (GetComponent<Collider>().bounds.Intersects(Hero.GetComponent<Collider>().bounds))
					Fall();
	}

	void Fall()
	{
		active = false;
		transform.Rotate(new Vector3(0, 0, rotAngle));
		transform.Translate(yDist, 0, 0);
		//transform.Translate(new Vector3(0, -yDist, 0));
	}
}
