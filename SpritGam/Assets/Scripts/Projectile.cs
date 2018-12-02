using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    [SerializeField] GunController gunController;
    [SerializeField] int bulletCount;

    // Use this for initialization
    void Start () {
        
    }
    
    // Update is called once per frame
    void Update ()
    {
        transform.position += transform.up * Time.deltaTime * speed;
    }
}
