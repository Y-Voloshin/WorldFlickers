using UnityEngine;
using System.Collections;

public class GameSettings : MonoBehaviour {

	public static KeyCode MoveRight,
	MoveLeft,
	Jump,
	Use,
	UseInventory,
	NextSelectedInventoryObject,
	RandomizeFlickerObjects,
	Pause,
	Quit;

	public static GameObject Hero;
	
	// Use this for initialization
	void Start () {
		MoveRight = KeyCode.RightArrow;
		MoveLeft = KeyCode.LeftArrow;
		Jump = KeyCode.UpArrow;
		Use = KeyCode.E;
		UseInventory = KeyCode.F;
		NextSelectedInventoryObject = KeyCode.R;
		Pause = KeyCode.Q;
		RandomizeFlickerObjects = KeyCode.T;
		Quit = KeyCode.Escape;

		Hero = GameObject.Find ("Hero");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(Quit))
		{
			if (Application.loadedLevelName == "MainMenu")
				Application.Quit();
			else
				Application.LoadLevel("MainMenu");
		}
	}
}
