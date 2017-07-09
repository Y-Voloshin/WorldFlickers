using UnityEngine;
using System.Collections;

public class NeighbourDog : MonoBehaviour {

	public float ActiveTime = 4;
	float CurrentTime = 0;
	public bool Active = false;
	GameObject House;
	Vector2 DefaultTextureOffset = new Vector2(-0.125f, 0), ActiveTextureOffset = new Vector2(0, 0);
	// Use this for initialization
	void Start () {
		House = GameObject.Find("HouseDark");
		Deactivate();
	}
	
	// Update is called once per frame
	void Update () {
		if (Active)
		{
			Action();
			if (CurrentTime >= ActiveTime)
			{
				Deactivate();
			}
		}
	}

	public void Activate()
	{
		Active = true;
		GetComponent<Renderer>().material.mainTextureOffset = ActiveTextureOffset;
		House.GetComponent<SwitchableHouse>().Activate();
	}

	void Deactivate()
	{
		CurrentTime = 0;
		Active = false;
		GetComponent<Renderer>().material.mainTextureOffset = DefaultTextureOffset;
	}

	void Action()
	{
		CurrentTime += Time.deltaTime;

	}
}
