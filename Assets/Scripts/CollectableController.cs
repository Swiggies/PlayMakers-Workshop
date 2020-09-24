using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableController : MonoBehaviour
{
    [SerializeField] private int score = 50;
    [SerializeField] private float bounceStrength = 0.1f;
    [SerializeField] private float bounceTime = 1;
    [SerializeField] private float rotationSpeed = 0.25f;

    private Vector3 initPosition;

    private void Start()
    {
        initPosition = transform.position;
    }

    public void Update()
    {
        float sine = Mathf.Sin(Time.time * bounceTime);
        transform.position = initPosition + new Vector3(0, sine * bounceStrength, 0);
        transform.Rotate(Vector3.forward * rotationSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ServiceLocator.Current.Get<ScoreManager>().AddScore(score);
            Destroy(gameObject);
        }
    }
}
