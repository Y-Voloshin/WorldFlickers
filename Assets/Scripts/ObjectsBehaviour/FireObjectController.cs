using UnityEngine;
using System.Collections;

public class FireObjectController : MonoBehaviour {

	GameObject[] FireObjects;
	// Use this for initialization
	void Start () {
		FireObjects = GameObject.FindGameObjectsWithTag ("FireObject");
		//foreach (GameObject ff in FireObjects)
			//ff.GetComponent<FireObject>().On = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (FireObjects.Length > 1)

			for (int i = 0; i < (FireObjects.Length - 1); i++)
				for (int j = 1; j < FireObjects.Length; j++)
					if (FireObjects[i].GetComponent<Collider>().bounds.Intersects(FireObjects[j].GetComponent<Collider>().bounds))
					    if (FireObjects[i].GetComponent<FireObject>().On || FireObjects[j].GetComponent<FireObject>().On)
					    {
							//FireObjects[i].GetComponent<FireObject>().On = true;
							//FireObjects[j].GetComponent<FireObject>().On = true;
							FireObjects[i].GetComponent<FireObject>().StartFire();
							FireObjects[j].GetComponent<FireObject>().StartFire ();
						}

	}
}
