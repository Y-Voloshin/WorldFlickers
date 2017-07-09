using UnityEngine;
using System.Collections;

public class FireObject : MonoBehaviour {

	public bool On = false;
	public bool SolidOn = false;
	public bool SolidOff = false;
	public bool IsGround = false;
	public GameObject[] Fires;
	GameObject Hero;
	// Use this for initialization
	void Start () {
		Hero = GameObject.Find ("Hero");
		FireSwitch ();

	}
	
	// Update is called once per frame
	void Update () {
		//FireSwitch ();

		bool use = Input.GetKeyDown (GameSettings.Use);

		if (use && Hero.GetComponent<Collider>().bounds.Intersects(GetComponent<Collider>().bounds))
		{
			StartFire();
		}
	}

	void FireSwitch()
	{
		//On = !On;
		foreach (GameObject Fire in Fires)
		{
			Fire.transform.GetChild (0).GetComponent<Renderer>().enabled = On;
			Fire.transform.GetChild (1).GetComponent<Renderer>().enabled = On;
			Fire.transform.GetChild (2).GetComponent<Renderer>().enabled = On;
		}


	}

	public void StartFire()
	{
		if (!On)//On = true;
		Invoke ("LightFire", 1);
	}

	void LightFire()
	{
		On = true;
		FireSwitch ();
	}

	//IEnumerator Fi
}
