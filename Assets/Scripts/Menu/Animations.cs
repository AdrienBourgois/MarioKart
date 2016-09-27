using UnityEngine;

public class Animations : MonoBehaviour {

    private static Animations instance = null;
    public static Animations Instance
    {
        get
        {
            if (instance != null)
                return instance;
            instance = GameObject.Find("Animations").GetComponent<Animations>();
            return instance;
        }
    }

    GameObject current_animated_object = null;

    MenuManager menu_mgr = null;

    void Awake()
    {
        menu_mgr = GameObject.Find("MenuManager").GetComponent<MenuManager>();
    }

    public GameObject GetRandomTrack()
    {
        int id = Random.Range(0, menu_mgr.tracks.Length - 1);
        return menu_mgr.tracks[id];
    }
    public GameObject GetRandomCar()
    {
        int id = Random.Range(0, menu_mgr.cars.Length - 1);
        return menu_mgr.cars[id];
    }

    void Update () {
        if(current_animated_object)
            current_animated_object.transform.Rotate(new Vector3(0, 45 * Time.deltaTime, 0), Space.Self);
    }

    public void changeObject(GameObject obj, Vector3 position)
    {
        if(current_animated_object)
            DestroyObject(current_animated_object, 2f);
        current_animated_object = Instantiate(obj);
        current_animated_object.transform.SetParent(menu_mgr.cam.transform);
        current_animated_object.transform.Rotate(new Vector3(25, 145, 0), Space.Self);
        current_animated_object.transform.position = position;
    }
}
