using UnityEngine;
using System.Collections;

public class FloorUnderLight : MonoBehaviour {

	public Material DarkMaterial, LightMaterial;
	public bool Illuminated;
	//GameObject Hero, HeroBottom;
	//CharacterController HeroController;
	// Use this for initialization
	void Start () {
		//Hero = GameObject.Find("Hero");
		//HeroBottom = GameObject.Find("HeroBottom");
		//HeroController = Hero.GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void Illuminate()
	{
		Illuminated = true;
		GetComponent<Renderer>().material = LightMaterial;
		GetComponent<Collider>().isTrigger = false;
	}

	public void IlluminateOff()
	{
		Illuminated = false;
		GetComponent<Renderer>().material = DarkMaterial;
	}
}
