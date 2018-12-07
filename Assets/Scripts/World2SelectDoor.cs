using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class World2SelectDoor : MonoBehaviour {

	public Object sceneToLoad;


	void OnTriggerEnter2D(Collider2D other) {
		SceneManager.LoadScene("World2Levels");
	}
}
