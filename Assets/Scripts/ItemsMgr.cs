using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ItemsMgr : MonoBehaviour {


    static ItemsMgr instance = null;
    static public ItemsMgr Instance
    {
        get
        {
            if (instance != null)
                return instance;
            instance = GameObject.Find("ItemsMgr").GetComponent<ItemsMgr>();
            return instance;
        }
    }

    StarItem star;
    public StarItem Star
    {
        get { return star; }
    }

    List<GameObject> items_prefabs_list = new List<GameObject>();

    enum available_item { Star = 0}

    void Awake()
    {
        GameObject item_prefab = Resources.Load<GameObject>("Items/Prefabs/Star");
        items_prefabs_list.Add(item_prefab);
    }

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public void RegisterInput(BaseItem power_up)
    {
        InputMgr.Instance.LeftControlIsDown += power_up.ActiveItem;
    }

    public void UnregisterInput(BaseItem power_up)
    {
        InputMgr.Instance.LeftControlIsDown -= power_up.ActiveItem;
        
    }

    public void AddItemToKart(GameObject kart)
    {
        
        GameObject item = RandItemInstance();
        BaseItem power_up = item.GetComponent<BaseItem>();

        RegisterInput(power_up);
        CarsMgr.Instance.InscribeToPowerUpEvents(kart, power_up);
    }

    public GameObject RandItemInstance()
    {
        System.Random rand_range = new System.Random();
        int idx_item = rand_range.Next(0, items_prefabs_list.Count);
        GameObject item = Instantiate(items_prefabs_list[idx_item]);
        //Debug.Log("Rand inst = " + idx_item);
        return item;
    }
}
