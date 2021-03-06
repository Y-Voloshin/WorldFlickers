using UnityEngine;
using System.Collections;

public class GirlController : MonoBehaviour {

	public float speed = 1.5f, jumpSpeed = 2.1f, gravity = 4.0f;
	private float verticalSpeed = 0;
	//private Vector3 moveDirection = Vector3.zero;
	private Vector3 moveDirection = new Vector3 (1, 0, 0);
	public Vector3 CheckPoint = new Vector3 ();

	GameObject[] LightGrounds, DarkGrounds, IlluminatedGrounds, FireGrounds, FireObjects;

	public bool jump = false;
	bool OnDarkGround = false;
	public bool Locked = false;
	GameObject SceneController, HeroBottom;

	public bool StandOnSolid = false;

	public bool Paused = true;

	public int test;

	void Start () {
		SceneController = GameObject.Find("SceneController");
		HeroBottom = GameObject.Find ("Hero2Bottom");

		LightGrounds = GameObject.FindGameObjectsWithTag ("LightGround");
		DarkGrounds = GameObject.FindGameObjectsWithTag ("DarkGround");
		IlluminatedGrounds = GameObject.FindGameObjectsWithTag ("IlluminatedGround");
		FireObjects = GameObject.FindGameObjectsWithTag("FireObject");
		int i = 0;

		foreach (GameObject fObj in FireObjects)
		{
			if (fObj.GetComponent<FireObject>().IsGround)
				i++;
		}
		FireGrounds = new GameObject[i];
		i = 0;
		foreach (GameObject fObj in FireObjects)
		{
			if (fObj.GetComponent<FireObject>().IsGround)
			{
				FireGrounds[i] = fObj;
				//FireGrounds[i].GetComponent<FireObject>().On = true;
				i++;

			}
		}

		CheckPoint = transform.position;

		//test = FireGrounds.Length;
	}

	void Update() {
		if (Input.GetKeyDown (GameSettings.Pause))
						Paused = !Paused;

		if (!Paused) {
						if (!Locked) {
								//bool right = Input.GetKey (GameSettings.MoveRight);
								//bool left = Input.GetKey (GameSettings.MoveLeft);		
								//bool up = Input.GetKeyDown (GameSettings.Jump);


								CharacterController controller = GetComponent<CharacterController> ();


								if (controller.isGrounded)
										CheckGrounds ();
								if (OnDarkGround)
										MoveToCheckPoint ();

								if (controller.isGrounded) {
										verticalSpeed = 0;
										//if (Input.GetButton ("Jump")) {
										//		verticalSpeed = jumpSpeed; 
										//		StandOnSolid = false;
										//}
								}
								else
								{
									verticalSpeed -= gravity * Time.deltaTime;
								}


								//if (right) {
									moveDirection = new Vector3 (speed, 0, 0);
								//} else {
								//	if (left) {
								//		moveDirection = new Vector3 (-speed, 0, 0);
								//	} else
								//		moveDirection = Vector3.zero;
								//}


								
								moveDirection.y = verticalSpeed;
								controller.Move (moveDirection * Time.deltaTime);


								if (transform.position.y < -10) {
										transform.position = new Vector3 (transform.position.x, 8, transform.position.z);
										verticalSpeed = 0;
								}
						}
				}
	}

	void CheckGrounds()
	{
		bool ondark = false, onlight = false;

		foreach (GameObject ground in LightGrounds)
			if (HeroBottom.GetComponent<Collider>().bounds.Intersects(ground.GetComponent<Collider>().bounds))
				onlight = true;

		foreach (GameObject ground in DarkGrounds)
			if (HeroBottom.GetComponent<Collider>().bounds.Intersects(ground.GetComponent<Collider>().bounds))
				ondark = true;

		foreach (GameObject ground in IlluminatedGrounds)
			if (HeroBottom.GetComponent<Collider>().bounds.Intersects(ground.GetComponent<Collider>().bounds))
			{
				if (ground.GetComponent<FloorUnderLight>().Illuminated)
					onlight = true;
				else
					ondark = true;	
			}

		test = FireGrounds.Length;

		foreach (GameObject ground in FireGrounds)
			if (HeroBottom.GetComponent<Collider>().bounds.Intersects(ground.GetComponent<Collider>().bounds))
		{


			if (ground.GetComponent<FireObject>().On)
			{
				onlight = true;

			}
			else
				ondark = true;	
		}
		
		OnDarkGround = ondark && (!onlight);
	}

	public void MoveToCheckPoint()
	{
		;
		transform.position = CheckPoint;
		OnDarkGround = false;
	}
}