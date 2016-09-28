using UnityEngine;
using System;
using System.Collections;

public abstract class BaseItem : MonoBehaviour {

    [SerializeField]
    protected string item_name;
    [SerializeField]
    protected bool is_active;
    [SerializeField]
    protected float time_action;

    //bool expired = false;
    public delegate void ItemEventHandler(float args1);
    public event ItemEventHandler improve_speed;

    public delegate void StatusEventHandler();
    public event StatusEventHandler expired;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	protected virtual void Update () {
	    
	}

    public virtual void ActiveItem()
    {
        is_active = true;
    }
    
    protected void OnImproveSpeed(float value)
    {
        if (improve_speed != null)
            improve_speed(value);
    }

    protected void Expire()
    {
        ItemsMgr.Instance.UnregisterInput(this);
        expired();
        Destroy(this);
    }
    
}
