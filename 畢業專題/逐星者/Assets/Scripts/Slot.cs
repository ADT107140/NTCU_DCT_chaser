using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    //public int slotId;//空格id等於物品id
    public item slotItem;
    public Image slotImage;
    public Text slotNum;
    public Text slotInfo;

    //public GameObject itemInSlot;
    //public void ItemOnClicked()  //slot被案
    //{
    //    //inventoryManager.UpdateitemInfo(slotInfo);
    //}
    //public void  setupSlot(item item)
    //{
    //    if(item == null)
    //    {
    //        itemInSlot.SetActive(false);
    //        return;
    //    }

    //    slotImage.sprite = item.itemImage;
    //    slotNum.text = item.itemHeld.ToString();
    //    slotInfo.text = item.itemInfo;

    //}

}
