using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WinScreen_Hikari : MonoBehaviour
{
      public Sprite TinrifficImage; // To let the player know they won
      public Image BackgroundImage;
      public TextMeshProUGUI screenText;

      private bool DonewithGame;
    // Start is called before the first frame update
    void Start()
    {
        DonewithGame = false;
        BackgroundImage.color = new Color(255, 255, 255, 0);
        screenText.faceColor = new Color32(255, 138, 146, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!DonewithGame){GameObject[] pies = GameObject.FindGameObjectsWithTag("Collectible");

        if (pies.Length == 0)
        {
          SetWinScreen();
        }}
    }

    void SetWinScreen() {
      BackgroundImage.color = new Color(255, 255, 255, 255);
      screenText.faceColor = new Color32(255, 138, 146, 255);
      screenText.text = "Tin-riffic! You win!";
      BackgroundImage.sprite = TinrifficImage;
      DonewithGame = true;
    }
}
