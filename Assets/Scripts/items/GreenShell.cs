using UnityEngine;
using System.Collections;

public class GreenShell : BaseItem, IThrowableItem {

    [SerializeField]
    float speed;
    [SerializeField]
    float rotation_speed;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	protected override void Update () {

        if (!is_active)
            base.Update();
    }

   

    public override void ActiveItem()
    {
        base.ActiveItem();
        StartTimer();
        Expire();
    }

    void FixedUpdate()
    {
        if (is_active)
        {
            MoveStraightforward(speed);
            CheckWallsCollisions();
            CheckKartCollisions();
            if (target != null)
                if (!IsActionTimeExpired())
                    KartCollisionAction();
                else
                    Destroy(this.gameObject);
            if (IsTimeExpired() == true)
                Destroy(this.gameObject);
            
        }
    }
    
    void CheckWallsCollisions(float coll_idx = 1)
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, fwd, out hit, 4))
        {
            //Debug.Log("hit.collider.tag = " + hit.collider.tag);
            if (hit.collider.tag == "Wall")
            {
                float angle = 45;
                if (coll_idx > 2)
                    angle = 170;
                //Debug.Log("Hit Wall");
                transform.Rotate(new Vector3(0f, angle, 0f), Space.Self);
                //Debug.Log("new rotation = " + transform.rotation);
                CheckWallsCollisions(coll_idx += 1);
            }
        }  //else if (hit.collider)
    }

    void CheckKartCollisions()
    {
        if (target == null)
        {
            RaycastHit hit;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);
            if (Physics.Raycast(transform.position, fwd, out hit, 4))
            {
                if (hit.collider.tag == "AreaEffectKart")
                {
                    Debug.Log("kart collision");
                    target = hit.collider.transform.parent.gameObject;
                    StartActionTimer();
                    gameObject.GetComponent<Renderer>().enabled = false;
                }
            }  //else if (hit.collider)
        }
    }

    public void MoveTo(Transform target, float speed)
    {

    }

    public void MoveStraightforward(float speed)
    {
        transform.Translate(new Vector3(0f, 0f, 1f), Space.Self);
    }

    void KartCollisionAction()
    {
        target.GetComponent<CarController>().LostControl(rotation_speed);
    }
}
