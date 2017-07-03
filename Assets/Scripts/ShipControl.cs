using UnityEngine;

public class ShipControl : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private float _lastFireTime = 0;

    public float rotationSpeed = 1;
    public float movementForce = 1;
    public float fireImpulse = 1;
    public float turnVelocityScale = 1;
    public GameObject bullet;
    public Transform bulletSpawnPosition;
    public float fireCooldownPeriod = 0.2f;

    public void Update()
    {
        if (Input.GetButton("Fire1") && (Time.time - _lastFireTime) > fireCooldownPeriod)
        {
            var instance = (GameObject)Instantiate(bullet, bulletSpawnPosition.position, transform.rotation);
            if (instance != null)
            {
                var rigid = instance.GetComponent<Rigidbody2D>();
                if (rigid != null)
                {
                    rigid.velocity = _rigidbody2D.velocity;
                    _rigidbody2D.AddForce(-transform.right * fireImpulse, ForceMode2D.Impulse);
                    instance.gameObject.layer = LayerMask.NameToLayer("Friendly Bullets");
                    Destroy(instance, 2);
                    _lastFireTime = Time.time;
                }
            }
        }
    }

    public void FixedUpdate()
    {
        _rigidbody2D = _rigidbody2D ?? GetComponent<Rigidbody2D>();

        float velocityScale = Mathf.Clamp01((_rigidbody2D.velocity.magnitude + 0.1f) * turnVelocityScale);
        _rigidbody2D.AddTorque(-Input.GetAxis("Horizontal") * rotationSpeed * velocityScale);

        float backPenalty = Input.GetAxis("Vertical") < 0 ? 0.2f : 1;
        _rigidbody2D.AddForce(Input.GetAxis("Vertical") * movementForce * transform.right * backPenalty, ForceMode2D.Impulse);
    }

    public void OnDestroy()
    {
        if (GameManager.Instance)
        {
            GameManager.Instance.livesLeft--;
        }
    }
}
