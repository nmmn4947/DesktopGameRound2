using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleTools(Animator animator)
    {
        animator.SetBool("isOpen", !animator.GetBool("isOpen"));
    }

    public void OpenSetting()
    {
        settingsPanel.SetActive(true);
    }
    
    public void CloseSetting()
    {
        settingsPanel.SetActive(false);
    }
}
