using UnityEngine;
using System.Collections;

public class SwitchableHouse : MonoBehaviour {
	public GameObject OnHouse;
	Vector3 ActivePos, InactivePos;
	public bool Active = false;
	public float ActiveTime = 8;
	float CurrentTime = 0;
	// Use this for initialization
	void Start () {
		ActivePos = transform.position;
		InactivePos = ActivePos + new Vector3(0, 0, -30);
		OnHouse = GameObject.Find("HouseLight");

		OnHouse.transform.position = InactivePos;
	}
	
	// Update is called once per frame
	void Update () {
		if (Active)
		{
			CurrentTime += Time.deltaTime;
			if (CurrentTime > ActiveTime)
				Deactivate();
		}
	}

	public void Activate()
	{
		Active = true;
		transform.position = InactivePos;
		OnHouse.transform.position = ActivePos;
	}

	public void Deactivate()
	{
		Active = false;
		CurrentTime = 0;
		transform.position = ActivePos;
		OnHouse.transform.position = InactivePos;
	}
}
