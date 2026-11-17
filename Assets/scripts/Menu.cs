using UnityEngine;
using UnityEngine.UIElements;

public class NewEmptyCSharpScript : MonoBehaviour
{
    [SerializeField] private VisualTreeAsset menuUXML;
    private UIDocument uiDocument;
    private VisualElement rootElement;

    private void Start()
    {
        // Create a new UI Document
        uiDocument = new GameObject("UIDocument").AddComponent<UIDocument>();
        // Load the UXML file
        var visualTree = Resources.Load<VisualTreeAsset>("Menu");
        uiDocument.visualTreeAsset = visualTree;
        // Add the UI Document to the scene
        uiDocument.transform.SetParent(transform, false);
        // Get the root element
        rootElement = uiDocument.rootVisualElement;

        var startButton = rootElement.Q<Button>("Start");
        var exitButton = rootElement.Q<Button>("Exit");
    }

    private void OnStartButtonClicked()
    {
        // Handle start button click
        Debug.Log("Start button clicked!");
    }

    private void OnExitButtonClicked()
    {
        // Handle exit button click
        Debug.Log("Exit button clicked!");
        Application.Quit();
    }
}
