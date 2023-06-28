using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;

    //Kamera Inertia
    [SerializeField] private float distanceAhead;
    [SerializeField] private float cameraSpeed;
    private float lookAhead;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);

        //Kamera Inertia

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x + lookAhead, transform.position.y, transform.position.z);

        //Kamera inertia
        // Lerp untuk gerakan perlahan / gradually changed
        lookAhead = Mathf.Lerp(lookAhead, (-distanceAhead * player.localScale.x), Time.deltaTime * cameraSpeed);
    }
}
