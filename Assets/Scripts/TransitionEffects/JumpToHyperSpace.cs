using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class JumpToHyperSpace : MonoBehaviour
{
    [Header("Camera Setup")]
    public GameObject mainCam;
    [SerializeField] Vector3 camStartPos;
    [SerializeField] Vector3 camEndPos;

    [Header("Win UI Setup")]
    public Animator winScreenAnimator;
    public ScoreDisplay scoreDisplay;

    [Header("Post Process Setup")]
    public PostProcessVolume volume;
    public AnimationCurve effectCurve;
    public AnimationCurve fadeBackCurve;
    Bloom bloomLayer = null;
    LensDistortion lensLayer = null;
    DepthOfField depthLayer = null;

    [Header("Post Process Settings")]
    [SerializeField] float bloomStartVal = 0.5f;
    [SerializeField] float bloomEndVal = 50f;
    [SerializeField] float lensDistStartVal = 0f;
    [SerializeField] float lensDistEndVal = -100f;
    [SerializeField] float depthStartVal = 50f;
    [SerializeField] float depthEndVal = 300f;

    [Header("Effect Duration Settings")]
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

        // I HAVE NO INTENTION OF KEEPING THIS! 
        // Our ships aren't all facing the same direction (from an axis standpoint OR right vs. left).
        // This makes the jump to hyperspace look weird when the camera jumps to the right (on the x axis) in level 2,
        // but jumps upward on levels 1 & 3 because they're aligned on the z axis, or when the ship appears to jump backwards
        // in the tutorial because it's facing the opposite direction. This is my quick fix. When we have more consistently
        // aligned levels I will remove this switch statement and just have the one camEndPos possibility (and it won't be hardcoded).
        // Thank you for your understanding during this trying time.
        //switch (SceneManager.GetActiveScene().name)
        //{
        //    case "Ship_Level_Tutorial NEW":
        //        camEndPos = new Vector3(camStartPos.x + 35f, camStartPos.y, camStartPos.z);
        //        break;
        //    case "Ship_Level_1Final":
        //        camEndPos = new Vector3(camStartPos.x, camStartPos.y, camStartPos.z + 35f);
        //        break;
        //    case "BetaMichaelTest":
        //        camEndPos = new Vector3(camStartPos.x + 35f, camStartPos.y, camStartPos.z);
        //        break;
        //    case "Ship_Level_3":
        //        camEndPos = new Vector3(camStartPos.x, camStartPos.y, camStartPos.z + 35f);
        //        break;
        //}

        camEndPos = new Vector3(camStartPos.x, camStartPos.y, camStartPos.z + 35f);
    }

    // This is for testing please remove when done testing thanks
    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        StartCoroutine(HyperspaceJump());
    //    }
    //}

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

        if (Engine.instance != null)
        {
            Engine.instance.engineHeat = 2f;
        }
        bloomLayer.intensity.value = bloomStartVal;
        lensLayer.intensity.value = lensDistStartVal;
        depthLayer.focalLength.value = depthStartVal;

        StartCoroutine(RevealWinScreen());

        yield break;
    }

    IEnumerator RevealWinScreen()
    {
        yield return new WaitForSeconds(1f);

        winScreenAnimator.transform.parent.gameObject.SetActive(true);
        winScreenAnimator.SetTrigger("Win");

        yield return new WaitForSeconds(2f);

        StartCoroutine(scoreDisplay.FillCogs());

        yield break;
    }
}
