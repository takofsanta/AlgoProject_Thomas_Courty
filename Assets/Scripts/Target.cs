using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.EditorTools;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRB;

    //force de l'impulsion
    [SerializeField]
    private float minImpulse = 15f;
    [SerializeField]
    private float maxImpulse = 25f;
    [SerializeField]
    private float maxTorque = 10f;
    [SerializeField]
    private float maxSpawnX = 4f;
    [SerializeField]
    private float pointSpawn = -1f;

    private Controller controller;
    [SerializeField] private int scoreItem;
    [SerializeField] GameObject destroyFXParticle;

    // Start is called before the first frame update
    void Start()
    {
        targetRB = GetComponent<Rigidbody>();
        targetRB.AddForce(RandomForce(), ForceMode.Impulse);
        targetRB.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawn();

        controller = GameObject.Find("GameManager").GetComponent<Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minImpulse, maxImpulse);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    private Vector3 RandomSpawn()
    {
        return new Vector3(Random.Range(-maxSpawnX, maxSpawnX), pointSpawn);
    }
    private void OnMouseDown()
    {
        if (controller.isGamePlaying)
        {
            Instantiate(destroyFXParticle, this.transform.position, this.transform.rotation);
            controller.UpdateScore(scoreItem);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (gameObject.CompareTag("good"))
        {
            controller.GameOver();
        }
    }
}
