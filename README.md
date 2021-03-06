# Модуль "Accounts"
### 1. [Описание модуля](#module)
### 2. [Используемые технологии и библиотеки](#code)
### 3. [Фронтенд-реализация](#front)
### 4. [Инструкция по запуску](#instruction)
### 5. [Исправление взаимодействия бека и фронта](#debug)
### 6. [Прочее](#credits)
## Module
### В составе общего [проекта](https://github.com/team-5-tutor-project) модуль выполняет следующие функции:

- **Регистрация** и **авторизация** клиентов и репетиторов.
- Предоставление доступа к **личному кабинету** и **списку чатов** пользователя.
- Возможность редактировать свои данные в **личном кабинете**

### Модуль связан с другими модулями следующим образом:
- С [Поисковиком](https://github.com/team-5-tutor-project/team-5-searcher) у модуля общая база данных, общие модели данных, также с **Поисковика** возвращается ID созданного чата
- С [Мессенджером](https://github.com/team-5-tutor-project/team-5-messenger) модуль взаимодействует во время запроса ссылки на чат по имеющемуся ID.

### 

### Текущая модель данных для БД:
<img src="https://media.discordapp.net/attachments/973629450258374716/978036039425859584/unknown.png">

## Code

### Backend

- Реализован http-сервер с помощью библиотеки **Microsoft.AspNetCore.Mvc**
- Подключение к базе данных и конфигурация осуществляются на базе библиотеки **Microsoft.Extensions.Configuration**
- Используется **Swagger** для тестирования реализуемых методов и взаимодействия с БД
- Используется **Mapper** для работы с DTO

### Frontend

- Используется Blazor
- Всё взаимодейвствие с другими модулями организуется через Redirect

## Front

### Посмотреть реализацию проекта можно по [ссылке]()

### Основная страница:

![FireShot Capture 404 - Index - tutor-project-account herokuapp com](https://user-images.githubusercontent.com/79146846/175837740-7298516b-c885-4355-abba-797d636a2f1f.png)

### Страница регистрации:

![image](https://user-images.githubusercontent.com/79146846/175837781-f37e7428-9bc1-4ce1-b0ee-489cf4cf1437.png)

### Страница авторизации:

![image](https://user-images.githubusercontent.com/79146846/175837769-614714da-cbe7-408a-9758-d81406d192df.png)

### Личный кабинет репетитора:

![image](https://user-images.githubusercontent.com/79146846/175837841-d930344f-e4a4-4ef4-9d92-0c687430d106.png)

### Личный кабинет клиента:

![image](https://user-images.githubusercontent.com/79146846/175837818-df520847-4107-4557-a477-e327ca568c8b.png)

### Список чатов пользователя:

![image](https://user-images.githubusercontent.com/79146846/175837855-b8da8ef1-8170-44b2-afa2-85071783097e.png)

## Instruction

### Запуск и тестирование

### Шаг 1. Запустите бек (модуль \team-5-account\Back). В открывшемся Swagger-интерфейсе можно поработать с данными в БД, но в общем это нужно лишь для активации сервера

### Так выглядит корректно запущенный бек:
![image](https://user-images.githubusercontent.com/79146846/173901161-d895405a-87f6-470c-b32f-cb520174ded1.png)

### Шаг 2. Запустите фронт (модуль \team-5-account\Front).

### Так выглядит корректно запущенный фронт:

![image](https://user-images.githubusercontent.com/79146846/175837884-b82a026c-7471-4b25-8c02-98a92d825b48.png)

### Шаг 3. Модуль "Аккаунт" запущен, можно работать. Well done!

## Debug

### Из-за политики [CORS](https://metanit.com/sharp/aspnet5/31.1.php) взаимодействие между двумя localhost-адресами будет затруднено. Чинится это, например, [так](https://stackoverflow.com/questions/48285408/how-to-disable-cors-completely-in-webapi)

### Пример исправления (файл Startup.cs в проекте TutorProject.Account.Web), котоое позволяет подключаться к серверу с любого адреса и игнорировать CORS:

![image](https://user-images.githubusercontent.com/79146846/173897319-1c444231-5762-4e49-939d-b04c81a0eb1b.png)

### Далее потребуется сформировать корректный запрос к серверу, для чего смотрим формат запроса в Swagger:
![image](https://user-images.githubusercontent.com/79146846/173898071-4635146d-c888-4eab-88bf-77f707568517.png)
### Проверяем, есть ли в БД необходимые нам данные (в данном случае чат):
![image](https://user-images.githubusercontent.com/79146846/173900710-33133c96-96b8-4a89-9552-9bdb94e5bf63.png)
### Преобразуем увиденное в запрос:
![image](https://user-images.githubusercontent.com/79146846/173898103-3c6365a3-453e-4076-ae44-38888a17e133.png)
### И получаем конечный результат (да, я именно это и хотел получить XD): 
![image](https://user-images.githubusercontent.com/79146846/173900504-f9835833-8a35-40ab-9d85-6182c7ee3dbf.png)





## Credits

### Текущий [Список задач](https://github.com/team-5-tutor-project/team-5-account/issues):

### Team-lead
[<img src="https://avatars.githubusercontent.com/u/62665587?v=4" width="100px;"/><br /><sub><b>Михаил Руковишников</b></sub>](https://github.com/kawwik)<br />
### Team
[<img src="https://avatars.githubusercontent.com/u/79146846?v=4" width="100px;"/><br /><sub><b>Илья Корехов</b></sub>](https://github.com/kroexov)<br /> 

[<img src="https://avatars.githubusercontent.com/u/70719055?v=4" width="100px;"/><br /><sub><b>Баир Энкеев</b></sub>](https://github.com/deworldgreen)<br />
