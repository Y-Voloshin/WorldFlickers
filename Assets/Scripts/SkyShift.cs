using UnityEngine;
using System.Collections;

public class SkyShift : MonoBehaviour {

	public Material NewSkyMaterial;
	GameObject Hero;
	// Use this for initialization
	void Start () {
		Hero = GameObject.Find("Hero");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
