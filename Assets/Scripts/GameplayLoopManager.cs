using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameplayLoopManager : MonoBehaviour
{

    public static GameplayLoopManager instance;


    public delegate void NextTickEvent();
    public static event NextTickEvent onNextTickEvent;


    public static float TimeBetweenEvents { get; private set; }

    [Header("Event System")]
    [SerializeField] private float timeBetweenEvents;

    // TODO: Have pipes in scene add to a ship integrity value 
    [Header("Ship Statistics")]
    public int shipCurrenHealth;
    public int shipMaxHealth;

    [Header("Ship Blast Attributes")]
    [SerializeField] GameObject blastEffectPrefab;
    [SerializeField] float explosionRadius;
    [SerializeField] public int explosionDamage;
    [SerializeField] LayerMask interactableLayerMask;
    [Space]
    [SerializeField] Vector3[] possibleAttackPositions;

    [HideInInspector] public Vector3 attackLocation;
    Vector3 lastHitLocaton;
    [HideInInspector] public bool gotHit;

    [Header("UI Elements")]
    public GameObject[] HealthBars;
    public GameObject loseGameScreen;



    private void Start()
    {
        TimeBetweenEvents = timeBetweenEvents;

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        shipCurrenHealth = shipMaxHealth;

        StartCoroutine("eventSystem");
        AdjustUI();
    }

    IEnumerator eventSystem()
    {
        while (true)
        {
            yield return new WaitForSeconds(TimeBetweenEvents);
            onNextTickEvent();
            StartCoroutine("shipBlast");
        }
    }

    IEnumerator shipBlast()
    {

        if (attackLocation != null)
        {
            while (attackLocation == lastHitLocaton)
            {
                attackLocation = possibleAttackPositions[Random.Range(0, possibleAttackPositions.Length)];
            }
        }
        else
        {
            attackLocation = possibleAttackPositions[Random.Range(0, possibleAttackPositions.Length)];
        }

        lastHitLocaton = attackLocation;
        gotHit = true;                          //michael add
        yield return new WaitForSeconds(.5f);     //delay in travel time of laser

        GameObject newBlast = Instantiate(blastEffectPrefab, attackLocation, Quaternion.identity);

        Collider[] damagedObjects = Physics.OverlapSphere(attackLocation, explosionRadius, interactableLayerMask);

        foreach (Collider damagedObject in damagedObjects)
        {
            IDamageable<int> caughtObject = damagedObject.GetComponent<IDamageable<int>>();
            shipCurrenHealth -= explosionDamage;
            if (caughtObject != null) caughtObject.TakeDamage(1);
        }

        AudioEventManager.instance.PlaySound("bang", .8f, Random.Range(.2f, 1f), 0);
        AdjustUI();

        if (shipCurrenHealth <= 0)
        {
            LoseGame();
        }

        yield return new WaitForSeconds(1.5f);

        Destroy(newBlast);

        yield return null;
    }

    void AdjustUI()
    {
        for (int i = 0; i < HealthBars.Length; i++)
        {
            if(shipCurrenHealth >= i)
            {
                HealthBars[i].SetActive(true);
            }
            else
            {
                HealthBars[i].SetActive(false);
            }

            
        }
    }

    void LoseGame()
    {
        // TODO: Make UI prettier and animate
        loseGameScreen.SetActive(true);
        GameStateManager.instance.SetGameState(GameState.LostByDamage);
        //Time.timeScale = Mathf.Lerp(1f, 0.2f, 2f);
    }

    private void OnDrawGizmosSelected()
    {
        foreach (Vector3 attackPosition in possibleAttackPositions)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPosition, explosionRadius);
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(attackPosition, 0.5f);

            Collider[] damagedObjects = Physics.OverlapSphere(attackPosition, explosionRadius, interactableLayerMask);

            foreach (Collider damagedObject in damagedObjects)
            {

                if (Gizmos.color == Color.red) { Gizmos.color = Color.red; } else { Gizmos.color = Color.blue; }
                Gizmos.color = Color.red;
                Gizmos.DrawWireCube(damagedObject.transform.position, new Vector3(0.8f, 0.8f, 0.8f));
                // MeshRenderer caughtObject = damagedObject.GetComponent<MeshRenderer>();
                 //caughtObject.material.color = Color.red;
            }

        }
    }
}

