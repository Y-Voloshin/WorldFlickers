using UnityEngine;
using System.Collections;

public class CloudPieceInventoryObject : MonoBehaviour {

	public GameObject ObjectAfterActivation;
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//ObjectAfterActivation.GetComponent<CloudPiece>().JustDropped = true;
		CheckDropCloudPiece ();
	}

	void CheckDropCloudPiece()
	{
		if (GetComponent<InventoryObject>().Active && GetComponent<InventoryObject>().Selected)
			//if (GetComponent<InventoryObject>().Selected)
				if (Input.GetKeyDown (GameSettings.UseInventory)) {
					ObjectAfterActivation.GetComponent<CloudPiece> ().DropPiece ();
					//ObjectAfterActivation.GetComponent<CloudPiece>().JustDropped = true;
					GetComponent<InventoryObject>().Deactivate();
				}
	}
}
