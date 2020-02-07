using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevisSceneTransition : MonoBehaviour
{
    public new LevisTransitionCamera camera;
    TextMeshProUGUI buttonText;
    
    string sceneName;

    private void Start()
    {
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        sceneName = camera.target.name;
        buttonText.text = "Load " + sceneName;
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
