using UnityEngine;
using System.Collections;

public class BoomController : MonoBehaviour
{

    public Vector3 target;
    public float moveSpeed = 3;
    public float destroyTime = 1;
    public GameObject explor;
    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((transform.position - target) * moveSpeed * Time.deltaTime * -1);
    }

    void OnDestroy()
    {
        GameObject exp = Instantiate(explor, transform.position, Quaternion.identity) as GameObject;
        Destroy(exp, 0.5f);
    }
}
