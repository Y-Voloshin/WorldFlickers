using UnityEngine;
using System.Collections;

public class CloudPiece : MonoBehaviour {

	GameObject Hero, HeroSprite;
	Transform CloudPieceBottom, CollisionArea;
	Vector3 DropDeltaRight = new Vector3(0.3f, 0.2f, -0.3f), DropDeltaLeft = new Vector3(-0.3f, 0.2f, -0.3f);
	public bool JustDropped = false, IntersectsCloud = false;

	// Use this for initialization
	void Start () {
		CloudPieceBottom = transform.FindChild ("CloudPieceBottom");
		CollisionArea = transform.FindChild("CollisionArea");
		Hero = GameObject.Find ("Hero");
		HeroSprite = GameObject.Find ("HeroSprite");
	}
	
	// Update is called once per frame
	void Update () {
		if (JustDropped)
		{
			//JustDropped = false;
			if (IntersectsCloud)
			{
				JustDropped = false;
			}
			else
			{
				if (CloudPieceBottom.GetComponent<CloudPieceBottom>().IntersectsCloud)
				{
					//transform.position += new Vector3(0, - 0.5f, 0);
					transform.position += new Vector3(0, - (transform.lossyScale.y / 2), 0);
				}
				else
				{
					JustDropped = false;
				}
			}
		}
		else
		{
			JustDropped = (!IntersectsCloud) && CloudPieceBottom.GetComponent<CloudPieceBottom>().IntersectsCloud;
		}
	}

	public void DropPiece()
	{
		JustDropped = true;

		if (HeroSprite.GetComponent<GirlAnimation>().LookLeft)
			transform.position = Hero.transform.position + DropDeltaLeft;
		else
			transform.position = Hero.transform.position + DropDeltaRight;

		if (!JustDropped) JustDropped = true;
		//transform.gameObject//
	}
}
