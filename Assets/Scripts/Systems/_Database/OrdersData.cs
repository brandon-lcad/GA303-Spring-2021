using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Order", menuName = "Systems/Orders")]
public class OrdersData : OrdersTemplate
{
    [Header("Order Data")]
    public CraftablesData orderObjective;

    public bool orderComplete;
    public bool isDelivered;

    public bool orderTimed;
    public bool orderActive;
    public int orderTimer;
}
