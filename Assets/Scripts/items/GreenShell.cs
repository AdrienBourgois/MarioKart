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

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter");
    }

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("OnTriggerEnter");
    }
}
