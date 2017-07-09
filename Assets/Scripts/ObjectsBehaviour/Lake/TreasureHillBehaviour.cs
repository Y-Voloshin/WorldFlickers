using UnityEngine;
using System.Collections;

public class TreasureHillBehaviour : MonoBehaviour {

	public GameObject RequiredGameObject, ResultGameObject;
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
			if (Input.GetKeyDown(GameSettings.UseInventory))
			{
				if (GetComponent<Collider>().bounds.Intersects(Hero.GetComponent<Collider>().bounds))
				{
					if (RequiredGameObject.GetComponent<InventoryObject>().Active)
						Act();

				}
			}
		}
	}

	void Act()
	{
		RequiredGameObject.GetComponent<InventoryObject> ().Deactivate ();
		ResultGameObject.GetComponent<InventoryObject> ().Activate ();
		transform.position += new Vector3 (0, 0, -30);
		Active = false;
	}
}
