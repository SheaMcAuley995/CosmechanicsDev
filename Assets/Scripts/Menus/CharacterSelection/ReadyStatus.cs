using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class ReadyStatus : MonoBehaviour
{
    public static ReadyStatus instance;

    public string levelSelect;
    public Text countdownText;
    Coroutine countdown;

    [SerializeField] float time = 5f;
    bool countingDown;

    CharSelectController[] players;
    [HideInInspector] public int playersReady = 0;


    #region Singleton
    void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
    #endregion

    void Start()
    {
        countdownText.enabled = false;
    }

    public void CheckIfAllPlayersReady()
    {
        players = FindObjectsOfType<CharSelectController>();

        if (playersReady == players.Length && players.Length != 0)
        {
            StartCountdown();
        }
        else
        {
            StopCountdown();
        }
    }

    void StartCountdown()
    {
        time = 4f;
        countingDown = true;
        countdown = StartCoroutine(CountdownToGame());
    }

    void StopCountdown()
    {
        countingDown = false;
        countdown = null;
        countdownText.enabled = false;
    }

    IEnumerator CountdownToGame()
    {
        countdownText.enabled = true;

        while (countingDown)
        {
            if (time > 0f)
            {
                time -= 1f;
                countdownText.text = "Starting Game In: " + Mathf.RoundToInt(time).ToString();

                yield return new WaitForSeconds(1f);
            }
            else
            {
                ContinueToGame();
                break;
            }
        }
    }

    void ContinueToGame()
    {
        for (int i = 0; i < players.Length; i++)
        {
            DontDestroyOnLoad(players[i]);

            Animator[] animators = players[i].GetComponentsInChildren<Animator>();
            for (int j = 0; j < animators.Length; j++)
            {
                animators[j].Play("CharSelect Idle", -1, 0.8f);
                animators[j].SetBool("CharSelect", false);
            }

            players[i].GetComponent<PlayerController>().enabled = true;
            Destroy(players[i].GetComponent<CharSelectController>());
            Destroy(players[i].GetComponent<PlayerInput>());
        }

        SceneFader.instance.FadeTo(levelSelect);
    }
}
