using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ExampleGameController : MonoBehaviour
{
    public static ExampleGameController instance = null;
    
    //public Material[] materials;
    public int numberOfPlayers;
    public CameraMultiTarget cameraMultiTarget;
    public GameObject playerPrefab;
    private int currentPlayerId = 0;
    [HideInInspector] public Vector3[] spawnPoints;
    public List<string> spawnableScenes;

    [HideInInspector] public Material[] colorOptions = new Material[4];
    [HideInInspector] public GameObject[] headOptions = new GameObject[4];

    private void Awake()
    {
        if(GameStateManager.instance == null)
        {
            GameObject gameStateManager = new GameObject();
            gameStateManager.name = "GameStateManager";
            gameStateManager.AddComponent<GameStateManager>();
        }

       // DontDestroyOnLoad(this.gameObject);
        if(instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            //Destroy(gameObject);
        }

        LoadAssets();
    }

    /// <summary> 
    /// The following code eliminates the need for color & head options to be set in the 
    /// inspector of each level. 
    /// </summary>
    void LoadAssets()
    {
        // Load the head options from the Assets folder
        headOptions[0] = Resources.Load<GameObject>("HeadOptions/Rig_Blank_Blobfish 1");
        headOptions[1] = Resources.Load<GameObject>("HeadOptions/Rig_Blank_Fennec 1");
        headOptions[2] = Resources.Load<GameObject>("HeadOptions/Rig_Blank_Helmet 1");
        headOptions[3] = Resources.Load<GameObject>("HeadOptions/Rig_Blank_UncleBob 1");

        // Load the color options from the Assets folder
        colorOptions[0] = Resources.Load<Material>("ColorOptions/PlayerMat_Cyan 1");
        colorOptions[1] = Resources.Load<Material>("ColorOptions/PlayerMat_Magenta 1");
        colorOptions[2] = Resources.Load<Material>("ColorOptions/PlayerMat_Orange 1");
        colorOptions[3] = Resources.Load<Material>("ColorOptions/PlayerMat_White 1");
    }

    private void Start()
    {
        InitializeGameStart();
    }


    private void InitializeGameStart()
    {
            if (true)
            {
                setSpawnPoints();
                /// ZACH REMOVAL
                //var targets = new List<GameObject>(numberOfPlayers);

                //for (int i = 0; i < numberOfPlayers; i++)
                //{
                //    targets.Add(addPlayer());
                //    cameraMultiTarget.SetTargets(targets.ToArray());
                //}

            }

        /// ZACH REMOVAL
        //SceneManager.activeSceneChanged += MakePlayers;
        SceneManager.activeSceneChanged += cameraCheck;
        PlayerSpawn spawner = new PlayerSpawn(spawnPoints, cameraMultiTarget); /// ZACH ADDITION
        //if(PlayerSpawner.)
    }

     private void cameraCheck(Scene current, Scene next)
     {
         if (Camera.main.GetComponent<CameraMultiTarget>() != null)
         {
             cameraMultiTarget = Camera.main.GetComponent<CameraMultiTarget>();
         }
    
     }
    
     private void MakePlayers(Scene current, Scene next) {
    
         string currentName = current.name;
    
         if (currentName == null)
         {
             currentName = "Replaced";
         }
    
         Debug.Log("Scenes: " + currentName + ", " + next.name);
    
        // foreach(string scene in spawnableScenes)
        // {
        //     if(currentName == scene)
        //     {
        //        /// ZACH REMOVAL
        //         //var targets = new List<GameObject>(numberOfPlayers);
        //         //Debug.Log(currentName + " works as a scene");
        //         //for (int i = 0; i < numberOfPlayers; i++)
        //         //{
        //
        //         //    targets.Add(addPlayer());
        //         //    cameraMultiTarget.SetTargets(targets.ToArray());
        //         //}
        //     }
        // }
     }

    public void setSpawnPoints()
    {
        spawnPoints = new Vector3[numberOfPlayers];

         //spawnPoints[0] = transform.position;
         for (int i = 0; i < numberOfPlayers; i++)
         {
             spawnPoints[i] = transform.position + new Vector3(i + 1, 0, 0);
         }
    }


    public GameObject addPlayer()
    {
        GameObject target = GameObject.Instantiate(playerPrefab, spawnPoints[0], Quaternion.identity);
        cameraMultiTarget = Camera.main.GetComponent<CameraMultiTarget>();
        //target.GetComponent<MeshRenderer>().material = materials[currentPlayerId];
        target.GetComponent<Player>().playerId = currentPlayerId;
        target.GetComponent<Player>().cameraTrans = cameraMultiTarget.GetComponent<Camera>().transform;
        currentPlayerId++;
        return target;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        for(int i = 0; i < numberOfPlayers; i++ )
        {
            Gizmos.DrawSphere(transform.position + new Vector3(i + 1, 0, 0), 0.5f);
        }
        
        
    }

}