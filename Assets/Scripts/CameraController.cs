using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform targetToFollow;
    public bool stopFollowingJump = false;
    public float followSpeed = 500.0f;
    private void FixedUpdate()
    {
        if (targetToFollow != null) //Target varsa çalýþýr
        {
            Vector3 newPosition = transform.position;

            float targetX = targetToFollow.position.x;
            newPosition.x = Mathf.Lerp(transform.position.x, targetX, followSpeed * Time.deltaTime); //Kameranýn x deðerini targetýn x'ine yakýnlaþtýrma

            if (stopFollowingJump) //Zýpladýðýndaki takip sistemi
            {
                newPosition.y = targetToFollow.position.y;
            }

            transform.position = newPosition;
        }
    }
}


