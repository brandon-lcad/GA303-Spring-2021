using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playController : MonoBehaviour
{
    private Rigidbody playerObject; //References the player's RigidBody component
    public float speed = 10f;
    public Image winPic;

    // Start is called before the first frame update
    void Start() {
        playerObject = GetComponent<Rigidbody>();
        winPic = GetComponent<Image>();
        winPic.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        float moveHorizontal = Input.GetAxis("Horizontal"); //References "A" and "D" movement keys
        float moveVertical = Input.GetAxis("Vertical"); //References "W" and "S" movement keys

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        playerObject.AddForce(movement * speed); //Applies directional force

        Debug.Log("Hor: " + moveHorizontal);
        Debug.Log("Ver: " + moveVertical);

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Collectible"))
            {
                other.gameObject.SetActive(false);
            }

            if (GameObject.FindGameObjectsWithTag("Collectible").Length == 0)
            {
                winPic.gameObject.SetActive(true);
                Debug.Log("You win!")
            }
        }
    }
}
