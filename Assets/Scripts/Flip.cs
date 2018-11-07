using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour {

    public GameObject flipAxis;
    public GameObject FlippableObjects;
    public bool rotating = false;
    public float rotationTime = 2f;
    public float anticipatedRotationAngle = 100f;
    float rotationStep;
    float timer = 0f;
    float totalRotationAngle = 0f;
    public bool aticipatedRotation = true;
    // Use this for initialization
    void Start () {
        rotationStep = anticipatedRotationAngle / (rotationTime / Time.deltaTime);
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.F))
        {
            rotating = true;
            timer = Time.time;
            totalRotationAngle = 0f;
        }

        if (aticipatedRotation)
        {
            if (rotating)
            {
                FlippableObjects.transform.RotateAround(flipAxis.transform.position, Vector3.up, rotationStep);
                totalRotationAngle += rotationStep;
                if (Time.time - timer > rotationTime)
                {
                    
                    rotating = false;
                    FlippableObjects.transform.RotateAround(flipAxis.transform.position, Vector3.up, 180- totalRotationAngle);
                }
            }
        }
        else
        {
            if (rotating)
            {
                FlippableObjects.transform.RotateAround(flipAxis.transform.position, Vector3.up, 180);
            }
            rotating = false;
        }
	}
}
