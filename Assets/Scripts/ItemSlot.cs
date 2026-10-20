using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    // Item Data
    public string itemName;
    public int itemQuantity;
    public Sprite itemIcon;
    public bool isFull;

    // Item Slot
    [SerializeField] private TMP_Text quantityText;
    [SerializeField] private Image itemImage;
    [SerializeField] private int MaxStackSize = 99;

    // Interactive item Slot
    [SerializeField] public GameObject SelectedPanel;
    public bool isItemSelected;
    private InventoryManager inventoryManager;

    public void Awake()
    {
        inventoryManager = FindAnyObjectByType<InventoryManager>();
    }

    public void AddItem(itemDetails item)
    {
        itemName = item.ItemName;
        // itemQuantity = item.Quantity;
        itemIcon = item.ItemIcon;
        isFull = true;
        AddQuantity(item.Quantity);
    }

    public bool CanStackWith(string otherItemName)
    {
        return !isFull && itemName == otherItemName;
    }

    public void AddQuantity(int amount)
    {
        itemQuantity += amount;
        isFull = itemQuantity >= MaxStackSize;

        quantityText.text = itemQuantity.ToString();
        quantityText.enabled = true;
        itemImage.sprite = itemIcon;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            RightClick();
        }

        if (eventData.button == PointerEventData.InputButton.Left)
        {
            LeftClick();
        }
    }

    private void LeftClick()
    {
        Debug.Log("Left Click");
    }

    private void RightClick()
    {
        Debug.Log("Right Click");
    }
}
