using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Transform))]
public class ButtonClicker : MonoBehaviour, IPointerClickHandler
{
    private Image _image;
    private Transform _button;
    private Vector3 _normalScale;
    private float _animationTime = 0.2f;
    private float _onPointerClickScale = 0.5f;

    private void Start()
    {
        _button = GetComponent<Transform>();
        _image = GetComponent<Image>();
        _normalScale = _button.transform.localScale;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(gameObject.name);
        Debug.Log(_normalScale);

        transform.DOScaleX(_button.transform.localScale.x - _onPointerClickScale, _animationTime).SetLoops(2, LoopType.Yoyo);
        transform.DOScaleY(_button.transform.localScale.y - _onPointerClickScale, _animationTime).SetLoops(2, LoopType.Yoyo);

        _image.DOColor(Color.blue, _animationTime).SetLoops(2, LoopType.Yoyo);
    }
}
