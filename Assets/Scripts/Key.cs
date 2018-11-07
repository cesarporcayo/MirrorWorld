using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {
    public GameObject dummySphere;
    public GameObject Door;
    bool picked = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && picked == false)
        {
            picked = true;
            Debug.Log("HERE");
            Door.GetComponent<Door>().keyNumber+=1;
            Destroy(this.transform.parent.gameObject);
            dummySphere.GetComponent<MeshRenderer>().materials[0].color = Color.white;
        }
    }
}
