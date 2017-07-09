using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LampActivationArea : MonoBehaviour {

	public GameObject InventoryObject;
	GameObject Hero;
	GameObject Lamp;
	public Vector3 ObjectPosition;



	List<FloorUnderLight> IlluminatedObjects = new List<FloorUnderLight>();

	// Use this for initialization
	void Start () {
		Hero = GameObject.Find ("Hero");
		Lamp = GameObject.Find ("LampConnected");
		Lamp.SetActive (false);

		IlluminatedObjects.Add (GameObject.Find("WashingMachine").GetComponent<FloorUnderLight>());
		IlluminatedObjects.Add (GameObject.Find("Shelf").GetComponent<FloorUnderLight>());
		IlluminatedObjects.Add (GameObject.Find("BathFloor").GetComponent<FloorUnderLight>());

	}
	
	// Update is called once per frame
	void Update () {

		//Debug.Log(GameSettings.UseInventory);
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
		Lamp.SetActive (true);
		InventoryObject.GetComponent<InventoryObject> ().Deactivate ();
		foreach(FloorUnderLight item in IlluminatedObjects)
		{
			item.Illuminate();
		}
	}
}
