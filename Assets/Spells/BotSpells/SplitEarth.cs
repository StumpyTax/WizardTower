using System.Collections;
using UnityEngine;

public class SplitEarth : Spell
{
    private void Start()
    {
        statuses.Add(new Stun());
        transform.position = casterEntity.transform.position;
        StartCoroutine(DestroyRoutine());
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            var victim = other.GetComponent<Entity>();
            victim.Hp -= CalculateDamage();
            victim.AddNewStatuses(statuses);
        }
    }

    public IEnumerator DestroyRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
