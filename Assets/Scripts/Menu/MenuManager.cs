﻿using UnityEngine;

public class MenuManager : MonoBehaviour
{

    private static MenuManager instance = null;
    public static MenuManager Instance
    {
        get
        {
            if (instance != null)
                return instance;
            instance = GameObject.Find("MenuManager").GetComponent<MenuManager>();
            return instance;
        }
    }

    public GameObject panels = null;
    public Camera cam = null;
    public GameObject[] cars = null;
    public GameObject[] tracks = null;

    void Start()
    {
        Animations anims = Animations.Instance;
        anims.changeObject(anims.GetRandomCar(), new Vector3(2.3f, -0.8f, 90f));
    }
}