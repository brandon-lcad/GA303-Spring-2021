using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionController : MonoBehaviour
{
    public Decision decision;
    // public Text questionText;
    public Button choiceButton;
    public GameObject choicePanel;

    private List<DecisionController> decisionControllers = new List<DecisionController>();

    // Changes the active decision in the controller
    public void Change(Decision _decision)
    {
        Debug.Log("CHANGING TO A DECISION");
        RemoveChoices();
        decision = _decision;
        gameObject.SetActive(true);
        Initialize();
        Debug.Log("CHANGED TO DECISION " + _decision.text);
    }

    // Hides the conversation
    public void Hide(Conversation conversation)
    {
        RemoveChoices();
        gameObject.SetActive(false);
    }

    // Clears the current choices available
    private void RemoveChoices()
    {
        foreach (DecisionController d in decisionControllers)
            Destroy(d.gameObject);

        decisionControllers.Clear();
    }


    // Set the visible text to the question text (not used in our version) and call AddChoiceButton to generate buttons
    private void Initialize()
    {
        //questionText.text = question.text;

        for(int index = 0; index < decision.choices.Length; index++)
        {
            DecisionController d = DecisionController.AddChoiceButton(choiceButton, decision.choices[index], index, choicePanel);
            Debug.Log("Print! Decision choice = " + decision.choices[index].text);
            decisionControllers.Add(d);
        }

        // Hides the template button
        choiceButton.gameObject.SetActive(false);
    }
}
