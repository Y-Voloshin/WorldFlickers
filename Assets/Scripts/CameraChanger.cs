using UnityEngine;
using System.Collections;

public class CameraChanger : MonoBehaviour {

	public float TargetZ;
	GameObject Hero, MainCamera;
	// Use this for initialization
	void Start () {
		Hero = GameObject.Find("Hero");
		MainCamera = GameObject.Find("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<Collider>().bounds.Intersects(Hero.GetComponent<Collider>().bounds))
			MainCamera.GetComponent<CameraController>().StartChange(TargetZ);
	}
}
