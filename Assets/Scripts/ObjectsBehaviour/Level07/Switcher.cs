using UnityEngine;
using System.Collections;

public class Switcher : MonoBehaviour {

	public GameObject[] Movers;
	GameObject Hero;
	// Use this for initialization
	void Start () {
		Hero = GameObject.Find ("Hero");
	}
	
	// Update is called once per frame
	void Update () {
		bool use = Input.GetKeyDown (GameSettings.Use);
		
		if (use && Hero.GetComponent<Collider>().bounds.Intersects (GetComponent<Collider>().bounds))
			foreach (GameObject Mover in Movers)
				Mover.GetComponent<Mover> ().Activate ();
	}
}
