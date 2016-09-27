using UnityEngine;

public class CarCam : MonoBehaviour
{
    Transform carCam;
    [SerializeField]
    Transform car;
    Rigidbody carPhysics;
    public Vector3 offset;

    public float rotationThreshold = 1f;
    public float cameraStickiness = 10.0f;
    public float cameraRotationSpeed = 5.0f;

    void Awake()
    {
        carPhysics = car.GetComponent<Rigidbody>();
    }

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Quaternion look;

        look = Quaternion.LookRotation(car.forward * 0.2f);
        Vector3 rotation = car.transform.localEulerAngles;
        rotation.x = 30;
        look.eulerAngles = rotation;

        transform.rotation = Quaternion.Slerp(transform.rotation, look, cameraRotationSpeed * Time.fixedDeltaTime);

        Vector3 pos = transform.localPosition;

        pos += new Vector3(-4f, 2f, 0);
        //pos.y += 2f;
        transform.position = Vector3.Lerp(pos, car.position, cameraStickiness * Time.fixedDeltaTime);
    }
}