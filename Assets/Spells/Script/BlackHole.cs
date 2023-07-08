using UnityEngine;

[RequireComponent(typeof(Collider))]
public class BlackHole : Spell
{
    Vector3 targetDirection;
    
    
    public float gravity = 2;
    public float radius = 10;
    private SphereCollider _collider;
    
    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<SphereCollider>();
        _collider.radius = radius;

        transform.position = caster.transform.position;
    }

    private void OnTriggerStay (Collider other)
    {
        if (other.attachedRigidbody)
        {
            Vector3 difference = new Vector3(
                gameObject.transform.position.x - other.gameObject.transform.position.x, 
                gameObject.transform.position.y - other.gameObject.transform.position.y,
                gameObject.transform.position.z - other.gameObject.transform.position.z
            );
            Vector3 gravityDirection = difference.normalized;
            gravityDirection = gravityDirection * radius;
            Vector3 gravityVector = (gravityDirection - difference) * gravity;

            other.attachedRigidbody.AddForce(gravityVector, ForceMode.Acceleration);
            Debug.Log(gravityVector);
        }
    }
}
