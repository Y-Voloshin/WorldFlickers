using UnityEngine;
using System.Collections;

public class MenuItem : MonoBehaviour {


	public Color ActiveColor, InactiveColor;
	public bool ExitButton;
	public string SceneName = "";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseEnter()
	{
		GetComponent<GUIText>().color = ActiveColor;
	}

	void OnMouseExit()
	{
		GetComponent<GUIText>().color = InactiveColor;
	}

	void OnMouseUp()
	{
		if (ExitButton)
			Application.Quit();
		else
			if (SceneName != "")
				Application.LoadLevel(SceneName);
	}
}
