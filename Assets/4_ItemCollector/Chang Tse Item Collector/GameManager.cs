using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int Points;
    public GameObject WinningImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Points <= 0)
        {
            win();
        }
    }
    void win()
    {
        WinningImage.SetActive(true);
    }
}
