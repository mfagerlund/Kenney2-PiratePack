using UnityEngine;

public class UnityEventHelper : MonoBehaviour
{
    public void InstantiatePrefab(GameObject prefab)
    {
        if (this != null)
        {
            Instantiate(prefab, transform.position, transform.rotation);
        }
    }

    public void AddRightImpulse(float strength)
    {
        GetComponent<Rigidbody2D>().AddForce(transform.right * -strength, ForceMode2D.Impulse);
    }

    public void AddUpImpulse(float strength)
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * -strength, ForceMode2D.Impulse);
    }

    public void DestroyGameObject(GameObject target)
    {
        Destroy(target);
    }

    public void DelayedDestroyGameObject(float delayTime)
    {
        Destroy(gameObject, delayTime);
    }
}