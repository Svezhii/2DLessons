using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

[RequireComponent(typeof(Transform))]
public class ButtonScaler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Transform _button;
    private Vector3 _normalScale;
    private float _animationTime = 0.35f;
    private float _onPointerEnterScale = 0.5f;

    private void Start()
    {
        _button = GetComponent<Transform>();
        _normalScale = _button.transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScaleX(_normalScale.x + _onPointerEnterScale, _animationTime);
        transform.DOScaleY(_normalScale.y + _onPointerEnterScale, _animationTime);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(_normalScale, _animationTime);
    }
}
