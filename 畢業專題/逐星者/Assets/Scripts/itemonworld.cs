using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemonworld : MonoBehaviour
{
    public item thisitem;
    public inventory playerinventory;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AddNewItem();
            Destroy(gameObject);
        }
    }
    public void AddNewItem()
    {
        if (!playerinventory.itemlist.Contains(thisitem))
        {
            Debug.Log("1");
            playerinventory.itemlist.Add(thisitem);
            //   inventoryManager.CreateNewItem(thisitem);
            //for(int i = 0;i < playerinventory.itemlist.Count;i++)
            //{
            //    Debug.Log("2ok");
            //    if(playerinventory.itemlist[i] == null)
            //    {
            //        Debug.Log("3ok");
            //        playerinventory.itemlist[i] = thisitem;
            //        thisitem.itemHeld += 1;
            //        Debug.Log("4ok");
            //        break;
            //    }

            //}
        }
        else
        {
            thisitem.itemHeld += 1;
            Debug.Log("5ok");
        }
        inventoryManager.RefreshItem();
    }
}
