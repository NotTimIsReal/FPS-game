using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keypad : Interactable
{
    public bool isClosed = true;
    [SerializeField]
    private GameObject door;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    protected override void Interact()
    {
        Debug.Log("Interacting with keypad");
        isClosed = !isClosed;
        door.GetComponent<Animator>()
        .SetBool("isOpen", !isClosed);
    }
}
