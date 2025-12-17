using System;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public enum GameState
    {
        Tutorial,
        Working,
        Resting
    }
    
    [HideInInspector]
    public GameState currentGameState;
    
    [SerializeField] private UnityEvent<GameState> ChangeGameState;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }

        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SelectState(GameState.Working);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectState(GameState gameState)
    {
        ChangeGameState.Invoke(gameState);
        currentGameState = gameState;
    }
}
