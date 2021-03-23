using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionController : MonoBehaviour
{
    public Decision decision;
    public Button choiceButton;

    private List<DecisionController> decisionControllers = new List<DecisionController>();

    public void Change(Decision _decision)
    {
        RemoveChoices();
        decision = _decision;
        gameObject.SetActive(true);
        Initialize();
    }

    public void Hide(Conversation conversation)
    {
        RemoveChoices();
        gameObject.SetActive(false);
    }

    private void RemoveChoices()
    {
        foreach (DecisionController d in decisionControllers)
            Destroy(d.gameObject);

        decisionControllers.Clear();
    }

    private void Initialize()
    {
        for(int index = 0; index < decision.choices.Length; index++)
        {
            DecisionController d = DecisionController.AddChoiceButton(choiceButton, decision.choices[index], index);
            decisionControllers.Add(d);
        }

        choiceButton.gameObject.SetActive(false);
    }
}
