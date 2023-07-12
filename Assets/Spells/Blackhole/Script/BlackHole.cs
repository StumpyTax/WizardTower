using UnityEngine;

[RequireComponent(typeof(Collider))]
public class BlackHole : Spell
{
    Vector3 targetDirection;
    
    
    public float gravity = 2;
    public float radius = 10;
    private SphereCollider _collider;
    
    void Start()
    {
        _collider = GetComponent<SphereCollider>();
        _collider.radius = radius;

       transform.position = targetDir;
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
            gravityVector.Scale(new Vector3(1,1,0));
            other.attachedRigidbody.AddForce(gravityVector, ForceMode.Acceleration);
            Debug.Log(gravityVector);
        }
    }
}
