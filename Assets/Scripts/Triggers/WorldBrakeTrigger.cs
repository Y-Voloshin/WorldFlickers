using UnityEngine;
using System.Collections;

public class WorldBrakeTrigger : MonoBehaviour {

    public delegate void EventContainer();

    public EventContainer OnHeroCome;
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("blabla");
    }
}
