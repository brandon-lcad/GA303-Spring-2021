using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ConversationChangeEvent : UnityEvent<Conversation> {}

public class DecisionManager : MonoBehaviour
{
    public Decision decision;
    public ConversationChangeEvent conversationChangeEvent;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
