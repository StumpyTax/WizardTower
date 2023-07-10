using UnityEngine;

public class Projectile : Entity
{
    public float speed;
    public float range;
    public float pushForce;
    
    public Vector3 start;
    public Vector3 direction;

    protected Rigidbody rb;
    private GameObject _gm;
    private Collider collider;
    public Spell spell;

   
    public void SetStatuses(Entity victim)
    {
        foreach (var status in spell.statuses)
        {
            status.target = victim;
            var statusGameObj = Instantiate(status);
/*            victim._statuses.Add(statusGameObj);
*/        }
    }

    public void Start()
    {
        collider= GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        return;
    }
}
