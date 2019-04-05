using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour {

    public Item item;
    public Text text; 
    public Sprite DefaultImg;
    public Sprite apple;

    public Image ItemImg;
    private bool isSlot = false;

    private int childNum;

    public void SetChildNum(int num) { childNum = num; }
    public Item ItemReturn() { return this.item; }
    public bool isSlots() { return isSlot; } // 차있으면 true
    public void SetSlots(bool isSlot) { this.isSlot = isSlot; } // isSlot -> 비면 false

    public void AddItem(Item item)
    {
        this.item = item;
        UpdateInfo(true, item.sprite);
    }

    public void emptyItem()
    {
        if (!isSlot)
        {
            return;
        }
        this.item = null;

        UpdateInfo(false, DefaultImg);
        return;
    }

    public void UpdateInfo(bool isSlot, Sprite sprite)
    {
        SetSlots(isSlot);
        ItemImg.sprite = sprite;

        if (item != null && DataManager.dataManager.isGot(item.ID) == 0) 
        {
            ItemImg.color = Color.black;
        }
        else if (item == null)
        {
            ItemImg.color = Color.white;
        }

        ItemIO.SaveData();
    }

    public void ShowInfo()
    {
        ObjManager.objManager.inventory.RenewInfo(this);

        if (DataManager.dataManager.isGot(item.ID) == 0)
        {
            ItemImg.color = Color.black;
        }
    }

    public void CheckItem() // 아이템 조사 시
    {
        DataManager.dataManager.GotItem(item.ID);
        ObjManager.objManager.inventory.RenewInfo(this);
        ItemImg.color = Color.white;

        ObjManager.objManager.inventory.RenewInventory();
    }

    public void UseItem() // 아이템 사용 시
    {
        /* 아이템 사용효과 적용 */
        PlayerState character = GameObject.FindGameObjectWithTag("Characters")
            .transform.GetChild(childNum).GetComponent<PlayerState>();
        DataManager dm = DataManager.dataManager;
        character.ChangeFull(dm.GetFull(item.ID));
        character.ChangeHP(dm.GetHP(item.ID));

        /* 아이템 비우고 인벤토리 새로고침 */
        DataManager.dataManager.GotItem(item.ID);
        emptyItem();
        ObjManager.objManager.inventory.RenewInfo();
        ObjManager.objManager.inventory.RenewInventory();
    }

    public void ThrowItem() // 아이템 버릴 시
    {
        emptyItem();
        ObjManager.objManager.inventory.RenewInfo();
        ObjManager.objManager.inventory.RenewInventory();
    }

    public void CheckGotItem()
    {
        if (item != null)
        {
            if (DataManager.dataManager.isGot(item.ID) == 1)
                ItemImg.color = Color.white;
            else ItemImg.color = Color.black;
        }
    }
}
