using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Savepp : MonoBehaviour
{
    [SerializeField]
    private DistortionManager Dlevel;
    [SerializeField]
    private DialogueManager_V02 ALI;
    [SerializeField]
    private UIController UI;
    public int Distortion;
    public int ActiveLineIndex;
    public Conversation convo;
    public string scene;

    



    void Start()
    {
        //Change distortion manager = new int()
        //Distortion = PlayerPrefs.GetInt("currentDistortion");
        //need to set

        //Change ALI
        //ActiveLineIndex = Playerprefs.GetInt("currentActiveLineIndex");
        //need to set
    }
    
    void Update()
    {
        // DistortionManager.GetInt(distortionLevel);


    }

    public void Buttonclicked()
    {

        Distortion = Dlevel.distortionLevel;
        ActiveLineIndex = ALI.activeLineIndex;
        convo = ALI.convo;
        scene = SceneManager.GetActiveScene().name;


        
        Debug.Log("Distortion is" + Distortion);
        Debug.Log("Active line is" + ActiveLineIndex);
        Debug.Log("Current Convo is" + convo);
        Debug.Log("Current scene is" + scene);

        //set Convo to string
        //saves
        PlayerPrefs.GetInt("currentDistortion", Distortion);
        PlayerPrefs.GetInt("currentActiveLineIndex", ActiveLineIndex);
        PlayerPrefs.GetString("CurrentScene", scene);
        //convo = new string(convostring);
       // convo = convo.ToString();
        //PlayerPrefs.GetString("currentConvo", convo);
    }

    public void Loadclicked()
    {
        PlayerPrefs.SetInt("currentDistortion", Distortion);
        PlayerPrefs.SetInt("currentActiveLineIndex", ActiveLineIndex);
        PlayerPrefs.SetString("CurrentScene", scene);
        Debug.Log("Distortion is" + Distortion);
        Debug.Log("Active line is" + ActiveLineIndex);
        Debug.Log("Current Convo is" + convo);
        //PlayerPrefs.SetString("currentConvo", convo);

        Dlevel.SendMessage("savesetdistortion");
        ALI.SendMessage("savesetALI");
        UI.SendMessage("LoadScene", scene);


    }

}
