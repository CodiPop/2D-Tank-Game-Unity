using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    private float move,moveSpeed, rotation, rotationSpeed;
    public tracks TrackL;
    public tracks TrackR;
    public float speed;
    bool movefoward;
    bool movereverse;

    // Start is called before the first frame update
    void Start()
    {

        moveSpeed = 5f;
        rotationSpeed = 100f;
    }

    // Update is called once per frame
    void Update()
    {

        move = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        rotation = Input.GetAxis("Horizontal") * -  rotationSpeed * Time.deltaTime;
        TrackL.animator.SetBool("isMoving", Mathf.Abs(move + rotation) > 0);
        TrackR.animator.SetBool("isMoving", Mathf.Abs(move + rotation) > 0);

    }

    void trackStart()
    {
        TrackL.animator.SetBool("isMoving", true);
        TrackR.animator.SetBool("isMoving", true);
    }

    void trackStop()
    {
        TrackL.animator.SetBool("isMoving", false);
        TrackR.animator.SetBool("isMoving", false);
    }
    private void LateUpdate()
    {
        transform.Translate(0f, move, 0f);
        transform.Rotate(0f, 0f, rotation);
    }


}
