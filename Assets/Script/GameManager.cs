using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager Instance = null; 

    private InputManager InputManager_ = null;

    private GameStateManager GameStateManager_ = null;
    private FocusedObjectManager FocusedObjectManager_ = null;


    void Awake()
    {
        if(Instance != null)
        {
            Destroy(this.gameObject);
            return;   
        }

        Instance = this;

        InputManager_ = InputManager.Instance();
        GameStateManager_ = GameStateManager.Instance();
        FocusedObjectManager_ = FocusedObjectManager.Instance();
        FocusedObjectManager_.Enable();

        DontDestroyOnLoad(this.gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        InputManager_.Update();
        GameStateManager_.Update();
    }
}
