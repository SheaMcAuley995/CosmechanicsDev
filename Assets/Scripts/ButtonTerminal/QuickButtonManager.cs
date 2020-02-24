using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickButtonManager : MonoBehaviour
{
    public ButtonCanvasView canvasView;
    [Space]
    public List<Image> images = new List<Image>();
    [Space]
    public List<Sprite> buttonSprites = new List<Sprite>();

    [SerializeField] string playerTag = "Char";


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(playerTag))
        {
            GenerateRandomSequence();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(playerTag))
        {
            canvasView.ToggleImages(false);
        }
    }

    void GenerateRandomSequence()
    {
        canvasView.ToggleImages(true);

        for (int i = 0; i < images.Count; i++)
        {
            int index = Random.Range(0, buttonSprites.Count);

            images[i].sprite = buttonSprites[index];
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag(playerTag))
        {
            
        }
    }
}
