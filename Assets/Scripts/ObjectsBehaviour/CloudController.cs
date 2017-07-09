using UnityEngine;
using System.Collections;

public class CloudController : MonoBehaviour {

	GameObject[]Clouds, SkyClouds;
	public GameObject[] CloudPieces;

	public float ScaleX, ScaleY, PosX, PosY, PosX2, PosY2;
	// Use this for initialization
	void Start () {
		Clouds = GameObject.FindGameObjectsWithTag("Cloud");
		SkyClouds = GameObject.FindGameObjectsWithTag("SkyCloud");

	}

	void Update()
	{
		CalcCloudPieceBottomCollisions();
		CalcCollisions(Clouds);
		CalcCollisions(SkyClouds);

	}
	
	// Update is called once per frame
	void CalcCollisions (GameObject[] CloudsArray) {

		for (int i = 0; i < CloudsArray.Length; i++)
			CloudsArray[i].transform.Find("CollisionArea").GetComponent<CloudCollisionArea>().Solid = false;


		bool solid;
		int Cloud1Id = -1, Cloud2Id = -1;
		if (CloudsArray.Length > 1)
		{
			for (int i = 0; i < (CloudsArray.Length - 1); i++)
			{
				solid = false;
				//Cloud2Id = -1;
				for (int j = i + 1; j < CloudsArray.Length; j++)
				{
					Cloud1Id = i; Cloud2Id = j;

					if (CloudsArray[i].GetComponent<Collider>().bounds.Intersects(CloudsArray[j].GetComponent<Collider>().bounds))
					{

						bool solid1 = CloudsArray[i].transform.Find("CollisionArea").GetComponent<CloudCollisionArea>().Solid,
							solid2 = CloudsArray[j].transform.Find("CollisionArea").GetComponent<CloudCollisionArea>().Solid;
						
						solid = true;
						/*
						if ((!solid1) || (!solid2))
						{

							if (CloudsArray[i].transform.Find("CollisionArea").GetComponent<CloudCollisionArea>().Solid)
							{
								Cloud1Id = j; Cloud2Id = i;
							}

							CalcCollisionArea(CloudsArray, Cloud1Id, Cloud2Id);


						}
						*/
						if (solid1)
						{
							Cloud1Id = j; Cloud2Id = i;
						}
						CalcCollisionArea(CloudsArray, Cloud1Id, Cloud2Id);

						solid = true;
					}
				}

				//CloudsArray[Cloud1Id].transform.Find("CollisionArea").GetComponent<CloudCollisionArea>().Solid = solid;
			}
		}
	}

	void CalcCloudPieceBottomCollisions()
	{
		bool solid, solid2;
		//int Cloud1Id = -1, Cloud2Id = -1;
		if ((SkyClouds.Length > 1) && (CloudPieces.Length > 1))
		{
			for (int i = 0; i < CloudPieces.Length; i++)
			{
				solid = false; solid2 = false;
				//Cloud2Id = -1;
				for (int j = 0; j < SkyClouds.Length; j++)
				{
					if ((CloudPieces[i]!= SkyClouds[j]) && CloudPieces[i].GetComponent<Collider>().bounds.Intersects(SkyClouds[j].GetComponent<Collider>().bounds)) solid2 = true;
					if (CloudPieces[i].transform.Find("CloudPieceBottom").GetComponent<Collider>().bounds.Intersects(SkyClouds[j].GetComponent<Collider>().bounds)) solid = true;
					
				}
				CloudPieces[i].GetComponent<CloudPiece>().IntersectsCloud = solid2;
				CloudPieces[i].transform.Find("CollisionArea").GetComponent<CloudCollisionArea>().Solid = solid2;
				CloudPieces[i].transform.Find("CloudPieceBottom").GetComponent<CloudPieceBottom>().IntersectsCloud = solid;
			}
		}
	}

	void CalcCollisionArea(GameObject[] CloudsArray, int id1, int id2)
	{
		float HalfX1 = CloudsArray[id1].transform.lossyScale.x / 2,
		HalfY1 = CloudsArray[id1].transform.lossyScale.y  / 2,
		HalfX2 = CloudsArray[id2].transform.lossyScale.x  / 2,
		HalfY2 = CloudsArray[id2].transform.lossyScale.y  / 2;

		PosX = Mathf.Max(CloudsArray[id1].transform.position.x - HalfX1, CloudsArray[id2].transform.position.x - HalfX2);
		PosY = Mathf.Max(CloudsArray[id1].transform.position.y - HalfY1, CloudsArray[id2].transform.position.y - HalfY2);
		PosX2 = Mathf.Min(CloudsArray[id1].transform.position.x + HalfX1, CloudsArray[id2].transform.position.x + HalfX2);
		PosY2 = Mathf.Min((CloudsArray[id1].transform.position.y + HalfY1), CloudsArray[id2].transform.position.y + HalfY2);

		ScaleX = (PosX2 - PosX) / CloudsArray[id1].transform.lossyScale.x;
		ScaleY = (PosY2 - PosY) / CloudsArray[id1].transform.lossyScale.y;
		
		PosX = (PosX2 + PosX) / 2;
		PosY = (PosY2 + PosY) / 2;
		
		CloudsArray[id1].transform.Find("CollisionArea").transform.position = new Vector3(PosX, PosY, CloudsArray[id1].transform.Find("CollisionArea").transform.position.z);
		
		CloudsArray[id1].transform.Find("CollisionArea").transform.localScale = new Vector3(ScaleX, ScaleY, CloudsArray[id1].transform.Find("CollisionArea").transform.localScale.z);
		
		CloudsArray[id1].transform.Find("CollisionArea").GetComponent<CloudCollisionArea>().Solid = true;
	}
}
