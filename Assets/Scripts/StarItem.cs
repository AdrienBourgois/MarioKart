using UnityEngine;
using System.Collections;

public class StarItem : BaseItem, IPowerUpItem {

    

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	protected override void Update () {
        
        
    }

    public void AddBenefit()
    {
        float improve_speed = 5;
        OnImproveSpeed(improve_speed);
    }

    public override void ActiveItem()
    {
        base.ActiveItem();
        AddBenefit();
        ItemsMgr.Instance.UnregisterInput(this);
    }
}
