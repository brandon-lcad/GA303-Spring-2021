using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[System.Serializable]
public class ConversationChangeEvent : UnityEvent<Conversation> {}

public class DecisionController : MonoBehaviour
{
    public Choice choice;
    public ConversationChangeEvent conversationChangeEvent;
    
    public static DecisionController AddChoiceButton(Button templateButton, Choice choice, int index)
    {
        Button button = Instantiate(templateButton);

        //button.Transform.SetParent(templateButton.transform.parent);
        button.name = "Choice " + (index + 1);
        button.gameObject.SetActive(true);

        DecisionController decisionController = button.GetComponent<DecisionController>();
        decisionController.choice = choice;
        return decisionController;
    }

    void Start()
    {
        if (conversationChangeEvent == null)
            conversationChangeEvent = new ConversationChangeEvent();

        GetComponent<Button>().GetComponentInChildren<Text>().text = choice.text;
    }

    public void MakeDecision()
    {
        conversationChangeEvent.Invoke(choice.nextConversation);
    }
}
