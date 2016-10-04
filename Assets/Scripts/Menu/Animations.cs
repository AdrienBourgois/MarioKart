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

    MenuManager menu_mgr = null;

    enum EObject_To_Display { Cars, Tracks, Selection, Any };
    EObject_To_Display current_state = EObject_To_Display.Cars;
    enum EDisplay_State { In, Out, Rotate, Next };
    [SerializeField]
    EDisplay_State current_display = EDisplay_State.Rotate;
    [SerializeField]
    float time_between_objects = 10f;
    float before_next_object = 0f;
    GameObject current_animated_object = null;

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

    void Update ()
    {
        if (current_animated_object)
        {
            if (current_display == EDisplay_State.Rotate)
            {
                current_animated_object.transform.Rotate(new Vector3(0, 45 * Time.deltaTime, 0), Space.Self);
            }
            else if (current_display == EDisplay_State.In)
            {
                Renderer[] object_renderer = current_animated_object.GetComponentsInChildren<Renderer>();
                foreach (Renderer renderer in object_renderer)
                {
                    Color object_color = renderer.material.color;
                    if (object_color.a < 1)
                    {
                        object_color.a = Mathf.Lerp(object_color.a, object_color.a + 0.5f, Time.deltaTime);
                        renderer.material.color = object_color;
                    }
                    else
                    {
                        current_display = EDisplay_State.Rotate;
                    }
                }
            }
            else if (current_display == EDisplay_State.Out)
            {
                Renderer[] object_renderer = current_animated_object.GetComponentsInChildren<Renderer>();
                foreach (Renderer renderer in object_renderer)
                {
                    Color object_color = renderer.material.color;
                    if (object_color.a > 0)
                    {
                        object_color.a = Mathf.Lerp(object_color.a, object_color.a - 0.5f, Time.deltaTime);
                        renderer.material.color = object_color;
                    }
                    else
                    {
                        current_display = EDisplay_State.Next;
                    }
                }
            }
        }
        else if (current_display == EDisplay_State.Next)
        { 
            changeObject(GetRandomCar(), new Vector3(2.3f, -0.8f, 90f));
        }
    }

    public void changeObject(GameObject obj, Vector3 position)
    {
        if(current_animated_object)
            DestroyObject(current_animated_object);
        current_animated_object = Instantiate(obj);
        current_animated_object.transform.SetParent(menu_mgr.cam.transform);
        current_animated_object.transform.Rotate(new Vector3(25, 0, 0), Space.Self);
        current_animated_object.transform.position = position;
    }
}
