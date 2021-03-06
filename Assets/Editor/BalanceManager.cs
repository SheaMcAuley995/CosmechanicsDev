﻿using UnityEngine;
using UnityEditor;

public class BalanceManager : EditorWindow 
    {

    [Header("Ship Engine")]
    [SerializeField] Engine engine;
    [SerializeField] [Tooltip("This is the speed at which the engine will cool down.")] [Range(0.1f,10)] float coolingSpeed;
    [SerializeField] [Tooltip("Percentage of engine that is cooled when florp is inserted.")] [Range(0.1f, 1)] float florpPower = 0.3f;
    [SerializeField] [Tooltip("How fast the ship progression bar will move.")] [Range(0.1f, 2)] float ProgressionMultiplier = 0.4f;
    [Header("Ship Health")]
    [SerializeField] ShipHealth shipHealth;
    [SerializeField] [Tooltip("Time between the blasts. Or the time between the events that will cause damage to the ship")] float TimeBetweenEvents;
    
    [Header("PlayerInfo")]
    [SerializeField] ExampleGameController gameController;
    [SerializeField] Grid grid;
    
    Color color;
    
    public void Awake()
    {
        engine = FindObjectOfType<Engine>();
        shipHealth = FindObjectOfType<ShipHealth>();
        grid = FindObjectOfType<Grid>();
        
    }
    
    [MenuItem("Window/Balance Window")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<BalanceManager>("BalanceWindow");
    }
    private void OnGUI()
    {

        GUILayout.Label("Balance Manager", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        EditorGUILayout.HelpBox("Hover over the text of any item to get a brief description. Make sure to reset connections after debugging.", MessageType.Info);
        GUILayout.Label("Engine Scipt edits", EditorStyles.boldLabel);
        engine.engineCoolingAmount  = EditorGUILayout.Slider(new GUIContent("Cooling Speed", "This is the speed at which the engine will cool down."), engine.engineCoolingAmount, 0.1f, 10);
        engine.florpCoolingPercentage = EditorGUILayout.Slider(new GUIContent("Florp Power", "Percentage of engine that is cooled when florp is inserted."), engine.florpCoolingPercentage, 0.1f, 1);
        engine.progressionMultiplier = EditorGUILayout.Slider(new GUIContent("Progression Multiplier", "How fast the ship progression bar will move."), engine.progressionMultiplier, 0.1f, 2);
        engine.enemyProgressionMultiplier = EditorGUILayout.Slider(new GUIContent("Enemy Progression Multiplier", "How fast the enemy ship progression bar will move."), engine.enemyProgressionMultiplier, 0.1f, 2);

        GUILayout.Label("Ship Health Scipt edits", EditorStyles.boldLabel);
        shipHealth.timeBetweenNEvents = EditorGUILayout.Slider(new GUIContent("Time Between Events", "Time between the blasts. Or the time between the events that will cause damage to the ship."), shipHealth.timeBetweenNEvents, 0.1f, 15);
        shipHealth.timeBeforeEventsStart = EditorGUILayout.Slider(new GUIContent("Time Before Event Starts", "Time between the blasts. Or the time between the events that will cause damage to the ship."), shipHealth.timeBeforeEventsStart, 0.1f, 15);
        GUILayout.Label("Fire Scipt edits", EditorStyles.boldLabel);
        grid.fireStartPercentage = EditorGUILayout.Slider(new GUIContent("Fire Start Percentage", "Time between the blasts. Or the time between the events that will cause damage to the ship."), grid.fireStartPercentage, 1, 100);
        grid.fireTimer = EditorGUILayout.Slider(new GUIContent("Fire Spread timer", "Time between the blasts. Or the time between the events that will cause damage to the ship."), grid.fireTimer, 0.1f, 15);
        GUILayout.Space(25);
        if (GUILayout.Button("RESET CONNECTIONS"))
        {
            engine = FindObjectOfType<Engine>();
            shipHealth = FindObjectOfType<ShipHealth>();
            grid = FindObjectOfType<Grid>();
        }
    }

}
