using UnityEngine;
using System.Collections;

public class FlickerObject : MonoBehaviour {

	public Color ColorLight = new Color(1f, 1f, 1f, 1f),
				ColorDark = new Color(0, 0, 0, 0);
	Color ColorSwitch = new Color(0.5f, 0.5f, 0.5f, 0.5f),
			ColorSpeed;

	int direction = 1;

	public bool ColorFlicker = false, AlphaFlicker = true, 
				UseCurrentColorAsLight = true, RandomizeCurrentColor = true;

	public Color CurrentColor;
	public float LightToDarkTime = 300, CurrentColorPos = -1;
	bool Solid = true;

	GameObject Hero, HeroBottom;

	public Vector3 contactnormal = new Vector3();

	// Use this for initialization
	void Start () {

		Hero = GameObject.Find("Hero");
		HeroBottom = GameObject.Find("HeroBottom");

		RandomizeFlickerObject ();
	}

	void RandomizeFlickerObject()
	{

		float dir = Random.Range (-1, 1);
		if (dir >= 0)
			direction = 1;
		else
			direction = -1;
		
		//collider.
		CheckLightBigger ();
		
		if (CurrentColorPos == -1)
			CurrentColorPos = Random.Range (0f, 1f);
		
		if (!ColorFlicker)
		{
			ColorLight = new Color(GetComponent<Renderer>().material.color.r, GetComponent<Renderer>().material.color.g, GetComponent<Renderer>().material.color.b, ColorLight.a);
			ColorDark = new Color(GetComponent<Renderer>().material.color.r, GetComponent<Renderer>().material.color.g, GetComponent<Renderer>().material.color.b, ColorDark.a);
		}
		
		if (!AlphaFlicker)
		{
			ColorLight = new Color(ColorLight.r, ColorLight.g, ColorLight.b, GetComponent<Renderer>().material.color.a);
			ColorDark = new Color(ColorDark.r, ColorDark.g, ColorDark.b, GetComponent<Renderer>().material.color.a);
		}
		
		
		CurrentColor = new Color ((ColorLight.r - ColorDark.r) * CurrentColorPos + ColorDark.r,
		                          (ColorLight.g - ColorDark.g) * CurrentColorPos + ColorDark.g,
		                          (ColorLight.b - ColorDark.b) * CurrentColorPos + ColorDark.b,
		                          (ColorLight.a - ColorDark.a) * CurrentColorPos + ColorDark.a);
		
		GetComponent<Renderer>().material.color = CurrentColor;
		//renderer.material.SetColor (0, CurrentColor);
		
		ColorSwitch = new Color ((ColorLight.r + ColorDark.r) / 2,
		                         (ColorLight.g + ColorDark.g) / 2,
		                         (ColorLight.b + ColorDark.b) / 2,
		                         (ColorLight.a + ColorDark.a) / 2);
		
		ColorSpeed = new Color ((ColorLight.r - ColorDark.r) / LightToDarkTime,
		                        (ColorLight.g - ColorDark.g) / LightToDarkTime,
		                        (ColorLight.b - ColorDark.b) / LightToDarkTime,
		                        (ColorLight.a - ColorDark.a) / LightToDarkTime);
	}

	void CheckLightBigger()
	{
		float temp;
		if (ColorLight.r < ColorDark.r)
		{
			temp = ColorLight.r;
			ColorLight.r = ColorDark.r;
			ColorDark.r = temp;
		}
		if (ColorLight.g < ColorDark.g)
		{
			temp = ColorLight.g;
			ColorLight.g = ColorDark.g;
			ColorDark.g = temp;
		}
		if (ColorLight.b < ColorDark.b)
		{
			temp = ColorLight.b;
			ColorLight.b = ColorDark.b;
			ColorDark.b = temp;
		}
		if (ColorLight.a < ColorDark.a)
		{
			temp = ColorLight.a;
			ColorLight.a = ColorDark.a;
			ColorDark.a = temp;
		}

	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (GameSettings.RandomizeFlickerObjects))
			RandomizeFlickerObject();

		UpdateColor ();

		if (Solid)
		{
			if (GetComponent<Collider>().bounds.Intersects(HeroBottom.GetComponent<Collider>().bounds))
			{
				if (Hero.GetComponent<CharacterController>().isGrounded || (Hero.GetComponent<CharacterController> ().velocity.y <=0))
					GetComponent<Collider>().isTrigger = false;
				else
				{
					if (!GetComponent<Collider>().bounds.Intersects(Hero.GetComponent<Collider>().bounds))
							GetComponent<Collider>().isTrigger = false;
					else { GetComponent<Collider>().isTrigger = true; }
				}
			}
			else { GetComponent<Collider>().isTrigger = true; }
		}
		else GetComponent<Collider>().isTrigger = true;

		GetComponent<Renderer>().material.color = CurrentColor;
		//renderer.material.color = new Color (1f, 1f, 1f, 0);
	}

	void CheckSolid()
	{
		if (ColorFlicker)
		{
			if (AlphaFlicker)
				Solid = ((CurrentColor.r >= ColorSwitch.r) 
				         && (CurrentColor.g >= ColorSwitch.g) 
				         && (CurrentColor.b >= ColorSwitch.b) 
				         && (CurrentColor.a >= ColorSwitch.a));
			else
				Solid = ((CurrentColor.r >= ColorSwitch.r) 
				         && (CurrentColor.g >= ColorSwitch.g) 
				         && (CurrentColor.b >= ColorSwitch.b));
		}
		else
			Solid = CurrentColor.a >= ColorSwitch.a;
	}

	void UpdateColor()
	{
		if (ColorFlicker)
		{
			CurrentColor.r = GetCurColor(ColorSpeed.r, CurrentColor.r, ColorLight.r, ColorDark.r);
			CurrentColor.g = GetCurColor(ColorSpeed.g, CurrentColor.g, ColorLight.g, ColorDark.g);
			CurrentColor.b = GetCurColor(ColorSpeed.b, CurrentColor.b, ColorLight.b, ColorDark.b);

			if (AlphaFlicker)
			{
				CurrentColor.a = GetCurColor(ColorSpeed.a, CurrentColor.a, ColorLight.a, ColorDark.a);

				if (((CurrentColor.a == ColorLight.a) && (CurrentColor.b == ColorLight.b)
				    && (CurrentColor.g == ColorLight.g) && (CurrentColor.r == ColorLight.r))
				    || ((CurrentColor.a == ColorDark.a) && (CurrentColor.b == ColorDark.b)
				    && (CurrentColor.g == ColorDark.g) && (CurrentColor.r == ColorDark.r)))
						direction = -direction;
			}
			else
			{
				if (((CurrentColor.b == ColorLight.b) && (CurrentColor.g == ColorLight.g) && (CurrentColor.r == ColorLight.r))
				    || ((CurrentColor.b == ColorDark.b) && (CurrentColor.g == ColorDark.g) && (CurrentColor.r == ColorDark.r)))
					direction = -direction;
			}
		}
		else
		{
			CurrentColor.a = GetCurColor(ColorSpeed.a, CurrentColor.a, ColorLight.a, ColorDark.a);

			if ((CurrentColor.a == ColorLight.a) || (CurrentColor.a == ColorDark.a))
				direction = -direction;
		}

		CheckSolid ();
	}

	float GetCurColor(float speed, float Cur, float Max, float Min)
	{
		float res = Cur + speed * direction;
		if (res >= Max)
			res = Max;
		else 
		{
			if (res <= Min)
				res = Min;
		}
		return res;
	}

}
