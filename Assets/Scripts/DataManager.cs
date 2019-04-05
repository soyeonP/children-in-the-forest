using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour {
    private static DataManager _dataManager = null;

    /* 오브젝트 아이템 리스트 */
    private List<Dictionary<string, object>> itemList;
    public List<Item> items;
    public Sprite[] sprites;
    public Sprite defaultImg;


    public static DataManager dataManager
    {
        get
        {
            if (_dataManager == null)
            {
                _dataManager = FindObjectOfType(typeof(DataManager)) as DataManager;

                if (_dataManager == null)
                {
                    Debug.Log("DataManager 없어요");
                }
            }

            return _dataManager;
        }
    }

    public List<Item> GetItems()
    {
        return items;
    }

    public int isGot(string id)
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i]["ID"].ToString() == id)
            {
                return System.Convert.ToInt32(itemList[i]["isGot"].ToString());
            }
        }

        return 0;
    }

    private void Awake()
    {
        /* 오브젝트 아이템 리스트 로드 */
        itemList = CSVReader.Read("Data/itemList");
        sprites = Resources.LoadAll<Sprite>("Objects");
        items = new List<Item>();

        for (int i = 0; i < 3; i++)
        {
            Item item = new Item();
            item.name = itemList[i]["name"].ToString();
            item.ID = itemList[i]["ID"].ToString();
            item.effect = itemList[i]["effect"].ToString();
            item.tool = itemList[i]["tool"].ToString();
            item.sprite = findSprite(item.ID);

            items.Add(item);
        }
        /* 오브젝트 아이템 리스트 로드 끝 */
    }

    public void GotItem(string id)
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i]["ID"].ToString() == id)
            {
                itemList[i]["isGot"] = 1;
                return;
            }
        }
    }

    public Sprite findSprite(string name)
    {
        if (sprites == null)
        {
            sprites = Resources.LoadAll<Sprite>("Objects");
        }

        foreach (Sprite spr in sprites)
        {
            if (spr.name == name)
            {
                return spr;
            }
        }

        return defaultImg;
    }

    public float GetHP(string ID)
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i]["ID"].ToString() == ID)
            {
                return System.Convert.ToSingle(itemList[i]["hp"].ToString());
            }
        }

        return -1;
    }

    public float GetFull(string ID)
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i]["ID"].ToString() == ID)
            {
                return System.Convert.ToSingle(itemList[i]["full"].ToString());
            }
        }

        return -1;
    }
}
