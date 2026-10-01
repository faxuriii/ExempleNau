using UnityEngine;

public class Meteorit : MonoBehaviour
{
    float vel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vel = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * vel * Time.deltaTime);

        if (transform.position.z < ValorsGlobals.LimitZNegaitu)
        {
            Destroy(gameObject);
        }
    }
}
