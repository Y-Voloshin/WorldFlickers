using UnityEngine;
using System.Collections;

public class Bath : MonoBehaviour {

	bool WaterActive = false;
	bool SourActive = false;

	public GameObject Sour;
	// Use this for initialization
	void Start () {
		Sour.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ActivateWater()
	{
		WaterActive = true;
		if (SourActive)
			Activate();
	}

	public void ActivateSour()
	{
		SourActive = true;
		if (WaterActive)
			Activate();
	}

	void Activate()
	{
		Sour.SetActive(true);
	}
}
