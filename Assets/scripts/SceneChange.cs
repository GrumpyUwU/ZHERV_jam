using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    public string targetSceneName;

    void Start()
    {
        // Attach the button's onClick listener
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(ChangeScene);
        }
        else
        {
            Debug.LogError("Button component not found.");
        }
    }

     void ChangeScene()
    {
        // Change the scene based on the specified scene name
        SceneManager.LoadScene(targetSceneName);
    }
}
