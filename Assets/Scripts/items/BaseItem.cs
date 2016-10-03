using UnityEngine;
using System;
using System.Collections;

public abstract class BaseItem : MonoBehaviour {

    [SerializeField]
    public string item_name;
    [SerializeField]
    protected float life_time;
    [SerializeField]
    protected float action_time;

    protected bool is_active;
    protected float expire_action_time;
    protected float expire_life_time;
    protected Transform frontal_spawn;
    protected Transform rear_spawn;
    protected Transform actual_spawn;
    protected GameObject target;
    protected GameObject sender;
    

    public GameObject Target { get { return target; } set { target = value; } }


    //bool expired = false;
    public delegate void ItemEventHandler(float args1);
    public event ItemEventHandler improve_speed;
    //public event ItemEventHandler lost_control;

    public delegate void StatusEventHandler(BaseItem sender);
    public event StatusEventHandler expired;

    void Awake()
    {
        is_active = false;
        frontal_spawn = null;
        rear_spawn = null;
        target = null;
       
    }

    public void Init(Transform new_frontal_spawn, Transform new_rear_spawn, GameObject new_target)
    {
        frontal_spawn = new_frontal_spawn;
        rear_spawn = new_rear_spawn;
        actual_spawn = rear_spawn;
        target = new_target;
        //sender = new_sender;
    }

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	protected virtual void Update () { 

            //Debug.Log("Idle_pos = " + idle_pos.position);
            Vector3 pos = actual_spawn.position;
            //pos.y += 5;
            transform.position = pos;
            //Debug.Log("PowerUp pos =" + transform.position);
            Quaternion rotation = actual_spawn.rotation;
            rotation.x = 0;
            rotation.z = 0;
            transform.rotation = rotation;
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
    }

    protected void StartTimer()
    {
        expire_life_time = Time.time + life_time;
    }

    protected bool IsTimeExpired()
    {
        if (Time.time > expire_life_time)
            return true;
        return false;
    }

    protected void StartActionTimer()
    {
        expire_action_time = Time.time + action_time;
    }

    protected bool IsActionTimeExpired()
    {
        if (Time.time > expire_action_time)
            return true;
        return false;
    }

    public void ActiveFrontalSpawn()
    {
        actual_spawn = frontal_spawn;
    }

    public void ActiveRearSpawn()
    {
        actual_spawn = rear_spawn;
    }
}
