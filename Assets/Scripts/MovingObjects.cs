using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjects : MonoBehaviour {

    public GameObject character;
    public Transform startPoint;
    public Transform endPoint;
    public float movingTime = 2f;
    public float movingSpeed;
    float timer = 0;
    public float dir = 1f;
    bool flag = true;
    public bool face = true;

	// Use this for initialization
	void Start ()
    {
        float distance = Vector3.Distance(startPoint.position, endPoint.position);
        float a = Vector3.Distance(startPoint.position, transform.position);
        movingSpeed = distance / movingTime;
        timer = a / distance * movingTime;
        Debug.Log(timer);
    }

    void restart()
    {
        Debug.Log("Here");
        transform.position = startPoint.position;
        timer = 0;
        if (face) dir = 1; else dir = -1;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > movingTime )
        {
            dir *= -1;
            timer = 0;
        }

        if (!character.GetComponent<Flip>().rotating)
        {
            transform.position = new Vector3(transform.position.x + movingSpeed * Time.deltaTime * dir, transform.position.y);
            flag = true;
        }
        else
        {
            if (flag)
            {
                face = !face;
                Debug.Log(face);
                restart();
                flag = false;
            }
        }
    }
}
