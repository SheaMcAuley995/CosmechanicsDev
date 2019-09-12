using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class JumpToHyperSpace : MonoBehaviour
{
    [Header("Camera Variables")]
    public GameObject mainCam;
    [SerializeField] Vector3 camStartPos;
    [SerializeField] Vector3 camEndPos;

    public PostProcessVolume volume;
    public AnimationCurve effectCurve;
    public AnimationCurve fadeBackCurve;
    Bloom bloomLayer = null;
    LensDistortion lensLayer = null;
    DepthOfField depthLayer = null;

    [Header("Post Process Variables")]
    [SerializeField] float bloomStartVal = 0.5f;
    [SerializeField] float bloomEndVal = 50f;
    [SerializeField] float lensDistStartVal = 0f;
    [SerializeField] float lensDistEndVal = -100f;
    [SerializeField] float depthStartVal = 50f;
    [SerializeField] float depthEndVal = 300f;

    [Header("Effect Settings")]
    [SerializeField] float effectDurationTime = 3f;
    [SerializeField] float effectFadeTime = 0.5f;


    void Start()
    {
        if (volume == null)
        {
            volume = FindObjectOfType<PostProcessVolume>();
        }
        if (mainCam == null)
        {
            mainCam = Camera.main.gameObject;
        }

        volume.profile.TryGetSettings(out bloomLayer);
        volume.profile.TryGetSettings(out lensLayer);
        volume.profile.TryGetSettings(out depthLayer);

        camStartPos = mainCam.transform.position;
        camEndPos = new Vector3(camStartPos.x + 35f, camStartPos.y, camStartPos.z);
    }

    // This is for testing please remove when done testing thanks
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(HyperspaceJump());
        }
    }

    public IEnumerator HyperspaceJump()
    {
        bloomLayer.enabled.value = true;
        lensLayer.enabled.value = true;
        depthLayer.enabled.value = true;

        bloomLayer.intensity.value = bloomStartVal;
        lensLayer.intensity.value = lensDistStartVal;
        depthLayer.focalLength.value = depthStartVal;

        float t = 0f;

        while (t < effectDurationTime)
        {
            float interpolation = effectCurve.Evaluate(t);
            bloomLayer.intensity.value = Mathf.Lerp(bloomStartVal, bloomEndVal, interpolation);
            lensLayer.intensity.value = Mathf.Lerp(lensDistStartVal, lensDistEndVal, interpolation);
            depthLayer.focalLength.value = Mathf.Lerp(depthStartVal, depthEndVal, interpolation);

            t += Time.unscaledDeltaTime;

            yield return 0;
        }
        mainCam.GetComponent<CameraMultiTarget>().enabled = false;

        StartCoroutine(ReverseEffect());
        yield break;
    }

    IEnumerator ReverseEffect()
    {
        float t = 0f;

        while (t < effectFadeTime)
        {
            float interpolation = fadeBackCurve.Evaluate(t);
            bloomLayer.intensity.value = Mathf.Lerp(bloomEndVal, bloomStartVal, interpolation);
            lensLayer.intensity.value = Mathf.Lerp(lensDistEndVal, lensDistStartVal, interpolation);
            depthLayer.focalLength.value = Mathf.Lerp(depthEndVal, depthStartVal, interpolation);

            mainCam.transform.position = Vector3.Lerp(camStartPos, camEndPos, interpolation);

            t += Time.unscaledDeltaTime;

            yield return 0;
        }

        Engine.instance.engineHeat = 2f;
        bloomLayer.intensity.value = bloomStartVal;
        lensLayer.intensity.value = lensDistStartVal;
        depthLayer.focalLength.value = depthStartVal;
        yield break;
    }
}
