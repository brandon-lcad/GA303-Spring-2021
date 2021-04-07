using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
    public TextMeshProUGUI clockDisplay;
    public Button journalButton;
    private void FixedUpdate()
    {
        clockDisplay.text = DateTime.Now.ToString("HH:mm");

    }
}
