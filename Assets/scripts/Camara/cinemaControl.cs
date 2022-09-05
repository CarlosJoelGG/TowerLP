using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using System.Collections.Generic;


public class cinemaControl : MonoBehaviour
{
    public Camera cam;
    public Slider slide;
    public CinemachineVirtualCamera cine;
    public float inputVel, inputVel2, zx;
    public Vector2 Altolimite, Minimolimite;
    public float zSizeMin, zSizeMax;
    public float zSize;
    public CamaraMove camMove;
    public bool PVE = false;
    // Start is called before the first frame update
    void Start()
    {
        if (!PVE)
        {
            iniciar();
        }
    }
    public void iniciar()
    {
        camMove = GetComponent<CamaraMove>();

        cam = Camera.main;

        if (zSizeMin == 0) zSizeMin = 7;

        if (zSizeMin == 0) zSizeMin = 12;

        //cine.m_Lens.OrthographicSize = 7;
        float cSize = Mathf.Round((zSizeMax - zSizeMin) / 3);

        cam.orthographicSize = cSize + zSizeMin;


        zSize = cam.orthographicSize;
        slide.minValue = zSizeMin;
        slide.maxValue = zSizeMax;
        slide.value = cSize + zSizeMin;
        slide.value = 11;
    }
    public void guardar()
    {
        zSize = cam.orthographicSize;
    }
    public float analizar(float a)
    {

        if (zSize-(a / inputVel2) < zSizeMin)
            return zSizeMin;
        if (zSize-(a / inputVel2) > zSizeMax)
            return zSizeMax;

        return (zSize-(a / inputVel2));
    }
    // Update is called once per frame
    void Update()
    {

        
       // zSize = slide.value;
        zx = zSizeMax - zSizeMin;
        inputVel = camMove.speedModiferMax - camMove.speedModiferMin;

        float c = zSize - zSizeMin;
        float a = (c * inputVel) / zx;

        camMove.speedModifer = a + camMove.speedModiferMin;
        
        //cam.orthographicSize = zSize;
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("colision");
    }
    private void OnCollisionExit(Collision collision)
    {
        
    }
    private void OnCollisionStay(Collision collision)
    {
        
    }
}
