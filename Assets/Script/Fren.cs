using UnityEngine;

public class Fren : MonoBehaviour
{
    private bool isResting;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleGameStates(GameManager.GameState state)
    {
        if (state == GameManager.GameState.Working)
        {
            isResting = false;
            Debug.Log(isResting);
        }
        else
        {
            isResting = true;
            Debug.Log(isResting);
        }
    }
}
