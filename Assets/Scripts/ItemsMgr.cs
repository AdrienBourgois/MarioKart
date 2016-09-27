using UnityEngine;
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
            instance = GameObject.FindGameObjectWithTag("ItemsMgr").GetComponent<ItemsMgr>();
            return instance;
        }
    }

    StarItem star;
    public StarItem Star
    {
        get { return star; }
    }

    List<BaseItem> items_list;

    enum available_item { Star = 0}

    void Awake()
    {
        star = GameObject.Find("Star").GetComponent<StarItem>();
        if (star == null)
            Debug.Log("NULL STAR");
        else
            Debug.Log("Star != null");
    }

    // Use this for initialization
    void Start () {
        RegisterInput();
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public void RegisterInput()
    {
        InputMgr.Instance.LeftControlIsDown += star.ActiveItem;
    }
}
