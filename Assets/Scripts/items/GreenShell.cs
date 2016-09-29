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
        if (Physics.Raycast(transform.position, fwd, out hit, 3))
            if (hit.collider.tag == "Wall")
            {
                Debug.Log("Hit Wall");
                //Quaternion rotation = transform.rotation;
                //rotation.x += 90;
                //transform.rotation = rotation;
                transform.Rotate(new Vector3(0f, 45f * i, 0f), Space.Self);
                Debug.Log("new rotation = " + transform.rotation);
                CheckWallsCollisions(++i);
            }
    }
}
