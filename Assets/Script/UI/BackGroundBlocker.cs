using UnityEngine;

public class BackGroundBlocker : MonoBehaviour
{
    BoxCollider boxCollider;
    [SerializeField] RectTransform canvasRect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        boxCollider.size = new Vector3(canvasRect.rect.width, canvasRect.rect.height, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
