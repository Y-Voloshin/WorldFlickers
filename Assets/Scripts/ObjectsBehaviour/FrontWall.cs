using UnityEngine;
using System.Collections;

public class FrontWall : MonoBehaviour {

	GameObject Hero;
	// Use this for initialization
	void Start () {
		Hero = GameObject.Find("Hero");
	}
	
	// Update is called once per frame
	void Update () {
			GetComponent<Renderer>().enabled = !Hero.GetComponent<Collider>().bounds.Intersects(GetComponent<Collider>().bounds);
	}
}
