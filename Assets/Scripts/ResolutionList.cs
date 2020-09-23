using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ResolutionList : MonoBehaviour
{
    Resolution[] resolutions;

    [SerializeField]
    int rows;

    float width;
    float height;

    public TextMeshProUGUI prefab;
    TextMeshProUGUI text;

    public ScrollRect scrollRect;
    RectTransform contentPanel;

    private void Start()
    {
        contentPanel = this.GetComponent<RectTransform>();

        resolutions = Screen.resolutions;

        RectTransform myRect = GetComponent<RectTransform>();

        int curResIndx = 0;


        rows = resolutions.Length;

        height = 50;
        width = 100;

        GridLayoutGroup grid = this.GetComponent<GridLayoutGroup>();
        grid.cellSize = new Vector2(width, height);


        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = $" {resolutions[i].width} x {resolutions[i].height}";
            //options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
               resolutions[i].height == Screen.currentResolution.height)
            {
                curResIndx = i;
            }
            text = (TextMeshProUGUI)Instantiate(prefab);
            text.transform.SetParent(transform, false);
            text.text = option;

            if (i == 0)
            {
                text.GetComponent<Button>().Select();
            }
        }

        
    }

    public void SetResolution(int resIndx)
    {
        Resolution resolution = resolutions[resIndx];

        Screen.SetResolution(resolution.width, resolution.height, true);
    }

}
