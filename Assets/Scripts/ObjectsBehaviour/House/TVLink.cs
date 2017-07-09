using UnityEngine;
using System.Collections;

public class TVLink : MonoBehaviour {

	GameObject Hero, SceneController, TV;

	bool off = true;

	// Use this for initialization

	void Start () {
		Hero = GameObject.Find ("Hero");
		TV = GameObject.Find ("TV");

	}
	
	// Update is called once per frame
	void Update () {
		if (off)
				if (GetComponent<Collider>().bounds.Intersects (Hero.GetComponent<Collider>().bounds))
				if (Input.GetKeyDown (GameSettings.Use))
						TV.GetComponent<TV> ().SwitchOn ();
	}
}
