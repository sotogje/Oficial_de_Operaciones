using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class cargando_nivel : MonoBehaviour
{
    public GameObject pantalla_carga;
    public Slider slider;
    public void cargando_escena(int numero_de_escena)
    {
        StartCoroutine(carga_sincronizadamente(numero_de_escena));
    }
    IEnumerator carga_sincronizadamente(int numero_de_escena)
    {
        AsyncOperation operacion = SceneManager.LoadSceneAsync(numero_de_escena);
        pantalla_carga.SetActive(true);

        while (operacion.isDone == false)
        {
            float progreso = Mathf.Clamp01(operacion.progress / 5f);
            slider.value = progreso;
            yield return null;
        }
    }
}