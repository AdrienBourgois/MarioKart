using UnityEngine;
using System.Collections;

public class BananaItem : BaseItem /*IThrowableItem*/ {

    [SerializeField]
    float rotation_speed;

    bool used = false; 

    void Start()
    {

    }
    
    // Update is called once per frame
    protected override void Update()
    {
        if (!is_active)
            base.Update();
    }

    public override void ActiveItem()
    {
        base.ActiveItem();
        Expire();
    }

    void FixedUpdate()
    {
        if (is_active)
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
        if (!used)
            if (is_active)
                if (collider.gameObject.tag == "AreaEffectKart")
                {
                    target = collider.transform.parent.gameObject;
                    StartActionTimer();
                    gameObject.GetComponent<Renderer>().enabled = false;
                    used = true;
                }
    }

    void Action()
    {
        //Debug.Log("action");
        target.GetComponent<CarController>().LostControl(rotation_speed);
    }
}
