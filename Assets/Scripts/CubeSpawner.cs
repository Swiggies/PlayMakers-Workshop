using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{

    [SerializeField] private float secondsToSpawn = 3;

    // Need this variable just for keeping track of the time
    private float timeLeft;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine("SpawnCubeCoroutine");    
    }

    private void Update()
    {
        // This is how a timer should be donw
        // This is done in the MAIN LOOP of the game so that it can easily be paused/stopped when the objects is disabled/destroyed

        // timeLeft should have ~1 added to it every second
        // Update is called once per frame and Time.deltaTime is the time between the current and the last frame
        // If the game is running at 60 fps that means 60 frames of deltaTime will be equal to ~1
        timeLeft += Time.deltaTime;
        if (timeLeft > secondsToSpawn)
        {
            SpawnCube();

            // Needs to be reset once the timer has finished.
            timeLeft = 0;
        }
    }

    // Function for spawning cubes
    void SpawnCube()
    {
        var cube = GameObject.Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube), transform.position, Quaternion.identity);
        cube.AddComponent<Rigidbody>();
    }

    // Wrong way to spawn something over time
    IEnumerator SpawnCubeCoroutine()
    {
        yield return new WaitForSeconds(secondsToSpawn);
        SpawnCube();

        StartCoroutine("SpawnCubeCoroutine");
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, 0.5f);
    }
}
