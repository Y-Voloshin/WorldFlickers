using UnityEngine;
using System.Collections;

public class Lamp : MonoBehaviour {

	public Material OnMaterial, OffMaterial;
	public bool SwitchedOn;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SwitchOn()
	{
		GetComponent<Renderer>().material = OnMaterial;
		SwitchedOn = true;
	}

	public void SwitchOff()
	{
		GetComponent<Renderer>().material = OffMaterial;
		SwitchedOn = false;
	}
}
