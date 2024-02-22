using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform targetToFollow;
    public bool stopFollowingJump = false;
    public float followSpeed = 500.0f;
    private void FixedUpdate()
    {
        if (targetToFollow != null) //Target varsa �al���r
        {
            Vector3 newPosition = transform.position;

            float targetX = targetToFollow.position.x;
            newPosition.x = Mathf.Lerp(transform.position.x, targetX, followSpeed * Time.deltaTime); //Kameran�n x de�erini target�n x'ine yak�nla�t�rma

            if (stopFollowingJump) //Z�plad���ndaki takip sistemi
            {
                newPosition.y = targetToFollow.position.y;
            }

            transform.position = newPosition;
        }
    }
}


