using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingRod : MonoBehaviour
{
    [SerializeField] float speedModifier = 0.012f;

    Touch touch;
    Vector2 movement;

    void Start()
    {

    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        float clampedY = Mathf.Clamp(transform.position.y, -1f, 5f);
        float clampedX = Mathf.Clamp(transform.position.x, -1f, 4f);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);

        //TouchControl/MobileInput
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(
                    transform.position.x + touch.deltaPosition.x * speedModifier,
                    transform.position.y + touch.deltaPosition.y * speedModifier,
                    transform.position.z);
            }
        }
    }
}
