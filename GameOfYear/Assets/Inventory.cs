using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
   
    #region Sigleton
    public static Inventory instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("There is already an existing inventory instance");
            return;
        }
        instance = this;
    }

    #endregion
    public int spaces = 20;
    public List<Item> items = new List<Item>();


    public bool Add(Item item)
    {   
        if (!item.isDefault)
        {
            if (items.Count >= spaces)
            {
                Debug.Log("Not enough space");
                return false;
            }
            items.Add(item);
        }
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
    }

}
