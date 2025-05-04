using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class ApiCardLoader : MonoBehaviour
{
    public string apiUrl = "https://www.imtech.com.ar/GAME/api/v1/get_cartas.php";

    public void DescargarCartas(System.Action<System.Collections.Generic.List<CardJsonData>> callback)
    {
        StartCoroutine(DescargarCartasCoroutine(callback));
    }

    private IEnumerator DescargarCartasCoroutine(System.Action<System.Collections.Generic.List<CardJsonData>> callback)
    {
        UnityWebRequest request = UnityWebRequest.Get(apiUrl);
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("❌ Error al contactar la API: " + request.error);
            callback?.Invoke(null);
            yield break;
        }

        string json = request.downloadHandler.text;
        ApiResponse respuesta = JsonUtility.FromJson<ApiResponse>(json);
        if (respuesta == null || respuesta.data == null)
        {
            Debug.LogError("❌ No se pudieron parsear las cartas.");
            callback?.Invoke(null);
            yield break;
        }

        callback?.Invoke(respuesta.data);
    }
}