using UnityEngine;
using System.Collections;

public class SpyGlass : MonoBehaviour {

	public GameObject InventoryObject;
	GameObject Hero;
	bool Active = true;
	
	// Use this for initialization
	void Start () {
		Hero = GameObject.Find ("Hero");
	}
	
	// Update is called once per frame
	void Update () {
		if (Active)
		{
				if (GetComponent<Collider>().bounds.Intersects(Hero.GetComponent<Collider>().bounds))
				{
					Act();					
				}

			if (Hero.transform.position.x > transform.position.x)
			{
				Active = false;
			}
		}
	}
	
	void Act()
	{

		InventoryObject.GetComponent<InventoryObject> ().Activate ();
		transform.position += new Vector3 (0, 0, -30);
		Active = false;
	}
}
