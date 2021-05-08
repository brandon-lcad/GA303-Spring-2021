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

    

    void Awake()
    {
        Distortion = 2;
        ActiveLineIndex = 0;
        scene = "02_Home";
        convo.name = "C_1A_Home";

        Distortion = PlayerPrefs.GetInt("currentDistortion", Distortion);
       ActiveLineIndex = PlayerPrefs.GetInt("currentActiveLineIndex", ActiveLineIndex);
        Debug.Log("Distortion is" + Distortion);
    }

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
        PlayerPrefs.SetInt("currentDistortion", Distortion);
        PlayerPrefs.SetInt("currentActiveLineIndex", ActiveLineIndex);
        PlayerPrefs.SetString("CurrentScene", scene);
        PlayerPrefs.SetString("CurrentConvo", convo.name);
        //convo = new string(convostring);
       // convo = convo.ToString();
        //PlayerPrefs.GetString("currentConvo", convo);
    }
   // public string GetString(string CurrentScene)
    //{
        //return PlayerPrefs.GetString(CurrentScene);
     //}
    //public string GetString(string CurrentConvo)
    //{
        //return PlayerPrefs.GetString(CurrentConvo);
    //}

    public void Loadclicked()
    {
        PlayerPrefs.GetInt("currentDistortion", Distortion);
        PlayerPrefs.GetInt("currentActiveLineIndex", ActiveLineIndex);
        PlayerPrefs.GetString("CurrentScene", scene);
        PlayerPrefs.GetString("CurrentConvo", convo.name);

        



       // Distortion = PlayerPrefs.GetInt("currentDistortion", Distortion);
        //ActiveLineIndex = PlayerPrefs.GetInt("currentActiveLineIndex", ActiveLineIndex);
        scene = PlayerPrefs.GetString("CurrentScene", scene);
        Debug.Log("Distortion is" + Distortion);
        Debug.Log("Active line is" + ActiveLineIndex);
        Debug.Log("Current Convo is" + convo);
        //PlayerPrefs.SetString("currentConvo", convo);

        UI.SendMessage("LoadScene", scene);
        Dlevel.SendMessage("savesetdistortion");
        ALI.SendMessage("savesetALI", convo);
        


    }

    public void Continueclick()
    {
       PlayerPrefs.GetInt("currentActiveLineIndex", ActiveLineIndex);
       PlayerPrefs.GetInt("currentDistortion", Distortion);
       PlayerPrefs.GetString("CurrentScene");
        PlayerPrefs.GetString("CurrentConvo");
    }

}
