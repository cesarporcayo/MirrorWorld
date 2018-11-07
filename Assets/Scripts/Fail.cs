using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fail : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(1);
        if (other.tag == "Player" || other.tag == "Key")
        {
            Debug.Log(2);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
