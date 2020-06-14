
function initMap(data, index, parent) {
    ymaps.ready(() => {

        let div = document.createElement('div');
        div.id = `map${index}`;
        div.className = 'commun_right';
        div.style = 'width: 600px; height: 500px';
        parent.append(div);
        // Создание карты.
        let myMap = new ymaps.Map(`map${index}`, {
            // Координаты центра карты.
            // Порядок по умолчнию: «широта, долгота».
            center: [data.geoLong, data.geoLat],
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
        let myPlacemark = new ymaps.Placemark([data.geoLong, data.geoLat], {
            // Хинт показывается при наведении мышкой на иконку метки.
            hintContent: data.glaceName,
            // Балун откроется при клике по метке.
            balloonContent: "<div class='storeInfo'><h3>Магазин: " + data.placeName + "</h3><div><h4>Часы работы: "
                + data.workTime + "</h4></div><div><h4>Телефон: " + data.localPhone + "</h4></div></div>"
        });
        // После того как метка была создана, добавляем её на карту.
        myMap.geoObjects.add(myPlacemark);

    });
}
