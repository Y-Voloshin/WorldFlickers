using UnityEngine;
using System.Collections;

public class SandHill : MonoBehaviour {

	public GameObject ObjectAfterUse;
	GameObject Hero;
	bool active = true;

	// Use this for initialization
	void Start () {
		Hero = GameObject.Find("Hero");
	}
	
	// Update is called once per frame
	void Update () {
		if (active)
		{
			if (GetComponent<Collider>().bounds.Intersects(Hero.GetComponent<Collider>().bounds))
			{
				if (Input.GetKeyDown(GameSettings.Use))
				{
					Change();
				}
			}
		}
	}

	void Change()
	{
		Vector3 temp = transform.position;
		transform.position = ObjectAfterUse.transform.position;
		ObjectAfterUse.transform.position = temp;
		active = false;
	}
}
