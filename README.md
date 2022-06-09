# Модуль "Accounts"
### 1. [Описание модуля](#module)
### 2. [Используемые технологии и библиотеки](#code)
### 3. [Фронтенд-реализация](#front)
### 4. [Инструкция по запуску](#instruction)
### 5. [Прочее](#credits)
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

### Личный кабинет (в разработке):

### Страница регистрации (в разработке):

### Страница авторизации (в разработке):

### Список чатов пользователя (в разработке):

## Instruction



## Credits

### Текущий [Список задач](https://github.com/team-5-tutor-project/team-5-account/issues):

### Team-lead
[<img src="https://avatars.githubusercontent.com/u/62665587?v=4" width="100px;"/><br /><sub><b>Михаил Руковишников</b></sub>](https://github.com/kawwik)<br />
### Team
[<img src="https://avatars.githubusercontent.com/u/79146846?v=4" width="100px;"/><br /><sub><b>Илья Корехов</b></sub>](https://github.com/kroexov)<br /> 

[<img src="https://avatars.githubusercontent.com/u/70719055?v=4" width="100px;"/><br /><sub><b>Баир Энкеев</b></sub>](https://github.com/deworldgreen)<br />
