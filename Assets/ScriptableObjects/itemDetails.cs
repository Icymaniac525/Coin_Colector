using UnityEngine;

[CreateAssetMenu(fileName = "itemDetails", menuName = "Scriptable Objects/itemDetails")]
public class itemDetails : ScriptableObject
{
    [SerializeField] private string itemName;
    [SerializeField] private int quantity;
    [SerializeField] private Sprite itemIcon;

    public string ItemName => itemName;
    public int Quantity => quantity;
    public Sprite ItemIcon => itemIcon;
    
}
