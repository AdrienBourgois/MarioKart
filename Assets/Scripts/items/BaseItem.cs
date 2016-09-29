using UnityEngine;
using System;
using System.Collections;

public abstract class BaseItem : MonoBehaviour {

    [SerializeField]
    public string item_name;
    [SerializeField]
    protected bool is_active;
    [SerializeField]
    protected float time_action;

    protected Transform idle_pos;
    protected Transform target;
    protected bool is_throwed;

    //bool expired = false;
    public delegate void ItemEventHandler(float args1);
    public event ItemEventHandler improve_speed;

    public delegate void StatusEventHandler(BaseItem sender);
    public event StatusEventHandler expired;

    void Awake()
    {
        is_active = false;
        idle_pos = null;
        target = null;
        is_throwed = false;
    }

    public void Init(Transform new_idle_pos, Transform new_target)
    {
        idle_pos = new_idle_pos;
        target = new_target;
    }

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	protected virtual void Update () { 
        if (!is_active)
        {
            //Debug.Log("Idle_pos = " + idle_pos.position);
            Vector3 pos = idle_pos.position;
            //pos.y += 5;
            transform.position = pos;//idle_pos.position;
            //Debug.Log("PowerUp pos =" + transform.position);
            transform.rotation = idle_pos.rotation;
        }

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
        expired(this);
        Destroy(this);
    }

    protected void MoveTo(Transform target, float speed)
    {
        if (target == null)
            MoveStraightforward(speed);
    }

    protected void MoveStraightforward(float speed)
    {
        Vector3 position = transform.position;
        position.x += Time.deltaTime * speed;
        transform.position = position;
    }
}
