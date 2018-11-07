using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Door : MonoBehaviour {

    public int keyNumber = 0;
    public int keyRequired;
    TextMesh doorNumber;
    public GameObject canvas;

    private void Start()
    {
        doorNumber = GetComponentInChildren<TextMesh>();
    }
    private void Update()
    {
        doorNumber.text = (keyRequired - keyNumber).ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && keyNumber>=keyRequired)
        {
            if (SceneManager.GetActiveScene().buildIndex < 10)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            else
            {
                Time.timeScale = 0;
                canvas.SetActive(true);
            }
        }
    }
}
