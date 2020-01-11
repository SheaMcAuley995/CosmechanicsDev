using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CharSelectController : MonoBehaviour
{
    Vector2 menuInput;

    enum CharacterStatus { NOT_READY, READY };
    CharacterStatus status;

    [Header("Selection Pool")]
    public GameObject[] heads;
    int headIndex;
    int colorIndex;

    [Space]    

    [SerializeField] Image[] locatorSprites;

    GameObject newHead;
    Vector3 headPos;
    Renderer[] childRenderers;
    Animator animator;

    bool selecting = false;

    GameObject standLocation;


    void Start()
    {
        headIndex = Random.Range(0, heads.Length);
        colorIndex = Random.Range(0, ColorManager.instance.availableColors.Count);
        animator = GetComponent<Animator>();
        locatorSprites = GetComponentsInChildren<Image>();

        AssignHead();
        AssignColor();

        standLocation = GameObject.FindGameObjectWithTag("Respawn");
        transform.position = standLocation.transform.position;
        standLocation.gameObject.tag = "Untagged";
    }

    void Update()
    {
        DetectInput();
    }

    void DetectInput()
    {
        Vector3 input = new Vector3(menuInput.x, menuInput.y, 0f);

        // If stick moves left, a selecting isn't currently being made, and the character is not marked as ready
        if (menuInput.x < 0f && !selecting && status == CharacterStatus.NOT_READY)
        {
            PreviousHead();
        }

        // If stick moves right, a selecting isn't currently being made, and the character is not marked as ready
        if (menuInput.x > 0f && !selecting && status == CharacterStatus.NOT_READY)
        {
            NextHead();
        }
    }

    void AssignHead()
    {
        newHead = GetComponentInChildren<Head>().gameObject;
        headPos = newHead.transform.position;
        Destroy(newHead.gameObject);

        newHead = Instantiate(heads[headIndex], headPos, Quaternion.Inverse(transform.rotation), transform);
        animator.SetBool("CharSelect", true);
        animator.Play("CharSelect Idle", -1, 0);
        newHead.GetComponent<Animator>().SetBool("CharSelect", true);
        newHead.GetComponent<Animator>().Play("CharSelect Idle", -1, 0);
    }

    void NextHead()
    {
        selecting = true;
        StartCoroutine(DelayForNextSelection());

        if (headIndex >= heads.Length - 1)
        {
            headIndex = 0;
        }
        else
        {
            headIndex++;
        }

        AssignHead();
    }

    void PreviousHead()
    {
        selecting = true;
        StartCoroutine(DelayForNextSelection());

        if (headIndex <= 0)
        {
            headIndex = heads.Length - 1;
        }
        else
        {
            headIndex--;
        }

        AssignHead();
    }

    void AssignColor()
    {
        childRenderers = GetComponentsInChildren<Renderer>();
        foreach (Renderer child in childRenderers)
        {
            if (child.gameObject.layer != 16)
            {
                child.material = ColorManager.instance.availableColors[colorIndex];
            }
        }

        locatorSprites = GetComponentsInChildren<Image>();
        foreach (Image locator in locatorSprites)
        {
            Color emissColor = ColorManager.instance.availableColors[colorIndex].GetColor("_EmissionColor");
            locator.color = emissColor;
        }

        for (int i = 0; i < ColorManager.instance.takenColors.Count; i++)
        {
            if (ColorManager.instance.takenColors[i] == null)
            {
                ColorManager.instance.takenColors[i] = ColorManager.instance.availableColors[colorIndex];
                break;
            }
        }

        ColorManager.instance.availableColors.RemoveAt(colorIndex);
    }

    IEnumerator DelayForNextSelection()
    {
        yield return new WaitForSeconds(0.2f);
        selecting = false;
        yield return null;
    }

    void OnSwapHead(InputValue value)
    {
        menuInput = value.Get<Vector2>();
    }

    void OnReadyUp()
    {
        Debug.Log("Player ready!");
        status = CharacterStatus.READY;
        ReadyStatus.instance.playersReady++;
        ReadyStatus.instance.CheckIfAllPlayersReady();
    }

    void OnUnReady()
    {
        Debug.Log("Player not ready!");
        status = CharacterStatus.NOT_READY;
        ReadyStatus.instance.playersReady--;
        ReadyStatus.instance.CheckIfAllPlayersReady();
    }

    void OnGoBack()
    {
        Debug.LogError("Zach hasn't implementing going back to the main menu yet");
    }
}
