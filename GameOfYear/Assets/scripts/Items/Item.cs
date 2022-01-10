using UnityEngine;


[CreateAssetMenu(fileName = "new Item", menuName ="Inventory/item")]
public class Item : ScriptableObject
{
    new public string name = "new Item";
    public Sprite icon = null;
    public bool isDefault = false;
}
