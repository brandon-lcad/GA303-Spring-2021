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
    public int nowDistortionLevel;
    public int nowActiveLineIndex;
    public Conversation nowConvo;
    public Scene nowScene;
    public string nowConvoName;
    public string nowSceneName;

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

    public void SaveButtonclicked()
    {

        nowDistortionLevel = GlobalChoiceRecorder.GCRInstance.globalDistortionLevel;
        nowActiveLineIndex = ALI.activeLineIndex;
        nowConvo = ALI.convo;
        nowScene = SceneManager.GetActiveScene();



        Debug.Log("Distortion is " + nowDistortionLevel);
        Debug.Log("Active line is " + nowActiveLineIndex);
        Debug.Log("Current Convo is " + nowConvo);
        Debug.Log("Current scene is " + nowScene);

        //set Convo to string
        //saves
        PlayerPrefs.SetInt("SavedDistortionLevel", Dlevel.distortionLevel);
        PlayerPrefs.SetInt("SavedActiveLineIndex", ALI.activeLineIndex);
        PlayerPrefs.SetString("SavedConvo", ALI.convo.name);
        PlayerPrefs.SetString("SavedSceneName", SceneManager.GetActiveScene().name);
        //convo = new string(convostring);
       // convo = convo.ToString();
        //PlayerPrefs.GetString("currentConvo", convo);
    }

    public void LoadButtonClicked()
    {
        nowDistortionLevel = PlayerPrefs.GetInt("SaveDistortionLevel");
        nowActiveLineIndex = PlayerPrefs.GetInt("SavedActiveLineIndex");
        // nowConvoName = PlayerPrefs.GetString("SavedConvo");
        nowSceneName = PlayerPrefs.GetString("SavedSceneName");

        Debug.Log("Distortion is " + nowDistortionLevel);
        Debug.Log("Active line is " + nowActiveLineIndex);
        // Debug.Log("Current Convo is " + nowConvoName);
        Debug.Log("Current scene is " + nowSceneName);
        //PlayerPrefs.SetString("currentConvo", convo);

        Dlevel.SendMessage("savesetdistortion", nowDistortionLevel);
        ALI.SendMessage("savesetALI", nowActiveLineIndex);
        // ALI.SendMessage("savesetConvo", nowConvo);
        UI.SendMessage("LoadScene", nowSceneName);
    }

}
