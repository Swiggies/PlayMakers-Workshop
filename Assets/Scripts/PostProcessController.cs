using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessController : MonoBehaviour
{
    [SerializeField] private PostProcessProfile profile;

    private Bloom bloom;

    // Start is called before the first frame update
    void Start()
    {
        profile.TryGetSettings<Bloom>(out bloom);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
            bloom.intensity.value += Time.deltaTime;
    }
}
