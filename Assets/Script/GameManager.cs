using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager Instance = null; 

    private InputManager inputManager = null;

    private GameStateManager gameStateManager = null;

    void Awake()
    {
        if(Instance != null)
        {
            Destroy(this.gameObject);
            return;   
        }

        Instance = this;

        inputManager = InputManager.Instance();
        gameStateManager = GameStateManager.Instance();

        DontDestroyOnLoad(this.gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        inputManager.Update();
        gameStateManager.Update();
    }
}
