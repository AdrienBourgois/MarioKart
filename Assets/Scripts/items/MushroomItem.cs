using UnityEngine;
using System.Collections;

public class MushroomItem : BaseItem, IPowerUpItem {
    [SerializeField]
    float boost_speed;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	protected override void Update () {
	
	}

    public void AddBenefit()
    {
        OnImproveSpeed(boost_speed);
    }

    public override void ActiveItem()
    {
        base.ActiveItem();
        AddBenefit();
        Expire();
        Destroy(this.gameObject);
    }
}
