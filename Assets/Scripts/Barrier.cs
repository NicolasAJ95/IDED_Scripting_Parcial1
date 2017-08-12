using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Barrier : MonoBehaviour
{
    [SerializeField]
    private DamageType type;

    [SerializeField]
    private float maxHp;

    private float currentHP;

    public float CurrentHP
    {
        get
        {
            return currentHP;
        }

        set
        {
            currentHP = value;
        }
    }

    public void TakeDamage(RayBeam ray)
    {

    
            currentHP -= ray.DamagePts;
            Debug.Log("Daño recibido, salud: " + currentHP);
       


    }

    private void TakeDamage(Projectile projectile)
    {

        
            currentHP -= projectile.DamagePts;
            Debug.Log("Daño recibido, salud: " + currentHP);
        

    }

    // Use this for initialization
    private void Start()
    {
        currentHP = maxHp;
    }
}