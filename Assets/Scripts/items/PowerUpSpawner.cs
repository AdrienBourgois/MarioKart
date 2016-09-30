using UnityEngine;
using System.Collections;

public class PowerUpSpawner : MonoBehaviour {

    [SerializeField]
     float rotation_speed;
    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        
        transform.Rotate(new Vector3(0f, 1f, 0f) * Time.deltaTime * rotation_speed, Space.Self);
        //Debug.Log("rotation = " + transform.rotation);
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
