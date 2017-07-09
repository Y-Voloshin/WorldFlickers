using UnityEngine;
using System.Collections;

public class LightSwitcher : MonoBehaviour {

	public GameObject[] Floors;
	GameObject Hero, SceneController;
	public GameObject Lamp, LightObject;
	public bool On = false;

	// Use this for initialization
	void Start () {
		Hero = GameObject.Find ("Hero");
		SceneController = GameObject.Find ("SceneController");

		if (On)
						SwitchOn ();
				else
						SwitchOff ();
	}
	
	// Update is called once per frame
	void Update () {

	if (GetComponent<Collider>().bounds.Intersects (Hero.GetComponent<Collider>().bounds))
		{

			if (Input.GetKeyDown(GameSettings.Use))
			{
				if (On)
					SwitchOff();
				else SwitchOn();
			}
		}
	}

	void SwitchOn()
	{
		On = true;
		Lamp.GetComponent<Lamp> ().SwitchOn ();
		LightObject.GetComponent<Light>().enabled = true;

		foreach (GameObject floor in Floors)
			floor.GetComponent<FloorUnderLight> ().Illuminate ();
	}

	void SwitchOff()
	{
		On = false;
		Lamp.GetComponent<Lamp> ().SwitchOff ();
		LightObject.GetComponent<Light>().enabled = false;
		//LightObject.
		foreach (GameObject floor in Floors)
			floor.GetComponent<FloorUnderLight> ().IlluminateOff ();
	}
}
