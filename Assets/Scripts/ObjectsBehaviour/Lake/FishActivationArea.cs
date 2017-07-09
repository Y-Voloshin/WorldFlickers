using UnityEngine;
using System.Collections;

public class FishActivationArea : MonoBehaviour {

	public GameObject InventoryObject;
	GameObject Hero;
	GameObject Fish;
	public Vector3 ObjectPosition;

	// Use this for initialization
	void Start () {
		Hero = GameObject.Find ("Hero");
		Fish = GameObject.Find ("TravelFish");
	}

	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(GameSettings.UseInventory))
		{
			if (GetComponent<Collider>().bounds.Intersects(Hero.GetComponent<Collider>().bounds))
			{
				if (InventoryObject.GetComponent<InventoryObject>().Active)
				{
					if (InventoryObject.GetComponent<InventoryObject>().Selected)
						Act();
				}
			}
		}
	}

	void Act()
	{
		Fish.GetComponent<TravelFish> ().Active = true;
		InventoryObject.GetComponent<InventoryObject> ().Deactivate ();
	}
}
