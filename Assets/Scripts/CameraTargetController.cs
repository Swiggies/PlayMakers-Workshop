using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTargetController : MonoBehaviour
{

    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private Vector3 offset;
    
    private Transform player;

    private void Awake()
    {

        // Variables on any Service should be SET in Awake()
        ServiceLocator.Current.Get<PlayerManager>().CameraTarget = gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Variables on any service should GET in Start()
        player = ServiceLocator.Current.Get<PlayerManager>().Player.transform;
        transform.SetParent(null);
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.eulerAngles += new Vector3(-mouseY * rotationSpeed, mouseX * rotationSpeed, 0);
    }

    private void LateUpdate()
    {
        transform.position = player.position + offset;
    }
}
