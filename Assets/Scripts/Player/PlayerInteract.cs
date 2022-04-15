using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera cam;
    [SerializeField]
    private LayerMask mask;
    [SerializeField]
    private float distance = 3.0f;
    private PlayerUi playerUi;
    private InputManager inputManager;
    void Start()
    {
        cam = GetComponent<PlayerLook>().camera;
        playerUi = GetComponent<PlayerUi>();
        inputManager = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        playerUi.UpdateText(string.Empty);
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit HitInfo;
        if (Physics.Raycast(ray, out HitInfo, distance, mask))
        {
            if (HitInfo.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = HitInfo.collider.GetComponent<Interactable>();
                playerUi.UpdateText(interactable.promptMessage);
                if (inputManager.onFoot.Interact.triggered)
                {
                    interactable.BaseInteract();
                }
            }
        };

    }
}
