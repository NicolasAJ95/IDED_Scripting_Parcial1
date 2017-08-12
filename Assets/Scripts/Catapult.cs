using UnityEngine;

public class Catapult : MonoBehaviour
{
    [SerializeField]
    private GameObject projectileToFire;

    [SerializeField]
    private Transform projectileSpawnTranform;

    [SerializeField]
    private float forceAmount;

    public void Fire()
    {
        var firedProj = Instantiate(projectileToFire, projectileSpawnTranform.position, projectileSpawnTranform.rotation);
        var rb = firedProj.GetComponent<Rigidbody>();
        rb.AddForce(Vector3.right * forceAmount, ForceMode.Impulse);
        
    }
}