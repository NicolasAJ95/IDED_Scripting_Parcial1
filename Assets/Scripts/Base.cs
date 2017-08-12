using UnityEngine;

public delegate void OnBaseDestroyed(Base thisBase);

public delegate void OnTurnFinished();

[RequireComponent(typeof(Collider))]
public class Base : MonoBehaviour
{
    public OnBaseDestroyed onBaseDestroyed;
    public OnTurnFinished onTurnFinished;

    [SerializeField]
    private float maxHP = 500F;

    [SerializeField]
    private Catapult catapult;

    [SerializeField]
    private RayBeam rayBeam;

    private float currentHP;

    private bool canAttack;
    private bool defending;

    public void EnableTurn()
    {
        enabled = true;
        canAttack = true;
    }

    public void AttackWithCatapult()
    {
        catapult.Fire();
        onTurnFinished();
        Debug.Log("Used Attack with catapult");
    }

    public void AttackWithRay()
    {
        rayBeam.Fire();
        onTurnFinished();
        Debug.Log("Used Attack with ray");
    }

    public void Repair()
    {
        currentHP += 125.0f;
        Debug.Log("Used repair");
        onTurnFinished();
    }

    public void Defend()
    {
        Debug.Log("Used defend");
        defending = true;
        
        onTurnFinished();
    }

    public void TakeDamage(RayBeam ray)
    {
        if(defending == false)
        {
            currentHP -= ray.DamagePts;
            Debug.Log("Daño recibido, salud: " + currentHP);
        }

        if (defending == true)
        {
            currentHP -= ray.DamagePts * 0.25f;
            Debug.Log("Daño recibido, salud: " + currentHP);
        }

    }

    private void TakeDamage(Projectile projectile)
    {
        if (defending == false)
        {
            currentHP -= projectile.DamagePts;
            Debug.Log("Daño recibido, salud: " + currentHP);
        }

        if (defending == true)
        {
            currentHP -= projectile.DamagePts * 0.25f;
            Debug.Log("Daño recibido, salud: " + currentHP);
        }
    }

    // Use this for initialization
    private void Start()
    {
        currentHP = maxHP;

        enabled = false;
        canAttack = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && canAttack)
        {
            AttackWithCatapult();
        }

        if (Input.GetKeyDown(KeyCode.S) && canAttack)
        {
            AttackWithRay();
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
            TakeDamage();
    }

}