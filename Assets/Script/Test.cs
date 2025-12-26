using UnityEngine;

public class Test : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Transparent3D.instance.isTabOff)
        {
            transform.rotation = Quaternion.Euler(0, 150, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 300, 0);
        }
    }
}
