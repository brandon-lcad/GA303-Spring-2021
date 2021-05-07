using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Savepp : MonoBehaviour
{[SerializeField]
    private DistortionManager Dlevel;
    [SerializeField]
    private DialogueManager_V02 ALI;
    public int Distortion;
    public int ActiveLineIndex;
    public Conversation convo;

    



    void Start()
    {
        //Change distortion manager = new int()
        //Distortion = PlayerPrefs.GetInt("currentDistortion");
        //need to set

        //Change ALI
        //ActiveLineIndex = Playerprefs.GetInt("currentActiveLineIndex");
        //need to set
    }
    // need to change to onclick save button
    void Update()
    {
        // DistortionManager.GetInt(distortionLevel);


    }

    public void Buttonclicked()
    {

        Distortion = Dlevel.distortionLevel;
        ActiveLineIndex = ALI.activeLineIndex;
        convo = ALI.convo;
        //con = convo;




        Debug.Log("Distortion is" + Distortion);
        Debug.Log("Active line is" + ActiveLineIndex);
        Debug.Log("Current Convo is" + convo);
        //saves
        PlayerPrefs.SetInt("currentDistortion", Distortion);
        PlayerPrefs.SetInt("currentActiveLineIndex", ActiveLineIndex);
        //PlayerPrefs.SetString("currentConvo", convo);

    }

}
