using UnityEngine;
using System.Collections;

public class CarsMgr : MonoBehaviour {

    static CarsMgr instance = null;
    static public CarsMgr Instance
    {
        get
        {
            if (instance != null)
                return instance;
            instance = GameObject.FindGameObjectWithTag("CarsMgr").GetComponent<CarsMgr>();
            return instance;
        }
    }

    GameObject player_car;

    void Awake()
    {
        player_car = GameObject.Find("TattooineCar");
        if (player_car == null)
            Debug.Log("player_car = null");
        else
            Debug.Log("player car != null");
    }

    // Use this for initialization
    void Start () {
        InscribeToPowerUpEvents();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void InscribeToPowerUpEvents(/*GameObject car*/)
    {
        CarUserControl car_control = player_car.GetComponent<CarUserControl>();
        ItemsMgr.Instance.Star.improve_speed += car_control.ImproveAccelleration;
    }
}
