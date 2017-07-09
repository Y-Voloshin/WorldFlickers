using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {

	GameObject Hero;
	// Use this for initialization
	void Start () {
		Hero = GameObject.Find ("Hero");
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<Collider>().bounds.Intersects (Hero.GetComponent<Collider>().bounds))
			Hero.GetComponent<PlayerController> ().CheckPoint = transform.position;
	}
}
