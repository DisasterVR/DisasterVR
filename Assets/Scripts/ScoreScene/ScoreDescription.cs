using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class Score
{
    public string description;
    public long points;
    public bool secure;
}

public class ScoreDescription : MonoBehaviour
{
    public Score[] scoreArray;
    public short sizeScoreArray = 3;
    public GameObject textoPrefab; // Asigna tu prefab de texto desde el Inspector
    public GameObject imagen;

    private GameObject txtImage;
    // Start is called before the first frame update
    void Start()
    {
        scoreArray = new Score[sizeScoreArray];
        scoreArray[0] = new Score { description = "Cerca de las ventanas", points = 0, secure = false };
        scoreArray[1] = new Score { description = "Permanecer cerca de una columna", points = 0, secure = true };
        scoreArray[2] = new Score { description = "Encontrarse alejado del estante", points = 0, secure = false };
        
        txtImage = new GameObject("TextoImagen");
        txtImage.transform.position = imagen.transform.position;
        txtImage.transform.rotation = imagen.transform.rotation;
        txtImage.transform.localScale = imagen.transform.localScale;
        InstanciarTextoPrefab();
    }

    // Update is called once per frame
    void InstanciarTextoPrefab()
    {
        GameObject[] txtInstantiate = new GameObject[3];
        for (int i = 0; i < 3; i++)
        {
            // Instanciar el prefab de TextMeshPro
            txtInstantiate[i] = Instantiate(textoPrefab, Vector3.zero, Quaternion.identity);

            // Establecer la imagen como padre del texto instanciado
            txtInstantiate[i].transform.SetParent(imagen.transform, false);
            //txtInstantiate[i].transform.position = new Vector3(txtInstantiate[i].transform.position.x, 14.493f, 0);
            
            txtInstantiate[i].transform.position = new Vector3(
                -14.158f,
                txtInstantiate[i].transform.position.y - (3*i),
                txtInstantiate[i].transform.position.z
            );

            // Configurar el contenido del texto (ajusta según tus necesidades)
            TextMeshProUGUI textoMeshProComponente = txtInstantiate[i].GetComponent<TextMeshProUGUI>();
            if (textoMeshProComponente != null)
            {
                textoMeshProComponente.text = scoreArray[i].description;
            }
        }
    }
}
