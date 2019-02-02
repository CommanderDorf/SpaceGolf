using UnityEngine;

public class Ball : MonoBehaviour
{
    public float force = 100f;
    public float maxForce = 2000;
    private Rigidbody2D body;
    private bool ballInMotion = false;

    // EVENTS
    public delegate void StrokeEvent();
    public event StrokeEvent OnStrokeEvent;

    public delegate void ForceChanged(float power, float maxForce);
    public static event ForceChanged OnPowerChanged;

    public delegate void AimingStateChanged(bool aimingState);
    public static event AimingStateChanged OnAimingStateChanged;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(ballInMotion && body.velocity.magnitude == 0)
        {
            OnAimingStateChanged?.Invoke(true);
            ballInMotion = false;
        }

        if(body.velocity.magnitude != 0)
        {
            return;
        }

        if (Input.GetMouseButton(0))
        {
            force = Mathf.Clamp(force + 20f, 100f, maxForce);

            OnPowerChanged?.Invoke(force, maxForce);
        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector2 forceVector = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
            body.AddForce(forceVector * force);
            ballInMotion = true;

            OnStrokeEvent?.Invoke();
            OnAimingStateChanged?.Invoke(false);
            force = 0;
            OnPowerChanged?.Invoke(force, maxForce);
        }
    }
}
