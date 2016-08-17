using UnityEngine;
using System.Collections;

public abstract class Actor : Destroyable {

    public HealthInterface health;

    void Start()
    {
        health = GetComponent<HealthInterface>();
        init();
    }

    public abstract void init();

    public void LoseHealth(float amount)
    {
        health.LoseHealth(amount);

        TestDead();
    }

    public void SetHealth(float amount)
    {
        health.SetHealth(amount);

        TestDead();
    }

    private void TestDead()
    {
        if (health.Dead())
        {
            DestroySelf();
        }
    }

    public abstract bool Hit(string tag);

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (Hit(collision.gameObject.tag))
        {
            Projectile proj = collision.gameObject.GetComponent<Projectile>();

            LoseHealth(proj.Damage());
        }
    }

}
