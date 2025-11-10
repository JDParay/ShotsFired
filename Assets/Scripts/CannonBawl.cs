using UnityEngine;

public class CannonBawl : MonoBehaviour
{
    [Header("Projectile Settings")]
    public GameObject projectilePrefab;   // Reference to your projectile prefab
    public Transform shootPoint;          // Where the projectile spawns
    public float shootForce = 20f;        // Force of the shot

    void Update()
    {
        // Trigger with Space or Left Mouse Button
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Instantiate projectile
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);

        // Add force using Rigidbody
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Optional: use physics formula approximation
            // X = 1/2at * vt * i → simplified as a constant impulse for this example
            Vector3 launchForce = shootPoint.forward * shootForce;
            rb.AddForce(launchForce, ForceMode.Impulse);
        }

        // Optional: destroy projectile after a few seconds
        Destroy(projectile, 5f);
    }
}
