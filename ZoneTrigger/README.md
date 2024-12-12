# ZoneTrigger

![image](https://github.com/user-attachments/assets/c95ce1d9-1fcb-4588-8553-741264592e7d)

## Пример 

![image](https://github.com/user-attachments/assets/629cc099-4a09-453a-9b07-59581efbb00e)

## Как использовать?

Разберем на примере монстра, который исчезает при касании его палкой.

### Шаг 1

Скачайте и импортируйте `ZoneTrigger.unitypackage`.

### Шаг 2 

Добавьте объекту любой подходящий коллайдер, установив у этого коллайдера флажок `Is Trigger`.

![Screenshot_45](https://github.com/user-attachments/assets/8ccd7c2f-e7be-47dc-86ac-25ae5fbfd112)


### Шаг 3

Создайте пустой `C# Script` с названием `Tag_Weapon` по пути `Assets/Scripts`. Скрипт пригодится для пометки предметов, на которые среагирует монстр (палка, меч, камень и т.п.).

![Screenshot_46](https://github.com/user-attachments/assets/c192cbdf-4696-4fed-94a5-cf94eedb6a3a)

Перенесите его на интерактивный объект, а точнее на ту часть, у которой имеется коллайдер.

![Screenshot_47](https://github.com/user-attachments/assets/b73ca0d3-46b0-4a06-9dc1-49e4fab8b0b9)

### Шаг 4

Добавьте на монстра скрипт `ZoneTrigger.cs` (Находится в `Assets/Scripts/`)

![Screenshot_48](https://github.com/user-attachments/assets/444516e0-21c5-44e7-968a-5cd8950be4ce)

Укажите скрипт, на который зона должна среагировать, нажав на кнопку у этого скрипта `Add Component` и выбрав в выпадающем списке скрипт `Tag_Weapon`.

![Screenshot_49](https://github.com/user-attachments/assets/17af545f-d5d1-4f22-8a68-5ece89053a18)

### Шаг 5

Настройте событие, которое должно произойти при входе и/или выходе из зоны предмета(палки) в событиях `On Enter` и `On Exit`

![Screenshot_50](https://github.com/user-attachments/assets/01da93cb-0a9e-4665-a15b-7de34427af99)

Например, перетащите объект монстра в `None (Object)` и укажите ему функцию исчезновения `No Functio -> GameObject -> SetActive (bool)`. Галочка должна быть снята, чтобы объект исчез.

![Screenshot_51](https://github.com/user-attachments/assets/40e3688a-4224-4666-b961-da224d53b0de)

### Готово

Нажмите на `Play`. Возьмите палку и тыкните ей в триггерную зону монстра - он исчезнет. 
