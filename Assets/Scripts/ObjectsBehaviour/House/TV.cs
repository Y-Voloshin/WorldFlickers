using UnityEngine;
using System.Collections;

public class TV : MonoBehaviour {
	public Material TVOnMaterial;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SwitchOn()
	{
		GetComponent<Renderer>().material = TVOnMaterial;
		GetComponent<Collider>().isTrigger = false;
	}
}
