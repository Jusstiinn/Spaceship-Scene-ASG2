using UnityEngine;

public class NewPlayerTeleporter : MonoBehaviour
{
    [Header("Destination")]
    public Transform teleportPoint;

    [Header("Linked Teleporter")]
    public NewPlayerTeleporter linkedTeleporter;

    private bool canTeleport = true;

    private void OnTriggerEnter(Collider other)
    {
        if (!canTeleport)
            return;

        if (!other.CompareTag("Player"))
            return;

        CharacterController cc = other.GetComponent<CharacterController>();

        if (cc == null)
            return;

        // Disable the destination until the player leaves it.
        linkedTeleporter.canTeleport = false;

        // Preserve local position.
        Vector3 localPos = transform.InverseTransformPoint(other.transform.position);

        // Preserve facing direction.
        Quaternion rotationOffset =
            teleportPoint.rotation * Quaternion.Inverse(transform.rotation);

        cc.enabled = false;

        other.transform.position = teleportPoint.TransformPoint(localPos);
        other.transform.rotation = rotationOffset * other.transform.rotation;

        cc.enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        canTeleport = true;

        if (linkedTeleporter != null)
            linkedTeleporter.canTeleport = true;
    }
}