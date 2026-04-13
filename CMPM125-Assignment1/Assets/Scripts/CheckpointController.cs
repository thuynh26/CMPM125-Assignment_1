using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public CheckpointController next;
    public CheckpointController target;
    public MeshRenderer left;
    public MeshRenderer right;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target.left.material.color = Color.red;
        target.right.material.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger enter " + other.transform.name);
        Debug.Log("Target: " + target.transform.name);
        Debug.Log("Next: " + next.transform.name);

        VehicleController vehicle = other.gameObject.GetComponent<VehicleController>();
        if (vehicle != null && target == this)
        {
            Debug.Log("Checkpoint reached");
            target = next;
            next.target = next;

            left.material.color = Color.white;
            right.material.color = Color.white;
            next.left.material.color = Color.red;
            next.right.material.color = Color.red;
        }
    }
}
