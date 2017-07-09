using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {

	public int ActiveObjectCount = 0, SelectedObjectId=0;
	public float Delta = 0.2f;
	GameObject SelectedBG;
	public GameObject[] InventoryObjects;

	// Use this for initialization
	void Start () {
		SelectedBG = GameObject.Find("_InventoryBG");
		InventoryObjects = GameObject.FindGameObjectsWithTag("InventoryObject");
															  //InventoryObject
	}
	
	// Update is called once per frame
	void Update () {
		if ( Input.GetKeyDown(GameSettings.NextSelectedInventoryObject))
			SetSelectedNext();
	}

	void EmptyInventory()
	{
		SelectedBG.transform.position += new Vector3(0,0, -20);
		SelectedObjectId = 0;
	}

	void SetSelectedNext()
	{
		if (ActiveObjectCount > 0)
		{
			for (int i = 0; i < InventoryObjects.Length; i++)
				//if (InventoryObjects[i].GetComponent<InventoryObject>().NumberInRow == SelectedObjectId)
					InventoryObjects[i].GetComponent<InventoryObject>().Selected = false;

			SelectedObjectId++;
			if (SelectedObjectId > ActiveObjectCount)
				SelectedObjectId = 1;

			for (int i = 0; i < InventoryObjects.Length; i++)
				if (InventoryObjects[i].GetComponent<InventoryObject>().NumberInRow == SelectedObjectId)
					InventoryObjects[i].GetComponent<InventoryObject>().Selected = true;

			SelectedBG.transform.position = transform.position + new Vector3((SelectedObjectId - 1) * 0.11f, 0, 0.001f);
		}
	}

	public void AddObject()
	{
		ActiveObjectCount ++;
		if (ActiveObjectCount ==1)
			SetSelectedNext();
	}

	public void DeleteObject(int id)
	{
		ActiveObjectCount--;
		if (ActiveObjectCount > 0)
		{
			for (int i = 0; i < InventoryObjects.Length; i++)
				InventoryObjects[i].GetComponent<InventoryObject>().MoveLeftIfNumberIsBigger(id);

			SetSelectedNext();
		}
		else
			EmptyInventory();
	}
}
