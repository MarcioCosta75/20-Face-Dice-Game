using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // O alvo que a c�mera deve seguir (o dado)
    public float smoothSpeed = 0.125f;
    public Vector3 offset; // Offset da posi��o da c�mera em rela��o ao alvo
    public bool followDice = false; // Deve a c�mera seguir o dado?

    void LateUpdate()
    {
        if (followDice)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            transform.LookAt(target);
        }
    }

    // M�todo para iniciar o acompanhamento do dado
    public void StartFollowingDice()
    {
        followDice = true;
    }
}