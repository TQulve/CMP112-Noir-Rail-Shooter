using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class cameraVingette : MonoBehaviour
{
    PostProcessVolume m_Volume;
    Vignette m_Vignette;

    void Update()
    {
        //vingette vars
        m_Vignette = ScriptableObject.CreateInstance<Vignette>();

        m_Vignette.enabled.Override(true);

        


        //create a vingette
        m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, m_Vignette);


        if (oneData.needCig == true)
        {
            // if you need a cigarette then set vingette intensity to 0.7
            m_Vignette.intensity.Override(0.7f);
        }

        else
        {
            // if you're alright set it to 0
            m_Vignette.intensity.Override(0f);

        }
    }

}
