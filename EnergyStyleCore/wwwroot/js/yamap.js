let Data;
function initMap(data) {
    Data = data;
    ymaps.ready(init);
}

function init() {

    // Проходим по всем данным и устанавливаем для них маркеры
    $.each(Data, function (i, item) {
        // Создание карты.
        let myMap = new ymaps.Map("map", {
            // Координаты центра карты.
            // Порядок по умолчнию: «широта, долгота».
            center: [item.GeoLong, item.GeoLat],
            // Уровень масштабирования. Допустимые значения:
            // от 0 (весь мир) до 19.
            zoom: 16,
            // Элементы управления
            controls: [

                'zoomControl', // Ползунок масштаба
                'rulerControl', // Линейка
                'routeButtonControl', // Панель маршрутизации
                'trafficControl', // Пробки
                'typeSelector', // Переключатель слоев карты
                'fullscreenControl', // Полноэкранный режим
            ]
        });

        // Добавление метки
        let myPlacemark = new ymaps.Placemark([item.GeoLong, item.GeoLat], {
            // Хинт показывается при наведении мышкой на иконку метки.
            hintContent: item.PlaceName,
            // Балун откроется при клике по метке.
            balloonContent: "<div class='storeInfo'><h3>Магазин: " + item.PlaceName + "</h3><div><h4>Часы работы: "
                + item.WorkTime + "</h4></div><div><h4>Телефон: " + item.LocalPhone + "</h4></div></div>"
        });
        // После того как метка была создана, добавляем её на карту.
        myMap.geoObjects.add(myPlacemark);
    });

}