using UnityEngine;
using System;
using System.Collections;

public abstract class BaseItem : MonoBehaviour {

    [SerializeField]
    public string item_name;
    [SerializeField]
    protected bool is_active;
    [SerializeField]
    protected float life_time;



    protected float expire_time;
    protected Transform frontal_spawn;
    protected Transform rear_spawn;
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
        frontal_spawn = null;
        rear_spawn = null;
        target = null;
        is_throwed = false;
    }

    public void Init(Transform new_frontal_spawn, Transform new_rear_spawn, Transform new_target)
    {
        frontal_spawn = new_frontal_spawn;
        rear_spawn = new_rear_spawn;
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
            Vector3 pos = frontal_spawn.position;
            //pos.y += 5;
            transform.position = pos;//idle_pos.position;
            //Debug.Log("PowerUp pos =" + transform.position);
            Quaternion rotation = frontal_spawn.rotation;
            rotation.x = 0;
            rotation.z = 0;
            transform.rotation = rotation;
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
        //Destroy(this);
    }

    protected void MoveTo(Transform target, float speed)
    {
        if (target == null)
            MoveStraightforward(speed);
    }

    protected void MoveStraightforward(float speed)
    {
        transform.Translate(new Vector3(0f, 0f, 1.0f) * Time.deltaTime * speed, Space.Self);
    }

    protected void StartTimer()
    {
        expire_time = Time.time + life_time;
    }

    protected bool IsTimeExpired()
    {
        if (Time.time > expire_time)
            return true;
        return false;
    }
}
