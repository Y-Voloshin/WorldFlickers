using UnityEngine;
using System.Collections;

public class Owen : MonoBehaviour {

	public GameObject Fire, Sour, Matches;

	bool active = true;
	// Use this for initialization
	void Start () {
		Sour.SetActive (false);
		Fire.GetComponent<ParticleSystem>().Stop ();
	}
	
	// Update is called once per frame
	void Update () {
		if (active)
		{
			if (Input.GetKey(GameSettings.UseInventory))
			{
				if (GameSettings.Hero.GetComponent<Collider>().bounds.Intersects(GetComponent<Collider>().bounds))
				{
					InventoryObject matches = Matches.GetComponent<InventoryObject>();

					if (matches.Active && matches.Selected)
					{
						LightFire();
					}
				}
			}
		}
	}

	void LightFire()
	{
		active = false;
		Sour.SetActive (true);
		Fire.GetComponent<ParticleSystem>().Play ();
	}
}
