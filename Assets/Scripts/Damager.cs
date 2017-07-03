using UnityEngine;

public class Damager : MonoBehaviour
{
    public float damage;

    public void OnCollisionEnter2D(Collision2D coll)
    {
        var healted = coll.gameObject.GetComponent<Healthed>();
        if (healted)
        {
            healted.RegisterHit(damage);
        }
    }
}
