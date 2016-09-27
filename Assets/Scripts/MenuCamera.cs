using UnityEngine;

public class MenuCamera : MonoBehaviour
{

    [SerializeField]
    GameObject panels = null;

    bool need_position_update = false;
    Vector3 from = new Vector3();
    Vector3 to = new Vector3();
    float t = 0;

    RectTransform canvas_transform = null;

    void Awake()
    {
        canvas_transform = panels.GetComponent<RectTransform>();
    }

    void Update()
    {
        if (need_position_update)
        {
            t += 1f * Time.deltaTime;
            PositionUpdate();
            if (t >= 1)
            {
                t = 0;
                need_position_update = false;
            }
        }
    }

    void PositionUpdate()
    {
        canvas_transform.localPosition = Vector3.Lerp(from, to, t);
    }

    public void GoToPanelUp()
    {
        from = canvas_transform.localPosition;
        to.Set(from.x, from.y - canvas_transform.rect.height, from.z);
        need_position_update = true;
    }

    public void GoToPanelDown()
    {
        from = canvas_transform.localPosition;
        to.Set(from.x, from.y + canvas_transform.rect.height, from.z);
        need_position_update = true;
    }

    public void GoToPanelLeft()
    {
        from = canvas_transform.localPosition;
        to.Set(from.x + canvas_transform.rect.width, from.y, from.z);
        need_position_update = true;
    }

    public void GoToPanelRight()
    {
        from = canvas_transform.localPosition;
        to.Set(from.x - canvas_transform.rect.width, from.y, from.z);
        need_position_update = true;
    }
}
