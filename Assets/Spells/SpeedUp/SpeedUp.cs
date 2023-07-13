using System.Collections.Generic;

public class SpeedUp : Spell
{
    public void Start()
    {
        statuses = new List<Status>();
        statuses.Add(new SpeedUpStatus());
        casterEntity.AddNewStatus(statuses[0]);
        Destroy(gameObject);
    }
}
