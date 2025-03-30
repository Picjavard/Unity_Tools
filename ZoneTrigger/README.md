# ZoneTrigger

![image](https://github.com/user-attachments/assets/cdabb3e4-0ebc-4ccd-aa24-538dea337956)

## Пример 

![image](https://github.com/user-attachments/assets/9dbc30c2-1991-48dd-a061-a0c30e2b1d72)

## Как использовать?

Разберем на примере монстра, который исчезает при касании его палкой.

### Шаг 1

Скачайте и импортируйте `ZoneTrigger.unitypackage`.

### Шаг 2 

Добавьте объекту любой подходящий коллайдер, установив у этого коллайдера флажок `Is Trigger`.

![Screenshot_45](https://github.com/user-attachments/assets/8ccd7c2f-e7be-47dc-86ac-25ae5fbfd112)


### Шаг 3

Создайте пустой `C# Script` или используйте уже имеющийся скрипт с названием `Tag_Weapon` по пути `Assets/_Arlycad/ZoneTrigger/Tags`. Скрипт пригодится для пометки предметов, на которые среагирует монстр (палка, меч, камень и т.п.).

![image](https://github.com/user-attachments/assets/8477a756-d461-4c9d-87d4-b5d7699ad483)

Перенесите его на интерактивный объект, а точнее на ту часть, у которой имеется коллайдер.

![image](https://github.com/user-attachments/assets/5719e005-6fc1-4be6-ad0f-403b395d291d)

### Шаг 4

Добавьте на монстра скрипт `ZoneTrigger.cs` (Находится в `Assets/_Arlycad/ZoneTrigger/`)

![image](https://github.com/user-attachments/assets/8c4b46c4-a3b7-400a-8787-c4f4393b3a7c)

Укажите скрипт, на который зона должна среагировать, нажав на кнопку у этого скрипта `Add Tag` и выбрав в выпадающем списке скрипт `Tag_Weapon`.

![image](https://github.com/user-attachments/assets/912e7e75-8369-4d90-894a-97cf581ec4cb)

### Шаг 5

Настройте событие, которое должно произойти при входе и/или выходе из зоны предмета(палки) в событиях `On Enter` и `On Exit`

![image](https://github.com/user-attachments/assets/0025c6ce-739f-4fb7-b675-fafa561a1215)

Например, перетащите объект монстра в `None (Object)` и укажите ему функцию исчезновения `No Function -> GameObject -> SetActive (bool)`. Галочка должна быть снята, чтобы объект исчез.

![image](https://github.com/user-attachments/assets/a211702e-a624-46b0-9214-7e32bcb261f5)

### Готово

Нажмите на `Play`. Возьмите палку и тыкните ей в триггерную зону монстра - он исчезнет. 
