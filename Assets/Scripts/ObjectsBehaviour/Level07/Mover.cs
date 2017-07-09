using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {


	public bool Moving, Rotating, MoveBackOnSecondPress, SecondPress, Active;
	public Vector3 StepMove, StepRotate;
	public float RotateTime, MoveTime, CurrentRotateTime, CurrentMoveTime, initDeltaTime;
	public Vector3 MoveSpeed, RotateSpeed;


	// Use this for initialization
	void Start () {
		initDeltaTime = Time.deltaTime;

		MoveSpeed = (StepMove) / MoveTime * initDeltaTime;
		RotateSpeed = (StepRotate) / RotateTime * initDeltaTime;
	}
	
	// Update is called once per frame
	void Update () {
		if (Active)
			Move ();
	}

	public void Activate()
	{
		if (Active)
		{
			if (MoveBackOnSecondPress)
			{
				CurrentMoveTime = MoveTime - CurrentMoveTime;
				CurrentRotateTime = RotateTime - CurrentRotateTime;
			}
		}
		else
		{

			if (MoveBackOnSecondPress)
			{
				CurrentMoveTime = MoveTime - CurrentMoveTime;
				CurrentRotateTime = RotateTime - CurrentRotateTime;
			}

				Active = true;
				CurrentMoveTime = 0;
				CurrentRotateTime = 0;
		}
	}

	public void Deactivate()
	{
		Active = false;
		{

				}
		if (MoveBackOnSecondPress)
		{
			MoveSpeed = - MoveSpeed;
			RotateSpeed = -RotateSpeed;
		}
	}

	public void Move()
	{
		bool InProgress = false;

		if (Moving)
		{

			if (CurrentMoveTime < MoveTime)
			{
				transform.position += MoveSpeed;
				CurrentMoveTime += initDeltaTime;
				InProgress = true;

			}
		}

		if (Rotating)
		{
			if (CurrentRotateTime < RotateTime)
			{
				transform.Rotate (RotateSpeed);
				CurrentRotateTime += initDeltaTime;
				InProgress = true;
			}
		}

		if (!InProgress)
		{
			CurrentMoveTime = 0;
			CurrentRotateTime = 0;
			SecondPress = !SecondPress;
			Deactivate();
		}

	}
}
