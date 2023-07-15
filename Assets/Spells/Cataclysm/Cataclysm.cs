using UnityEngine;

public class Cataclysm : Spell
{
    public GameObject SunStrike;

    private void Start()
    {
        foreach (var target in targets)
        {
            if (target == null) continue;
            var sunStrike = Instantiate(SunStrike, target.transform.position, transform.rotation);
            var tmp = sunStrike.GetComponent<SunStrike>();
            tmp.casterEntity = casterEntity;
        }
        Destroy(gameObject);
    }
}
