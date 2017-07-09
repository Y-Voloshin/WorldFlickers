using UnityEngine;
using System.Collections;

public class InventoryObject : MonoBehaviour {

	public bool Active = false, Selected = false;
	public int NumberInRow = -1;
	GameObject Inventory;
	public GameObject ObjectAfterActivation;
	// Use this for initialization
	void Start () {
		Inventory = GameObject.Find ("Inventory");
		Active = false;
		Selected = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Activate()
	{
		NumberInRow = Inventory.GetComponent<Inventory> ().ActiveObjectCount + 1;
		Inventory.GetComponent<Inventory> ().AddObject();
		transform.position = new Vector3 ((NumberInRow - 1) * 0.11f, 0, 0) + Inventory.transform.position;
		Active = true;
	}

	public void Deactivate()
	{
		Active = false;
		Selected = false;
		transform.position += new Vector3 (0, 0, -20f);
		Inventory.GetComponent<Inventory> ().DeleteObject(NumberInRow);
		NumberInRow = -1;


	}

	public void MoveLeftIfNumberIsBigger(int DeletedItemNumber)
	{
		if (Active && (NumberInRow > DeletedItemNumber))
		{
			transform.position -= new Vector3 (0.11f, 0, 0);
			NumberInRow--;
		}
	}


}
