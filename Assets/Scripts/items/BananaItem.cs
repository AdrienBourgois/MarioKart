using UnityEngine;
using System.Collections;

public class BananaItem : BaseItem, IThrowableItem {

    [SerializeField]
    float rotation_speed;

    bool used = false; 

    void Start()
    {

    }

    // Update is called once per frame
    protected override void Update()
    {
        if (!is_throwed)
            base.Update();
    }

    public void Throw()
    {
        is_throwed = true;
    }

    public override void ActiveItem()
    {
        base.ActiveItem();
        Throw();
        Expire();
    }

    void FixedUpdate()
    {
        if (is_throwed)
        {
            if (target != null)
            {
                if (!IsActionTimeExpired())
                    Action();
                else
                    Destroy(this.gameObject);
            }

        }
    }

    void OnTriggerEnter(Collider collider)
    {
        //Debug.Log("yooo");
        if (!used)
            if (is_throwed)
                if (collider.gameObject.tag == "AreaEffectKart")
                {
                    target = collider.transform.parent.gameObject;
                    StartActionTimer();
                    gameObject.GetComponent<Renderer>().enabled = false;
                    //gameObject.GetComponent<Collider>().isTrigger = false;
                    used = true;
                }
    }

    void Action()
    {
        //Debug.Log("action");
        target.GetComponent<CarController>().LostControl(rotation_speed);
    }
}
