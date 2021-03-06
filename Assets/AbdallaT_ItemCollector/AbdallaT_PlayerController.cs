using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbdallaT_PlayerController : MonoBehaviour {
    public float speed = 10f; // A setting that determines the movement speed
    private Rigidbody rb; // A reference to the player's RigidBody component
    public GameObject particle; // The particle effect that plays when an object is collected
    public int theScore;
    public GameObject scoreText;
    public Sprite YouWin; // Image of Winning
    private int maximumScore;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>(); // Gets the Rigidbody component from "this" object
    }

    // Update is called once per physics update
    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal"); // Gets the "A" and "D" input as float value (-1 and 1)
        float moveVertical = Input.GetAxis("Vertical"); // Gets the "S" and "W" input as float value (-1 and 1)

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical); // Vectorized movement direction
        rb.AddForce(movement * speed); // Apply directional force to the rigidbody to move it in that direction
    }

    // Called when the collider enters a "trigger" collider
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Collectible"))
        { // Does the other object have the "Collectible" tag?
            //GameObject effect = Instantiate(particle, other.gameObject.transform);
            //effect.transform.parent = null; 
            other.gameObject.SetActive(false); // Deactivate the other object (uncheck the active box)
            // How many are left? "??? remain"
            // If 0, display "you win". 
            theScore += 1;
            scoreText.GetComponent<Text>().text = "SCORE: " + theScore;
            maximumScore = 28;
            if (theScore >= maximumScore)
            {
                scoreText.GetComponent<Text>().text = "YOU WIN!! ";
            }
        }
    }
}

