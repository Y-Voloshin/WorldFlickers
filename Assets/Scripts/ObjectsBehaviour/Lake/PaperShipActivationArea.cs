using UnityEngine;
using System.Collections;

public class PaperShipActivationArea : MonoBehaviour {

	public GameObject InventoryObject;
	GameObject Hero, PaperShip;
	public Vector3 ObjectPosition;

	// Use this for initialization
	void Start () {
		PaperShip = GameObject.Find("PaperShip");
		Hero = GameObject.Find("Hero");

		ObjectPosition = transform.position + new Vector3(1f, -0.75f, 0);
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
		PaperShip.transform.position = ObjectPosition;
	}
}
