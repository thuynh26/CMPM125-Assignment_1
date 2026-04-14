using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using NUnit.Framework.Internal;

public class VehicleController : MonoBehaviour
{
    public float desired_acceleration;
    public float impulse;
    public float turnrate;

    public int lapCount = 0;
    public TextMeshProUGUI laplbl;

    public float starttime;
    public TextMeshProUGUI timelbl;

    public bool raceStarted;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        raceStarted = false;
        starttime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        // Update timer and lap counts
        if (raceStarted)
        {
            timelbl.text = string.Format("Time: {0:F2} seconds", (Time.time - starttime));
            laplbl.text = "Lap: " + lapCount;
        }

        // Accerelation and turning
        GetComponent<Rigidbody>().AddRelativeForce(desired_acceleration * impulse, 0, 0);
        float dx = (Mouse.current.position.x.value - Screen.width / 2) / turnrate;
        if (Mathf.Abs(dx) > 0.01f)
        {
            transform.Rotate(0, dx, 0);
        }

    }

    void OnMove(InputValue action)
    {
        var movement = action.Get<Vector2>();
        desired_acceleration = -movement.y;
        // changed to negative because the y-axis is inverted for some reason
    }
}
