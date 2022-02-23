using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementOnline : Mirror.NetworkBehaviour
{
    [SerializeField]
    private float speed = 3.5f;
    private bool toyAlRevez= false;

    public GameObject camObject;
    public Camera cam;
        float height ;
        float width ;

    private Mirror.NetworkManager networkManager;
    private void Start() {
        if(!isServer)
        return;

    SetupCamera(this.gameObject.GetComponent<Mirror.NetworkIdentity>().connectionToClient,GameObject.FindGameObjectWithTag("NetworkManager").GetComponent<Mirror.Examples.Pong.NetworkManagerPong>().numPlayers);

    }

    [Mirror.TargetRpc]
    public void SetupCamera(Mirror.NetworkConnection target, int playernum)
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        Debug.Log("CUANTOS PLAYERS TENGO???: " + playernum);
        if(playernum > 1)
        {
            cam.transform.Rotate(new Vector3(0,0,180));
            toyAlRevez=true;

        }
    
        height = 2f * cam.orthographicSize;
        width = height * cam.aspect;
    }

    public void LinkCamera(GameObject _cam)
    {
        cam = _cam.GetComponent<Camera>();
        
        GameObject[] cameras = GameObject.FindGameObjectsWithTag("MainCamera");

        Debug.Log("Takoyaki cameras.Length: " + cameras.Length);
        for (int i = 0; i < cameras.Length; i++)
        {
            if(cameras[i] != _cam)
            {
                Debug.Log("Setting " + cameras[i].name + " inactive");
                Debug.Log(cameras[i].name + " != " + _cam.name);
                cameras[i].SetActive(false);
            }
        }

        height = 2f * cam.orthographicSize;
        width = height * cam.aspect;
    }

    void Awake()
    {

    }

    void Update()
    {

        if(!isLocalPlayer)
        return;

        

        float verticalImput = Input.GetAxis("Vertical");
        float horizontallImput = Input.GetAxis("Horizontal");
        if(!toyAlRevez){
            //horizontal block
        if(transform.position.x + (transform.position.x * 0.1f) >= (cam.transform.position.x + (width/2.0f))){
            if(horizontallImput>0){
                horizontallImput=0;
            }
        }
        if(transform.position.x + (transform.position.x * 0.1f) <= (cam.transform.position.x - (width/2.0f))){
            if(horizontallImput<0){
                horizontallImput=0;
            }
        }
        //vertical block
        if(transform.position.y + (transform.position.y * 0.1f) >= (cam.transform.position.y + (height/2.0f))){
            if(verticalImput>0){
                verticalImput=0;
            }
        }   
        if(transform.position.y + (transform.position.y * 0.1f) <= (cam.transform.position.y - (height/2.0f))){
            if(verticalImput<0){
                verticalImput=0;
            }
        }
        }else{
            //horizontal block
        if(transform.position.x + (transform.position.x * 0.1f) >= (cam.transform.position.x + (width/2.0f))){
            if(horizontallImput<0){
                horizontallImput=0;
            }
        }
        if(transform.position.x + (transform.position.x * 0.1f) <= (cam.transform.position.x - (width/2.0f))){
            if(horizontallImput>0){
                horizontallImput=0;
            }
        }
        //vertical block
        if(transform.position.y + (transform.position.y * 0.1f) >= (cam.transform.position.y + (height/2.0f))){
            if(verticalImput<0){
                verticalImput=0;
            }
        }   
        if(transform.position.y + (transform.position.y * 0.1f) <= (cam.transform.position.y - (height/2.0f))){
            if(verticalImput>0){
                verticalImput=0;
            }
        }
        }
           

        Vector3 direction = new Vector3(horizontallImput, verticalImput,0f);
        transform.Translate(direction * speed *Time.deltaTime);
    }

}
