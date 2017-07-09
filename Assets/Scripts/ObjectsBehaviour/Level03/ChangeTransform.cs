using UnityEngine;
using System.Collections;

public class ChangeTransform : MonoBehaviour {

    [SerializeField]
    float time;

    [SerializeField]
    Vector3 RelativeEnd;
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Change()
    {


    }

    IEnumerator Execute()
    {
        Vector3 speed = RelativeEnd / time * Time.smoothDeltaTime;
        float currentTime = 0;
        Transform transf = transform;

        while(currentTime < time)
        {
            currentTime += Time.smoothDeltaTime;
            transf.position += speed;

            yield return null;
        }


    }
}
