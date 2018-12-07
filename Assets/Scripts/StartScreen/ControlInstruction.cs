using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlInstruction : MonoBehaviour {
    public GameObject instruction;
    int loseway = 0;
    int jump = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            loseway++;
            if (loseway > 3)
            {
                jump = 0;
                instruction.GetComponent<TextMeshPro>().text = "Trust me! Just press F! ";
            }
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump++;
            if (jump > 3)
            {
                loseway = 0;
                instruction.GetComponent<TextMeshPro>().text = "You can not jump over it! Just press F! ";
            }
        }
    }
}
