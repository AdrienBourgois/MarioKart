using UnityEngine;
using System.Collections;

public class GreenShell : BaseItem, IThrowableItem {

    [SerializeField]
    float speed;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	protected override void Update () {

        if (is_throwed)
            base.MoveTo(null, speed);
        else
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
    }

    void FixedUpdate()
    {
        if (is_throwed)
        {
            CheckWallsCollisions();
        }
    }



    void CheckWallsCollisions(float i = 1)
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, fwd, out hit, 4))
            if (hit.collider.tag == "Wall")
            {
                float angle = 45;
                if (i > 2)
                    angle = 170;
                Debug.Log("Hit Wall");
                transform.Rotate(new Vector3(0f, angle, 0f), Space.Self);
                Debug.Log("new rotation = " + transform.rotation);
                CheckWallsCollisions(i += 1);
            }
    }
}
