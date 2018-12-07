using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {
    public GameObject dummySphere;
    public GameObject Door;
    bool picked = false;

    public AudioSource sound;

	private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Player" && picked == false)
        {
            sound.Play();
            picked = true;
            Debug.Log("did so");
            // float doorSize = (Door.GetComponent<Door>().keyNumber * .4F) + 0;
            // Door.transform.localScale += new Vector3(0, doorSize, 0);
            Door.GetComponent<Door>().keyNumber+=1;
            dummySphere.GetComponent<MeshRenderer>().materials[0].color = Color.white;
            Destroy(this.transform.parent.gameObject);
        }
            
    }
}
