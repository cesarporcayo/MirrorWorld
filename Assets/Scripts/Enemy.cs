using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    
    public Transform ori,des;
    int point = 1;
    public float velocity = 5f;
    Vector3 facing;

    private void Start()
    {
        facing = (des.position - ori.position).normalized;
    }
    void Update()
    {
        transform.position = transform.position + velocity * Time.deltaTime * facing;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, facing,10f, 0 << 11);
        Debug.Log(hit.transform.gameObject.tag);

        Debug.DrawLine(transform.position, hit.point, Color.red, 1);
        if (hit.transform.gameObject.tag == "Environment" && Vector3.Distance(new Vector3(transform.position.x, 0, 0), new Vector3(hit.point.x, 0, 0)) < 1f)
        {
            facing = -facing;
            transform.RotateAround(transform.position, Vector3.up, 180);
        }

        else if (Vector3.Distance(new Vector3(transform.position.x, 0, 0), new Vector3(des.position.x, 0, 0)) < 0.1f || Vector3.Distance(new Vector3(transform.position.x, 0, 0), new Vector3(ori.position.x, 0, 0)) < 0.1f)
        {
            facing = -facing;
            transform.RotateAround(transform.position, Vector3.up, 180);
        }
    }
}
