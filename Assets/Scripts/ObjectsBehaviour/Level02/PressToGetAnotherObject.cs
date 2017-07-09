using UnityEngine;
using System.Collections;

public class PressToGetAnotherObject : MonoBehaviour {

	public GameObject AppearingObject;
	bool active = true;
	//GameObject Hero;
	// Use this for initialization
	void Start () {
		AppearingObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (active)
				if (Input.GetKeyDown (GameSettings.Use))
				if (GetComponent<Collider>().bounds.Intersects (GlobalVariables.Hero.GetComponent<Collider>().bounds)) {
						Activate ();
				}
	}

	void Activate()
	{
		active = false;
		AppearingObject.SetActive (true);
	}
}
