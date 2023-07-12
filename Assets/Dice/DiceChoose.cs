using UnityEngine;

public class DiceChoose : MonoBehaviour
{
    public GameObject newEdge;
    public float FrictionForce = 0.05f;
    public float lerpSpeed = 300;

    private float xDeg = 0;
    private float yDeg = 0;

    private Dice _dice;
    private Rigidbody _rb;

    public void Start()
    {
        _dice = GetComponent<Dice>();
        _rb = GetComponent<Rigidbody>();
        _dice.SetDiceAtStartPosition();
        _dice.OnTopEdgeChange = (o, o1) =>
        {
            var color = UnityEngine.Color.yellow;
            color.a = 0.5f;
            o.GetComponent<SpriteRenderer>().color = Color.white;
            o1.GetComponent<SpriteRenderer>().color = Color.yellow;
        };
    }

    public void Update()
    {
        Friction();
        _dice.GetTopEdge();
    }

    public void Confirm()
    {
        _dice.ChangeEdge(_dice.GetTopEdge(), newEdge);
    }

    public void Rotate(Vector3 vector3)
    {
        transform.Rotate(vector3);
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse0)) //если зажата ЛКМ
        {
            _rb.angularVelocity += new Vector3((Input.GetAxis("Mouse Y") * lerpSpeed * Time.deltaTime),
                (-Input.GetAxis("Mouse X") * lerpSpeed * Time.deltaTime), 0);
        }
    }

    private void Friction()
    {
        _rb.angularVelocity += new Vector3(
            _rb.angularVelocity.x * -FrictionForce, 
            _rb.angularVelocity.y * -FrictionForce,
            _rb.angularVelocity.z * -FrictionForce);
    }
}
