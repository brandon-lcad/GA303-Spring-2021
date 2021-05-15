using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Create a list of orders using the orderSO
 * 
 * Display a list of available orders to the player
 * 
 * Check if the player has the object in their inventory
 * 
 * Allow player to Deliver the order (active Deliver button)
 * 
 * Remove order from the list.
 * 
 * Reward the player
 */

public class OrderController : MonoBehaviour
{
    public List<OrdersData> orders;
    public OrderListEntry[] ordersEntries;
    public Inventory container;
    public GameObject orderEntryPrefab;
    public GameObject entryListContainer;

    private void Start()
    {
        GetNewQuests();
        DisplayQuests();
    }

    private void Update()
    {
        CheckQuestUpdates();
    }

    public void GetNewQuests()
    {
        var availableOrders = Resources.LoadAll<OrdersData>("Scriptable Objects/Orders");

        foreach (var order in availableOrders)
        {
            if (!order.orderComplete) orders.Add(order);
        }
    }

    private void DisplayQuests()
    {
        
        foreach (var order in orders)
        {
            var newEntry = Instantiate(orderEntryPrefab, entryListContainer.transform, false);
            var entryObject = newEntry.GetComponent<OrderListEntry>();
            entryObject.ordersData = order; 
          
        }
    }

    private void CheckQuestUpdates()
    {
        foreach (var order in ordersEntries)
        {
            GetCompletionStatus(order.ordersData);
            if (order.ordersData.orderComplete)
            {
                order.SetInteractable();
            }
        }
    }

    private void GetCompletionStatus(OrdersData order)
    {
        foreach (var item in container.inventoryItems)
        {
            if (item == order.orderObjective)
            {

                order.orderComplete = true;

            }
        }
    }


    public void Deliver(OrderListEntry orderEntry)
    {
        Debug.Log("Deliver clicked.");
        // TODO: add reward to player inventory
        RemoveOrder(orderEntry.ordersData);
    }

    public void RemoveOrder(OrdersData order)
    {
        // TODO: Remove the quest canvas so it doesnt display on the log.
        orders.Remove(order);
    }

    public void DepositReward(Container containerCtrl, OrdersData ordersData)
    {
        container.goldAmount += ordersData.rewardAmount;
    }
}
