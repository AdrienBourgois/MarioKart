using UnityEngine;

public class CarCam : MonoBehaviour
{
    private Transform camParent;
    public Transform car;

    [SerializeField]
    private float cameraStickiness = 10.0f;
    [SerializeField]
    private float cameraRotationSpeed = 5.0f;

    void Awake()
    {
        camParent = GetComponent<Transform>();
    }

    void Start()
    {
        camParent.parent = null;
    }

    void FixedUpdate()
    {
        Quaternion look;

        camParent.position = Vector3.Lerp(camParent.position, car.position, cameraStickiness * Time.fixedDeltaTime);

        look = Quaternion.LookRotation(car.forward);
        look = Quaternion.Slerp(camParent.rotation, look, cameraRotationSpeed * Time.fixedDeltaTime);
        camParent.rotation = look;
    }
}