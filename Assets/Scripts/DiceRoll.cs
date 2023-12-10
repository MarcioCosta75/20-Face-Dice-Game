using UnityEngine;

public class DiceRoll : MonoBehaviour
{
    private Rigidbody rb;
    public float torqueForce = 500f; // Força de torque para a rotação
    public float launchForce = 300f; // Força de lançamento
    public Camera mainCamera; // Referência à câmera principal

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ResetDice(); // Configura o dado para o estado inicial
    }

    public void RollDice()
    {
        rb.useGravity = true;
        rb.angularVelocity = Vector3.zero;
        rb.velocity = Vector3.zero;

        Vector3 launchDirection = mainCamera.transform.forward + new Vector3(Random.Range(-0.1f, 0.1f), 0, Random.Range(-0.1f, 0.1f));
        rb.AddForce(launchDirection.normalized * launchForce);
        rb.AddTorque(Random.onUnitSphere * torqueForce);

        mainCamera.GetComponent<CameraFollow>().StartFollowingDice();
    }

    public void ResetDice()
    {
        rb.useGravity = false;
        rb.angularVelocity = Vector3.zero;
        rb.velocity = Vector3.zero;
        rb.AddTorque(Random.onUnitSphere * torqueForce);
    }
}