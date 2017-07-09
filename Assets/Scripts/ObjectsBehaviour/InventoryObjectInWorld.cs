using UnityEngine;
using System.Collections;

public class InventoryObjectInWorld : MonoBehaviour {

	public GameObject InventoryObject;
	GameObject Hero;


	bool taken = false;
	// Use this for initialization
	void Start () {
		Hero = GameObject.Find ("Hero");
	}
	
	// Update is called once per frame
	void Update () {
		if (!taken)
		{
			if (Input.GetKeyDown(GameSettings.Use))
			if (GetComponent<Collider>().bounds.Intersects(Hero.GetComponent<Collider>().bounds))
			{
				InventoryObject.GetComponent<InventoryObject>().Activate();
				transform.position += new Vector3(0, 0, -100);
				//renderer.enabled = false;
			}
		}
	}
}
