using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	Vector3 Speed;
	float TargetZ;
	bool Changing = false;
	GameObject Hero, PauseMenu;
	// Use this for initialization
	void Start () {
		Hero = GameObject.Find ("Hero");
		PauseMenu = GameObject.Find ("PauseMenu");
		if (Hero.GetComponent<PlayerController>().Paused)
			PauseMenu.transform.position = transform.position + new Vector3(0, 0, 1.3f);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(GameSettings.Pause)) 
		{
			if (Hero.GetComponent<PlayerController>().Paused)
			{
				PauseMenu.transform.position = transform.position + new Vector3(0, 0, 1.3f);
			}
			else
			{
				PauseMenu.transform.position += new Vector3(0, 0, -31);
			}
		}

		if(Changing)
			ExecuteChange();
	}

	void ExecuteChange()
	{
		if (Mathf.Abs (transform.position.z - TargetZ) > Time.deltaTime)
		{
			transform.position +=Speed;
		}
		else
		{
			Changing = false;
		}

	}

	public void StartChange(float z)
	{
		TargetZ = z;
		Changing = true;

		if (TargetZ > transform.position.z)
			Speed = new Vector3(0, 0, 1 * Time.deltaTime);
		else
			Speed = new Vector3(0, 0, -1 * Time.deltaTime);
	}

}
