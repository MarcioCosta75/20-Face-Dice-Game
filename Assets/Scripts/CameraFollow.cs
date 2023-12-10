using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // O alvo que a câmera deve seguir (o dado)
    public float smoothSpeed = 0.125f;
    public Vector3 offset; // Offset da posição da câmera em relação ao alvo
    public bool followDice = false; // Deve a câmera seguir o dado?

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

    // Método para iniciar o acompanhamento do dado
    public void StartFollowingDice()
    {
        followDice = true;
    }
}