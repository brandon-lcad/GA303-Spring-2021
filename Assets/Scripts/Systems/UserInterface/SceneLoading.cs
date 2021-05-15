using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoading : MonoBehaviour
{
    public Image sceneLoading;
    // Start is called before the first frame update
    void Start()
    {
        sceneLoading.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        sceneLoading.fillAmount += 0.0005f;

        if (sceneLoading.fillAmount >= 0.990)
        {
            SceneManager.LoadSceneAsync(2);
        }
    }     
}
