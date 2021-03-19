using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistortionManager : MonoBehaviour
{
    public Canvas distortionUi;

    public Image vignette;
    public Image horns;
    public Image tail;

    private DialogueManager DL;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Dialogue Manager").GetComponent<DialogueManager>();
        DL = GameObject.Find("Dialogue Manager").GetComponent<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        int distortionLevel = DL.distortionLevel;
        // Activates a set of effects according to distortion level
        if (distortionLevel == 0)
        {
            distortion0();
        }

        else if (distortionLevel <= 20)
        {
            distortion20();
        }

        else if (distortionLevel <= 40)
        {
            distortion40();
        }

        else if (distortionLevel <= 60)
        {
            distortion60();
        }

        else if (distortionLevel <= 80)
        {
            distortion80();
        }

        else if (distortionLevel == 100)
        {
            distortion100();
        }
    }

    // This function toggles effects when distortion level == 0
    void distortion0()
    {

    }

    // This function toggles effects when distortion level <= 20
    void distortion20()
    {

    }

    // This function toggles effects when distortion level <= 40
    void distortion40()
    {

    }

    //This function toggles effects when distortion level <= 60
    void distortion60()
    {

    }

    //This function toggles effects when distortion level <= 80
    void distortion80()
    {

    }

    //This function toggles effects when sidtortion level == 100
    void distortion100()
    {

    }
}
