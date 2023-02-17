using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SelectionManager : MonoBehaviour
{

    public GameObject Info;
    Text interaction_text;
    public float maxDistance = 2;
    public bool onTarget;
    public static SelectionManager Instance { get; set; }

    private void Start()
    {
        interaction_text = Info.GetComponent<Text>();
        onTarget = false;
    }

    private void Awake()
    {
        if(Instance != null && Instance !=this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Debug.DrawRay(transform.position, transform.forward, Color.green);
            var selectionTransform = hit.transform;
            InteractableObject Interactable = selectionTransform.GetComponent<InteractableObject>();

            if (Interactable && Interactable.playerInRange)
            {

                onTarget = true;
                interaction_text.text = Interactable.GetItemName();
                Info.SetActive(true);
            }
            else
            {
                onTarget = false;
                Info.SetActive(false);
            }

        }
        else
        {
            onTarget = false;
            Info.SetActive(false);
        }
    }
}
