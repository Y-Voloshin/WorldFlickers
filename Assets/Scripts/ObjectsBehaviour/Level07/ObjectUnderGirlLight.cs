using UnityEngine;
using System.Collections;

public class ObjectUnderGirlLight : MonoBehaviour {

	GameObject GirlLight;
	public Material LightMaterial, DarkMaterial;
	// Use this for initialization
	void Start () {
		GirlLight = GameObject.Find ("GirlLight");
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<Collider>().isTrigger == GetComponent<Collider>().bounds.Intersects (GirlLight.GetComponent<Collider>().bounds))
			Switch();
	}

	void Switch()
	{
		GetComponent<Collider>().isTrigger = !GetComponent<Collider>().bounds.Intersects (GirlLight.GetComponent<Collider>().bounds);
		if (GetComponent<Collider>().isTrigger)
						GetComponent<Renderer>().material = DarkMaterial;
				else
						GetComponent<Renderer>().material = LightMaterial;
	}
}
