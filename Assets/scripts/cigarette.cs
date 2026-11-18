using TMPro;
using UnityEngine;

public class cigarette : MonoBehaviour
{
    private float cigTime = 10f;
    private int ciggs = 2;
    public TextMeshProUGUI ciggHud;
    void Start()
    {
        
    }

    
    void Update()
    {
        textHud();

        if (cigTime > 0)
        {
            oneData.needCig = false;
            cigTime -= Time.deltaTime;
        }
        else
        {
            oneData.needCig = true;
        }
        Debug.Log(oneData.needCig);
        if (oneData.cigScore >= 20)
        {
            ciggs += oneData.cigScore / 20;
            oneData.cigScore = oneData.cigScore % 20;
            Debug.Log(ciggs);
            Debug.Log(oneData.cigScore);
        }

        if (Input.GetKeyDown(KeyCode.Space) && ciggs > 0)
        {
            ciggs--;
            cigTime = 10f;
            
        }
    }
    public void textHud()
    {
        ciggHud.text = "ciggarettes: " + ciggs.ToString();
    }
}
