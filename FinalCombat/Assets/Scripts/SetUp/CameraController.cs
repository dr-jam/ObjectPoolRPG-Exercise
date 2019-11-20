using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject Target;
    [SerializeField] private Vector2 MaxPosition;
    [SerializeField] private Vector2 MinPosition;
    private Camera ManagedCamera;

    private void Awake()
    {
        this.ManagedCamera = this.gameObject.GetComponent<Camera>();
    }
    // Start is called before the first frame update
    void Start()
    {
        this.ManagedCamera.transform.position = new Vector3(this.Target.transform.position.x, this.Target.transform.position.x, this.ManagedCamera.transform.position.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var targetPosition = this.Target.transform.position;
        targetPosition.x = Mathf.Clamp(targetPosition.x,MinPosition.x, MaxPosition.x);
        targetPosition.y = Mathf.Clamp(targetPosition.y, MinPosition.y, MaxPosition.y);
        var cameraPosition = this.ManagedCamera.transform.position;
        this.ManagedCamera.transform.position = new Vector3(targetPosition.x, targetPosition.y, cameraPosition.z);
    }
}
