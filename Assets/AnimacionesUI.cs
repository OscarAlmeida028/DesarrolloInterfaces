using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionesUI : MonoBehaviour
{
    [SerializeField] private GameObject logo;
    [SerializeField] private GameObject fondoNegro;
    [SerializeField] private GameObject opciones;
    [SerializeField] private GameObject jugarButton;
    [SerializeField] private GameObject opcionesButton;
    [SerializeField] private GameObject creditosButton;
    [SerializeField] private GameObject imgInicio;

    private RectTransform logoRectTransform;
    private RectTransform jugarRectTransform;
    private RectTransform opcionesRectTransform;
    private RectTransform creditosRectTransform;

    private void Start()
    {
        logoRectTransform = logo.GetComponent<RectTransform>();
        jugarRectTransform = jugarButton.GetComponent<RectTransform>();
        opcionesRectTransform = opcionesButton.GetComponent<RectTransform>();
        creditosRectTransform = creditosButton.GetComponent<RectTransform>();

        MoveToStartPosition();
    }

    private void MoveToStartPosition()
    {
        float targetY = 900f; // La posición final deseada para el logo
        float duration = 1.5f; // Duración del movimiento inicial para el logo

        LeanTween.moveY(logoRectTransform, targetY, duration)
            .setEase(LeanTweenType.easeInBounce)
            .setOnComplete(StartBouncing);


        StartBouncingButtons();
    }

    private void StartBouncing()
    {
        float bounceAmount = 100f; // Cantidad de rebote
        float duration = 1.5f; // Duración de cada rebote

        LeanTween.moveY(logoRectTransform, logoRectTransform.anchoredPosition.y + bounceAmount, duration)
            .setEase(LeanTweenType.easeInOutSine)
            .setLoopPingPong();
    }

    private void StartBouncingButtons()
    {
        float bounceAmount = 30f; // Cantidad de rebote para los botones
        float duration = 1.5f; // Duración de cada rebote

        // Movimiento de rebote para el botón Jugar
        LeanTween.moveY(jugarRectTransform, jugarRectTransform.anchoredPosition.y + bounceAmount, duration)
            .setEase(LeanTweenType.easeInOutSine)
            .setLoopPingPong();

        // Movimiento de rebote para el botón Opciones
        LeanTween.moveY(opcionesRectTransform, opcionesRectTransform.anchoredPosition.y + bounceAmount, duration)
            .setEase(LeanTweenType.easeInOutSine)
            .setLoopPingPong();

        // Movimiento de rebote para el botón Créditos
        LeanTween.moveY(creditosRectTransform, creditosRectTransform.anchoredPosition.y + bounceAmount, duration)
            .setEase(LeanTweenType.easeInOutSine)
            .setLoopPingPong();
    }

    public void AbrirMenuOpciones()
    {
        LeanTween.scale(opciones.GetComponent<RectTransform>(), new Vector3(1, 1, 1), 0.5f)
            .setDelay(0.5f).setEase(LeanTweenType.easeInOutBack);
        LeanTween.alpha(fondoNegro.GetComponent<RectTransform>(), 0.5f, 1f);

        // Reproducir el sonido de clic
        SoundManager.instance.PlayClickSound();
    }

    public void CerrarMenuOpciones()
    {
        LeanTween.scale(opciones.GetComponent<RectTransform>(), new Vector3(0, 0, 0), 0.5f);
        LeanTween.alpha(fondoNegro.GetComponent<RectTransform>(), 0f, 0.5f);

        // Reproducir el sonido de clic
        SoundManager.instance.PlayClickSound();
    }
}
