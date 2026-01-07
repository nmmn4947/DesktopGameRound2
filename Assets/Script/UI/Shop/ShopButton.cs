using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    [SerializeField] private ShopItem itemData;
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI costText;

    [SerializeField] private Sprite lockedIcon;
    public void SetLockIconSprite(Sprite sprite){ lockedIcon = sprite; }

    // Update is called once per frame
    void Update()
    {
        if (!itemData.isUnlockedInShop)
        {
            image.sprite = lockedIcon;
            costText.gameObject.SetActive(true);
        }
        else
        {
            image.sprite = itemData.shopIcon;
            costText.gameObject.SetActive(false);
        }
        costText.text = itemData.cost.ToString();
    }
}
