using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class ConversationChangeEvent : UnityEvent<Conversation> {}

public class DecisionController : MonoBehaviour
{
    public Choice choice;
    public ConversationChangeEvent conversationChangeEvent;

    public SceneChange sceneChange;

    // Uses "Template Button" to make the choice buttons
    public static DecisionController AddChoiceButton(Button templateButton, Choice choice, int index, GameObject choicePanel)
    {
        Button button = Instantiate(templateButton);

    // Trying to use Layout Groups to bypass need to manually position buttons, may need these lines later
        // int buttonSpacing = -44;
        //button.transform.SetParent(templateButton.transform.parent);
        //button.transform.local Scale = Vector3.one;
        //button.transform.localPosition = new Vector3(0, index * buttonSpacing, 0);

        // Names the button and sets it to active
        button.name = "Choice " + (index + 1);
        button.gameObject.SetActive(true);
        button.transform.SetParent(choicePanel.transform, false);

        // Gets the DecisionController off of the button and sets the proper data in the Choice, then returns
        DecisionController decisionController = button.GetComponent<DecisionController>();
        // Get DialogueManager in order to send message asking to change the active
        decisionController.choice = choice;
        button.onClick.AddListener(() => SetChoice(choice.nextConversation));
        button.onClick.AddListener(() => SendDistortionLevel(choice.distortionEffect));
        button.onClick.AddListener(() => LoadScene(choice.nextScene));
        return decisionController;
    }

    private static void SetChoice(Conversation nextConversation)
    {
      GameObject dm = GameObject.Find("Dialogue Manager");
      dm.SendMessage("ChangeConversation", nextConversation);
    }

    void Start()
    {
        // If there's no Conversation Change Event, make one
        if (conversationChangeEvent == null)
            conversationChangeEvent = new ConversationChangeEvent();

        // Get the text component in the button and set the text to match the choice text
        GetComponent<Button>().GetComponentInChildren<Text>().text = choice.text;
    }

    // Invokes the event and broadcasts what conversation to load based on choice
    public void MakeDecision()
    {
        conversationChangeEvent.Invoke(choice.nextConversation);
    }

    private static void SendDistortionLevel(int distortionChange)
    {
      GameObject distortionManager = GameObject.Find("DistortionManager");
      distortionManager.SendMessage("UpdateDistortionLevel", distortionChange);
    }

    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
