using UnityEngine;

public class cameraAction : MonoBehaviour
{
    private Transform cameraTransform { get; set; } = null;

    private void Start()
    {
        cameraTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        DrawRay();

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.farClipPlane));

            if (Physics.Raycast(cameraTransform.position, worldPos - cameraTransform.position, out RaycastHit hit))
            {
                Debug.Log(hit.transform.name);
            }
        }
    }

    private void DrawRay()
    {
        Vector3 mousePosition = Input.mousePosition;

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.farClipPlane));

        Debug.DrawRay(cameraTransform.position, worldPos - cameraTransform.position, Color.red);
    }
}
