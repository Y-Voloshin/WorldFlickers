using UnityEngine;
using System.Collections;

public class Curtains : MonoBehaviour {

	bool closed = true;
	GameObject Hero, SceneController, LightMark;
	public Material OpenWindowMaterial;

	// Use this for initialization
	void Start () {
		Hero = GameObject.Find ("Hero");
		SceneController = GameObject.Find ("SceneController");
		LightMark = GameObject.Find ("LightMark1");
	}
	
	// Update is called once per frame
	void Update () {
		if (closed)
			if (GetComponent<Collider>().bounds.Intersects (Hero.GetComponent<Collider>().bounds))
				if (Input.GetKeyDown (GameSettings.Use)) {
					GetComponent<Renderer>().material = OpenWindowMaterial;
					closed = false;
					//LightMark.transform.localScale = new Vector3(3.5f, 1f);
				LightMark.GetComponent<Collider>().transform.localScale = new Vector3 (3.5f, 1, 1);
				LightMark.GetComponent<Collider>().transform.position -= new Vector3 (0.4f, 0, 0);
				}
	
	}
}
