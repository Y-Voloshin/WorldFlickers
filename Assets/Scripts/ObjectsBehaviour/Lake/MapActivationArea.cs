using UnityEngine;
using System.Collections;

public class MapActivationArea : MonoBehaviour {

	public GameObject InventoryObject;
	GameObject Hero;
	public Vector3 ObjectPosition;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(GameSettings.Use))
		{
			if (GetComponent<Collider>().bounds.Intersects(Hero.GetComponent<Collider>().bounds))
			{
				if (InventoryObject.GetComponent<InventoryObject>().Active)
				{
					Act();
				}
			}
		}
	}

	void Act()
	{

	}
}
