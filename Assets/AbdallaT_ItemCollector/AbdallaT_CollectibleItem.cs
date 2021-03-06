using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbdallaT_CollectibleItem : MonoBehaviour {
    public float xRotation = 10f; 
    public float yRotation = 10f; 
    public float zRotation = 10f; 

    // Update is called once per frame
    void Update() {
        transform.Rotate(new Vector3(xRotation, yRotation, zRotation) * Time.deltaTime);
    }
}
