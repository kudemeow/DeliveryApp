# DeliveryApp

## Описание

DeliveryApp — это консольное приложение на C#, предназначенное для фильтрации заказов службы доставки. Приложение позволяет фильтровать заказы по району и времени доставки, а также ведет логирование операций.

## Требования

- .NET 5.0 или выше
- Windows, macOS или Linux

## Установка

1. Склонируйте репозиторий или распакуйте архив с исходным кодом: git clone https://github.com/kudemeow/Orders;

## Конфигурация

- Убедитесь, что файл с заказами (`orders.txt`) находится в корневой директории проекта или укажите путь к файлу через параметры командной строки.
- Путь к файлу логов по умолчанию: рабочий стол текущего пользователя. Файл будет называться `delivery_log.txt`.

## Запуск

Для запуска приложения используйте команду: dotnet run -- `<ordersFilePath>` `<district>` `<firstDeliveryTime>` `<resultFilePath>`, где:  
    - `<ordersFilePath>` — путь к файлу с заказами.  
    - `<district>` — район доставки для фильтрации.  
    - `<firstDeliveryTime>` — время первой доставки в формате `yyyy-MM-dd HH:mm:ss`.  
    - `<resultFilePath>` — путь к файлу, в который будет записан результат фильтрации.  
Например, dotnet run -- "orders.txt" "DistrictA" "2023-10-01 09:00:00" "result.txt" или dotnet run -- "C:\Documents\orders.txt" "DistrictA" "2023-10-01 09:00:00" "result.txt".  
Пример файла orders.txt:  
    1,10.5,DistrictA,2023-10-01 09:00:00  
    2,5.0,DistrictB,2023-10-01 09:15:00  
    3,7.2,DistrictA,2023-10-01 09:30:00  
    4,3.8,DistrictC,2023-10-01 09:45:00  
    5,12.0,DistrictB,2023-10-01 10:00:00  
    6,6.5,DistrictA,2023-10-01 10:15:00  
    7,8.3,DistrictC,2023-10-01 10:30:00  
    8,4.4,DistrictB,2023-10-01 10:45:00  
    9,9.1,DistrictA,2023-10-01 11:00:00  
    10,11.7,DistrictC,2023-10-01 11:15:00

## Логирование

Логи записываются в файл `delivery_log.txt` на рабочем столе текущего пользователя. Файл создается автоматически, если его не существует.

## Примечания

- Убедитесь, что у вас есть права на запись в директорию, где будет создаваться файл логов.
- Для изменения настроек логирования или других параметров вы можете изменить соответствующие методы в коде приложения.

## Поддержка

Если у вас возникли вопросы или проблемы, пожалуйста, создайте issue в репозитории или свяжитесь с автором проекта.
