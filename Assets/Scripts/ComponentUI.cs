using System;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;


namespace UserGames
{
    public class ComponentUI:MonoBehaviour,IDragHandler,IPointerDownHandler,IEndDragHandler// TODO 学习整理
    {     

        private Vector2 _startPos;//开始位置
        private Vector2 _offset;//位置偏移
        private RectTransform _tr;

        public void Awake()
        {
            _tr = GetComponent<RectTransform>();
        }

        /// <summary>
        /// 拖拽UI
        /// </summary>
        public void OnDrag(PointerEventData eventData)
        {
            Vector3 pos;
            RectTransformUtility.ScreenPointToWorldPointInRectangle(_tr, eventData.position, eventData.enterEventCamera, out pos);
            _tr.position = pos-(Vector3)_offset;
        }
        /// <summary>
        /// 点击回调函数
        /// </summary>
        public void OnPointerDown(PointerEventData eventData)
        {
            
            Vector3 pos;
            RectTransformUtility.ScreenPointToWorldPointInRectangle(_tr, eventData.position, eventData.enterEventCamera, out pos);
            _startPos = _tr.position;
            _offset = (Vector2)pos - _startPos;
            //更改detail界面
            var count = _tr.parent.childCount;
            _tr.SetSiblingIndex(count - 1);//TODO 学习整理
        }
        
        /// <summary>
        /// 拖拽结束回调函数
        /// </summary>
        public void OnEndDrag(PointerEventData eventData)
        {
        }
    }
}