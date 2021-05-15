using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OrderListEntry : MonoBehaviour
{
    public OrdersData ordersData;

    public Image npcPortrait;
    public TextMeshProUGUI npcName;
    public TextMeshProUGUI orderDescription;
    public Image rewardIcon;
    public TextMeshProUGUI rewardDescription;
    public Button orderButton;

    [Header("Debug Options")]
    public bool isComplete;

    // Start is called before the first frame update
    void Start()
    {
        npcPortrait.sprite = ordersData.NpcIcon;
        npcName.text = ordersData.NpcName;
        orderDescription.text = ordersData.orderDescription;
        rewardIcon.sprite = ordersData.rewardImage;
        rewardDescription.text = "Reward: " + ordersData.rewardAmount + " Gold";
        orderButton.interactable = ordersData.orderComplete;
    }

    public void SetInteractable()
    {
        orderButton.interactable = ordersData.orderComplete;
    }

    public void Deliver()
    {
        ordersData.isDelivered = true;
        gameObject.SetActive(false);
    }
}
