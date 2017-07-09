using UnityEngine;
using System.Collections;

public class TravelFish : MonoBehaviour {

	public Vector3 StartPoint;
	public float SpeedX = 1, SpeedY = 1;

	public Vector3[] Points;

	public Vector3 SpeedV3, SpeedV3_X, SpeedV3_Y;

	public int CurPointId = 0, PointsLenght;
	//Vector3 CurPoint, EndPoint;
	bool Moving = false;
	public bool Active = false;
	public bool bigdist_x = true, bigdist_y = true;
	GameObject Hero, HeroBottom;



	public float CurXPos, TargetXPos;

	Vector3 LeftLocalScale, RightLocalScale;

	// Use this for initialization
	void Start () {
		Hero = GameObject.Find("Hero");
		HeroBottom = GameObject.Find("HeroBottom");

		//EndPoint = StartPoint;
		 CurPointId = 0;
		PointsLenght = Points.Length;
		SpeedV3 = new Vector3(Time.deltaTime * SpeedX, Time.deltaTime * SpeedY, 0);
		SpeedV3_X = new Vector3(Time.deltaTime * SpeedX, 0, 0);
		SpeedV3_Y = new Vector3(0, Time.deltaTime * SpeedY, 0);

		LeftLocalScale = transform.localScale;
		RightLocalScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z); 

	}
	
	// Update is called once per frame
	void Update () {
		if (Active)//Рыба задействована
		{
			if (!Moving)//Если не двигается
			{
				if (GetComponent<Collider>().bounds.Intersects(HeroBottom.GetComponent<Collider>().bounds))//Герой уже в рыбе
				{

					if (CurPointId == Points.Length)//Если уже проплыли все точки
					{
						Hero.GetComponent<PlayerController>().Locked = false;//Разблокируем героя
						Active = false;//Блокируем рыбу
						Moving = false;//На всякий случай
					}
					else
					{
						Moving = true;

						CurXPos = transform.position.x;
						TargetXPos = Points[CurPointId].x;

						Hero.GetComponent<PlayerController>().Locked = true;

						CalculateDirection(Points[CurPointId].x, Points[CurPointId].y);
					}
				}
				else//Герой не в рыбе - подплываем на начальную точку
				{
					if ((Mathf.Abs(transform.position.x - StartPoint.x) > 0.05) ||
					    (Mathf.Abs(transform.position.y - StartPoint.y) > 0.05))
					{
						CalculateDirection(StartPoint.x, StartPoint.y);
												
						Moving = true;
					}
				}
			}
			else//Если двигается
			{
				//CurXPos = transform.position.x;
				//TargetXPos = Points[CurPointId].x;

				if (GetComponent<Collider>().bounds.Intersects(HeroBottom.GetComponent<Collider>().bounds))//Герой уже в рыбе
				{
					if (CurPointId == Points.Length)
					{
						Moving = false;
					}
					else //Не все точки прошли
					{

						bigdist_x = IsBigDist (transform.position.x, Points[CurPointId].x);
						bigdist_y = IsBigDist (transform.position.y, Points[CurPointId].y);
						if (! (bigdist_x || bigdist_y))
						{
							CurPointId ++;

							if (CurPointId == Points.Length)
							{
								Moving = false;
							}
							else
							{
								CalculateDirection(Points[CurPointId].x, Points[CurPointId].y);
							}
						}
						else
						{
							MoveToPoint(Points[CurPointId]);
						}
					}
				}
				else
				{
					if ((Mathf.Abs(transform.position.x - StartPoint.x) > 0.05) ||
					    (Mathf.Abs(transform.position.y - StartPoint.y) > 0.05))
					{
						MoveToPointWithoutHero(StartPoint);
					}
					else
					{
						Moving = false;
					}
				}

			}
		}
	}

	void MoveToPoint(Vector3 point)
	{
		bigdist_x = IsBigDist (transform.position.x, point.x);
		bigdist_y = IsBigDist (transform.position.y, point.y);
		if (bigdist_x)
		{
			ExecuteMove(SpeedV3_X);
		}

		if (bigdist_y)
		{
			ExecuteMove(SpeedV3_Y);
		}
	}

	void ExecuteMove(Vector3 delta)
	{
		transform.position += delta;
		Hero.transform.position += delta;
	}

	void MoveToPointWithoutHero(Vector3 point)
	{
		bigdist_x = IsBigDist (transform.position.x, point.x);
		bigdist_y = IsBigDist (transform.position.y, point.y);
		if (bigdist_x)
		{
			ExecuteMoveWithoutHero(SpeedV3_X);
		}
		
		if (bigdist_y)
		{
			ExecuteMoveWithoutHero(SpeedV3_Y);
		}
	}
	
	void ExecuteMoveWithoutHero(Vector3 delta)
	{
		transform.position += delta;
		//Hero.transform.position += delta;
	}

	void CalculateDirection(float DestinationX, float DestinationY)
	{
		if (DestinationX > transform.position.x)
		{
			SpeedV3_X = new Vector3(Time.deltaTime * SpeedX, 0, 0);
			transform.localScale = RightLocalScale;
		}
		else
		{
			SpeedV3_X = new Vector3(-Time.deltaTime * SpeedX, 0, 0);
			transform.localScale = LeftLocalScale;
		}

		if (DestinationY > transform.position.y)
		{
			SpeedV3_Y = new Vector3(0, Time.deltaTime * SpeedY, 0);
		}
		else
		{
			SpeedV3_Y = new Vector3(0, -Time.deltaTime * SpeedY, 0);
		}

	}

	bool IsBigDist(float point1, float point2)
	{
		return Mathf.Abs (point1 - point2) > 0.05f;
	}
}
