using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flip : MonoBehaviour {

    public GameObject flipAxis;
    public GameObject FlippableObjects;

    public AudioSource flip0;
    public AudioSource flip1;

    public TextMesh flipText;
    public GameObject star1, star2, star3;
    public Sprite starOff;

    private int flipCount = 0;
    private int flip = 1;


    public bool rotating = false;
    public float rotationTime = 2f;
    public float anticipatedRotationAngle = 100f;
    float rotationStep;
    float timer = 0f;
    float totalRotationAngle = 0f;
    public bool aticipatedRotation = true;
    public bool starTest = false;

    // Use this for initialization
    void Start () {
        rotationStep = anticipatedRotationAngle / (rotationTime / Time.deltaTime);
    }
	
	// Update is called once per frame
	void Update () {

        //checkFlipTest();

        if (Input.GetKeyDown(KeyCode.K))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        if (Input.GetKeyDown(KeyCode.L))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if (Input.GetKeyDown(KeyCode.F) && !rotating)
        {
            rotating = true;
            timer = Time.time;
            totalRotationAngle = 0f;
            flipTest();
        }

        if (aticipatedRotation)
        {
            if (rotating)
            {
                this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
                FlippableObjects.transform.RotateAround(flipAxis.transform.position, Vector3.up, rotationStep);
                totalRotationAngle += rotationStep;
                foreach (BoxCollider2D c in FlippableObjects.GetComponentsInChildren<BoxCollider2D>())
                {
                    c.enabled = false;
                }
                if (Time.time - timer > rotationTime)
                {
                    this.GetComponent<Rigidbody2D>().constraints = ~RigidbodyConstraints2D.FreezePosition;
                    rotating = false;
                    FlippableObjects.transform.RotateAround(flipAxis.transform.position, Vector3.up, 180- totalRotationAngle);
                    foreach (BoxCollider2D c in FlippableObjects.GetComponentsInChildren<BoxCollider2D>())
                    {
                        c.enabled = true;
                    }
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


    void flipTest() {

        flipCount++;

        if (starTest)
        {
            if (flipCount > 5)
            {
                star1.GetComponent<SpriteRenderer>().sprite = starOff;
            }
            if (flipCount > 10)
            {
                star2.GetComponent<SpriteRenderer>().sprite = starOff;
            }
            if (flipCount > 15)
            {
                star3.GetComponent<SpriteRenderer>().sprite = starOff;
            }

            flipText.text = flipCount.ToString();
        }

        if (flip == 0) { flip0.Play(); flip = 1; }
        else if (flip == 1) { flip1.Play(); flip = 0; }


    }

    /*void checkFlipTest() {
        if (Input.GetKeyDown(KeyCode.Keypad1)) flip = 0;
        if (Input.GetKeyDown(KeyCode.Keypad2)) flip = 2;
        if (Input.GetKeyDown(KeyCode.Keypad3)) flip = 3;
        if (Input.GetKeyDown(KeyCode.Keypad4)) flip = 4;
    }*/
}
