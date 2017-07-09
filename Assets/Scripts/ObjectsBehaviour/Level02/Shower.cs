using UnityEngine;
using System.Collections;

public class Shower : MonoBehaviour {

	bool active = true;
	public GameObject particles, bath;
	GameObject Hero;


	// Use this for initialization
	void Start () {
		Hero = GameObject.Find ("Hero");
		particles.GetComponent<ParticleSystem>().Stop();
	}
	
	// Update is called once per frame
	void Update () {
		if (active)
			if (Input.GetKeyDown(GameSettings.Use))
				if (GetComponent<Collider>().bounds.Intersects(Hero.GetComponent<Collider>().bounds))
					Activate();
	}

	void Activate()
	{
		particles.GetComponent<ParticleSystem>().Play();
		bath.GetComponent<Bath>().ActivateWater();
	}
}
