using UnityEditor;
using UnityEditor.Build.Pipeline.Interfaces;
using UnityEditor.SceneManagement;
using UnityEditor.SettingsManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

[RequireComponent(typeof(PanelRenderer))]
public class Menu : MonoBehaviour
{
    VisualElement root;
    PanelRenderer panelRenderer;
    bool uiReady;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnEnable()
    {
        panelRenderer = GetComponent<PanelRenderer>();
        if (panelRenderer != null)
        {
            panelRenderer.RegisterUIReloadCallback(OnUIReload);
        }
    }

    private void OnDisable()
    {
        uiReady = false;
        if (panelRenderer != null)
        {
            panelRenderer.UnregisterUIReloadCallback(OnUIReload);
        }
    }

    private void Update()
    {
        if (uiReady)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }

    private void OnUIReload(PanelRenderer panelRenderer, VisualElement rootElement)
    {
        root = rootElement;

        var game_Start = root.Q<VisualElement>("Start");
        var game_Exit = root.Q<VisualElement>("Exit");

        game_Start.RegisterCallback<ClickEvent>(OnGameStart_Clicked);
        game_Exit.RegisterCallback<ClickEvent>(OnGameExit_Clicked);

        uiReady = true;
    }

    private void OnGameStart_Clicked(ClickEvent evt)
    {
        Debug.Log("Start Pressed");
        SceneManager.LoadSceneAsync("Warehouse-Interior");
        SceneManager.UnloadSceneAsync("Menu");
    }

    private void OnGameExit_Clicked(ClickEvent evt)
    {
        QuitGame();
    }

    private void QuitGame()
    {
        Debug.Log("Game Terminated");
        Application.Quit();
    }
}
