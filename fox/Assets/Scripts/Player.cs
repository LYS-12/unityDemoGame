using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : KitchenObjectHolder
{
    public static Player Instance { get; private set; }
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private LayerMask countersLayerMask;
    private bool isWalking = false;
    private BaseCounter selectedCounter;
    public bool IsWalking { get { return isWalking; } }
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        gameInput.OnInteractAction += GameInput_OnInteractAction;
    }


    // Update is called once per frame
    void Update()
    {
        HandleInteraction();
    }
    private void FixedUpdate()
    {
        HandleMovement();
    }
    private void GameInput_OnInteractAction(object sender, System.EventArgs e)
    {
        selectedCounter.Interact(this);
    }

    private void HandleMovement()
    {
        Vector3 direction = gameInput.GetMovementDirectionNormalized();
        isWalking = direction != Vector3.zero;
        transform.position += direction * Time.deltaTime * moveSpeed;
        if (direction != Vector3.zero)
        {
            transform.forward = Vector3.Slerp(transform.forward, direction, Time.deltaTime * rotationSpeed);
            //transform.forward = direction;
        }
    }
    private void HandleInteraction()
    {


        if ((Physics.Raycast(transform.position, transform.forward, out RaycastHit hitinfo, 2f, countersLayerMask)))
        {
            if (hitinfo.transform.TryGetComponent<BaseCounter>(out BaseCounter counter))
            {

                SetSelectedCounter(counter);
            }
            else
            {
                SetSelectedCounter(null);
            };

        }
        else
        {
            SetSelectedCounter(null);
        }
    }
    public void SetSelectedCounter(BaseCounter counter)
    {
        if (counter != selectedCounter)
        {
            selectedCounter?.CancelSelect();
            counter?.SelectCounter();
            this.selectedCounter = counter;
        }
    }
}
