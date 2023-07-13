using UnityEngine;

[RequireComponent(typeof(Collider))]
public class BlackHole : Spell
{
    Vector3 targetDirection;
    
    
    public float gravity = 2;
    public float radius = 10;
    public float duration=5;

    private SphereCollider _collider;
    private float _curDur=0;
    void Start()
    {
        _collider = GetComponent<SphereCollider>();
        _collider.radius = radius;

       transform.position = targetDir;
    }
    public void FixedUpdate()
    {
        if (_curDur < duration)
            _curDur += Time.fixedDeltaTime;
        else
            GetComponent<Animator>().SetTrigger("End");
    }
    public void OnEnd()
    {
        Destroy(gameObject);
    }

    private void OnTriggerStay (Collider other)
    {
        if (other.attachedRigidbody && other.tag!="Player")
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
            Rigidbody rb;
            if (other.TryGetComponent<Rigidbody>(out rb))
                rb.AddForce(gravityVector, ForceMode.Acceleration);
            Debug.Log(gravityVector);
        }
    }
}
