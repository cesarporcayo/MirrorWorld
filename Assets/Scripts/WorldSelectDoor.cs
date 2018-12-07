using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldSelectDoor : MonoBehaviour {

	public Object sceneToLoad;


	void OnTriggerEnter2D(Collider2D other) {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
