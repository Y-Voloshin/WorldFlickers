using UnityEngine;
using System.Collections;

public class AlwaysRunTrigger : MonoBehaviour {

	public bool AlwaysRunState;
	bool active = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (active)
		{
			if (GetComponent<Collider>().bounds.Intersects(GameSettings.Hero.GetComponent<Collider>().bounds))
			{
				GameSettings.Hero.GetComponent<PlayerController>().SetAlwaysRun(AlwaysRunState);
				active = false;
			}
		}
	}
}
