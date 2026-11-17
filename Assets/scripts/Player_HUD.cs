using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Player_HUD : MonoBehaviour
{
    PanelRenderer panelRenderer;
    VisualTreeAsset visualTree;
    bool uiReady;
    private int uiVersion = 0;

    void Awake()
    {
        GetComponent<PanelRenderer>().RegisterUIReloadCallback(OnUIReload);
    }

    // Sets the state of the ui to false...
    void OnDestroy()
    {
        uiReady = false;
        if (GetComponent<PanelRenderer>() != null)
        {
            GetComponent<PanelRenderer>().UnregisterUIReloadCallback(OnUIReload);
        }
    }

    private void OnUIReload(PanelRenderer panel, VisualElement root, int version)
    {
        visualTree = GetComponent<VisualTreeAsset>();

        var ammo = root.Q<VisualElement>("Count");
        var health = root.Q<VisualElement>("HealthBar");
        if (uiVersion == version)
        {
            return;
        }

        uiVersion = version;
    }
}
