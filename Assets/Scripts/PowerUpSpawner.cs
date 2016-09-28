using UnityEngine;
using System.Collections;

public class PowerUpSpawner : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider collider)
    {
        //Debug.Log("Collision!!!" + collider.gameObject.name);
        if (collider.gameObject.tag == "AreaEffectKart")
        {
            GameObject kart = collider.transform.parent.gameObject;
            if (!kart.GetComponent<CarUserControl>().Has_Power_Up)
                ItemsMgr.Instance.AddItemToKart(kart);
        }

    }
}
