using UnityEngine;
using UnityEngine.UI;
using TMPro;

public static class GraphicsHandler
{
    /// <summary>
    /// Fade methods forUI elements;
    /// </summary>
    //<param name="g"></param>

    public static void FadeIn(this TextMeshProUGUI g)
    {
        g.GetComponent<CanvasRenderer>().SetAlpha(0f);
        g.CrossFadeAlpha(1f, .15f, false);//second param is the time
    }
    public static void FadeOut(this TextMeshProUGUI g)
    {
        g.GetComponent<CanvasRenderer>().SetAlpha(1f);
        g.CrossFadeAlpha(0f, .15f, false);
    }
}