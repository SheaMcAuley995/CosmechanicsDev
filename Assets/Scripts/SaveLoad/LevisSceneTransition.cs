using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevisSceneTransition : MonoBehaviour
{
    public new LevisTransitionCamera camera;
    TextMeshProUGUI buttonText;

    LevelSelectImput inputActions;

    string sceneName;

    private void Awake()
    {
        inputActions = new LevelSelectImput();
    }

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

    private void OnEnable()
    {
        inputActions.MenuControls.Select.performed += Select_performed; ;
        inputActions.MenuControls.Select.Enable();
    }

    private void OnDisable()
    {
        inputActions.MenuControls.Select.performed -= Select_performed;
        inputActions.MenuControls.Select.Disable();
    }

    private void Select_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        //throw new System.NotImplementedException();
        if(camera.worldSelected)
        {
            ChangeScene();
        }

    }
}
