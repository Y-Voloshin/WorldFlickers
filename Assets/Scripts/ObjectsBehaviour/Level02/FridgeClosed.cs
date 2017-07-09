using UnityEngine;
using System.Collections;

public class FridgeClosed : MonoBehaviour {

	public GameObject FridgeOpen;

	// Use this for initialization
	void Start () {
		FridgeOpen.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
		if (GameSettings.Hero.GetComponent<Collider>().bounds.Intersects(GetComponent<Collider>().bounds))
		{
			if (Input.GetKey(GameSettings.Use))
			{
				Open();
			}
		}
	}

	void Open()
	{
		FridgeOpen.SetActive (true);
		gameObject.SetActive (false);
	}
}
