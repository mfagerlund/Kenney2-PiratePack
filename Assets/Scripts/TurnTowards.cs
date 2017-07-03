using UnityEngine;

public class TurnTowards : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    public float rotationSpeed = 0.5f;
    public float turnVelocityScale = 4;

    void Update()
    {
        var player = GameObject.FindGameObjectWithTag("Player");

        if (!player)
        {
            return;
        }

        // If there is a player, turn towards it!
        _rigidbody2D = _rigidbody2D ?? GetComponent<Rigidbody2D>();

        var dir = player.GetComponent<Rigidbody2D>().position - _rigidbody2D.position;
        if (dir.sqrMagnitude >= 0)
        {
            dir.Normalize();

            var wantedRotation = Mathf.Atan2(dir.y, dir.x);
            float velocityScale = Mathf.Clamp01((_rigidbody2D.velocity.magnitude + 0.1f) * turnVelocityScale);
            var currentRotation = Mathf.Deg2Rad * _rigidbody2D.rotation;
            var delta = currentRotation - wantedRotation;
            while (delta > Mathf.PI) { delta -= 2 * Mathf.PI; }
            while (delta < -Mathf.PI) { delta += 2 * Mathf.PI; }
            _rigidbody2D.AddTorque(-delta * rotationSpeed * velocityScale);
        }
    }
}
