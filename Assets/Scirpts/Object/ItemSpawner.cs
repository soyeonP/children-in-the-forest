using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {

    private List<Item> items;
    public Sprite defaultImg;

    public GameObject objPrefab;
    public GameObject objParent;

    private DataManager dm;

    private void Start()
    {
        dm = DataManager.dataManager;
        items = dm.GetItems();


        for (int i = 0; i < 10; i++)
        {
            Item item = items[Random.Range(0, items.Count)];

            GameObject obj = Instantiate(objPrefab, objParent.transform);
            Item itemCompo = obj.GetComponent<Item>();

            itemCompo.name = item.name;
            itemCompo.ID = item.ID;
            itemCompo.des = item.des;
            itemCompo.tool = item.tool;
            itemCompo.sprite = item.sprite;
            itemCompo.type = item.type;
            itemCompo.effect = item.effect;

            /* 오브젝트 생성 - 테스트용으로 화면 안에서만 */
            obj.transform.position = new Vector2(Random.Range(-Camera.main.orthographicSize, Camera.main.orthographicSize),
                Random.Range(-Camera.main.aspect, Camera.main.aspect));
            obj.GetComponent<SpriteRenderer>().sprite = item.sprite;

        }
    }

}
