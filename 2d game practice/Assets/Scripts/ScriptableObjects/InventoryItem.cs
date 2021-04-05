using UnityEngine;



[CreateAssetMenu(menuName = "Scriptable Objects/Inventory Item", fileName = "New Inventory Item")]
public class InventoryItem : ScriptableObject
{

    public string itemName;
    public string itemDescription;
    public Sprite itemSprite;
    public int numberHeld;
    public bool isUsable;
    public bool isUnique;

}
