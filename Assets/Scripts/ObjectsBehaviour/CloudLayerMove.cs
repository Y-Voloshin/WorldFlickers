using UnityEngine;
using System.Collections;

public class CloudLayerMove : MonoBehaviour {

	public float StartX, EndX, SpeedX;

	Vector3 Speed, StartPoint;
	// Use this for initialization
	void Start () {
		if (StartX > EndX)
		{
				if (SpeedX > 0)
						SpeedX = -SpeedX;
		}
		else
		{
			if (SpeedX < 0)
				SpeedX = -SpeedX;
		}

		Speed = new Vector3(SpeedX * Time.deltaTime, 0, 0);
		StartPoint = new Vector3 (StartX, transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += Speed;
		if (SpeedX > 0)
		{
			if (transform.position.x > EndX)
				transform.position = StartPoint;
		}
		else
		{
			if (transform.position.x < EndX)
				transform.position = StartPoint;
		}
	}
}
