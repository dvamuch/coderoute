
using CodeRoute.DAL.Repositories;

namespace CodeRoute.DAL
{
    public static class PresetsForContext 
    {
        public static void AddRoutePresets(this Context context)
        {
            context.Routes.Add(new Models.Route() { Title = "", Description = "", MarkDownPage = "" });
            context.Routes.Add(new Models.Route() { Title = "Frontend Разработчик", Description = "Специалист, отвечающий за создание пользовательского интерфейса сайта, приложения или ПО", MarkDownPage = "" });
            context.Routes.Add(new Models.Route() { Title = "Backend Разработчик", Description = "Программист, который пишет серверный код, отвечает за реакцию ресурса на действия пользователя и выдачу информации", MarkDownPage = "" });
            context.Routes.Add(new Models.Route() { Title = "DevOps инженер", Description = "Специалист, который синхронизирует этапы разработки программного продукта", MarkDownPage = "" });
        }

        public static void AddVertexPresets(this Context context)
        {
            context.Vertexes.Add(new Models.Vertex()
            {
                VertexId = 1,
                RouteId = 1,
                Name = "",
                MarkdownPage = ""
            });

            context.Vertexes.Add(new Models.Vertex()
            {
                VertexId = 2,
                RouteId = 2,
                Name = "Интернет",
                MarkdownPage = "<p class=\"lhMain\">Интернет - это глобальная сеть, которая объединяет огромное количество компьютеров по всему миру и дает возможность получения доступа к различным ресурсам и сервисам</p>\r\n<p class=\"lhMain\">Посетите следующие ресурсы, чтобы узнать больше:</p>\r\n<ul class=\"linkedList fn-accent\">\r\n  <li class=\"item\">\r\n    <a title=\"\" href=\"https://ru.wikipedia.org/wiki/Интернет\" class=\"link\">Интернет</a>\r\n  </li>\r\n  <li class=\"item\">\r\n    <a title=\"\" href=\"https://habr.com/ru/articles/709210/\" class=\"link\">Основы Интернета</a>\r\n  </li>\r\n</ul>"
            });

            context.Vertexes.Add(new Models.Vertex()
            {
                VertexId = 3,
                RouteId = 2,
                Name = "Как работает интернет?",
                MarkdownPage = "<p class=\"lhMain\">Интернет - это глобальная сеть компьютеров, соединенных друг с другом, которые взаимодействуют посредством стандартизированного набора протоколов.</p>\r\n<p class=\"lhMain\">Посетите следующие ресурсы, чтобы узнать больше:</p>\r\n<ul class=\"linkedList fn-accent\">\r\n  <li class=\"item\">\r\n    <a title=\"\" href=\"https://habr.com/ru/companies/ruvds/articles/720704/\" class=\"link\">Как работает Web</a>\r\n  </li>\r\n</ul>"
            });

            context.Vertexes.Add(new Models.Vertex()
            {
                VertexId = 4,
                RouteId = 2,
                Name = "Что такое HTTP?",
                MarkdownPage = "<p class=\"lhMain\">HTTP - это протокол связи прикладного уровня на основе TCP/IP, который стандартизирует взаимодействие клиента и сервера друг с другом. HTTP следует классической модели “Клиент-сервер”, когда клиент открывает запрос на подключение, а затем ожидает получения ответа. HTTP - это протокол без сохранения состояния, это означает, что сервер не сохраняет никаких данных (состояния) между двумя запросами.</p>\r\n<p class=\"lhMain\">Посетите следующие ресурсы, чтобы узнать больше:</p>\r\n<ul class=\"linkedList fn-accent\">\r\n  <li class=\"item\">\r\n    <a title=\"\" href=\"https://habr.com/ru/articles/215117/\" class=\"link\">Простым языком об HTTP</a>\r\n  </li>\r\n  <li class=\"item\">\r\n    <a title=\"\" href=\"https://proglib.io/p/chto-takoe-http-i-https-2021-03-22\" class=\"link\">Что такое HTTP и HTTPS?</a>\r\n  </li>\r\n</ul>"
            });

            context.Vertexes.Add(new Models.Vertex()
            {
                VertexId = 5,
                RouteId = 2,
                Name = "HTML",
                MarkdownPage = "<p class=\"lhMain\">HTML расшифровывается как язык гипертекстовой разметки. Он используется во внешнем интерфейсе и задает структуру веб-странице, которую вы можете стилизовать с помощью CSS и сделать интерактивной с помощью JavaScript.</p>\r\n<p class=\"lhMain\">Посетите следующие ресурсы, чтобы узнать больше:</p>\r\n<ul class=\"linkedList fn-accent\">\r\n  <li class=\"item\">\r\n    <a title=\"\" href=\"https://ru.wikipedia.org/wiki/HTML\" class=\"link\">HTML</a>\r\n  </li>\r\n</ul>"
            });

            context.Vertexes.Add(new Models.Vertex()
            {
                VertexId = 6,
                RouteId = 2,
                Name = "Основы",
                MarkdownPage = "<p class=\"lhMain\">HTML расшифровывается как язык гипертекстовой разметки. Он используется во внешнем интерфейсе и задает структуру веб-странице, которую вы можете стилизовать с помощью CSS и сделать интерактивной с помощью JavaScript.</p>\r\n<p class=\"lhMain\">Посетите следующие ресурсы, чтобы узнать больше:</p>\r\n<ul class=\"linkedList fn-accent\">\r\n  <li class=\"item\">\r\n    <a title=\"\" href=\"https://developer.mozilla.org/ru/docs/Learn/Getting_started_with_the_web/HTML_basics\" class=\"link\">Основы HTML</a>\r\n  </li>\r\n  <li class=\"item\">\r\n    <a title=\"\" href=\"https://practicum.yandex.ru/blog/zachem-nuzhen-html/\" class=\"link\">Что такое HTML</a>\r\n  </li>\r\n</ul>"
            });

            context.Vertexes.Add(new Models.Vertex()
            {
                VertexId = 7,
                RouteId = 2,
                Name = "Cемантическая верстка",
                MarkdownPage = "<p class=\"lhMain\">Семантический элемент четко описывает его значение как для браузера, так и для разработчика. В HTML семантический элемент - это тип элементов, которые могут использоваться для определения различных частей веб-страницы, таких как <form>, <table>, <article>, <header>, <footer>,и т.д.</p>\r\n<p class=\"lhMain\">Посетите следующие ресурсы, чтобы узнать больше:</p>\r\n<ul class=\"linkedList fn-accent\">\r\n  <li class=\"item\">\r\n    <a title=\"\" href=\"https://gist.github.com/semyonnaumov/b5a0631b2f34437f7928093c52fafa46\" class=\"link\">Краткий конспект по HTML</a>\r\n  </li>\r\n  <li class=\"item\">\r\n    <a title=\"\" href=\"https://html5book.ru/html-tags/\" class=\"link\">HTML-теги</a>\r\n  </li>\r\n</ul>"
            });

            context.Vertexes.Add(new Models.Vertex()
            {
                VertexId = 8,
                RouteId = 2,
                Name = "CSS",
                MarkdownPage = "<p class=\"lhMain\">CSS или каскадные таблицы стилей - это язык, используемый для оформления интерфейса любого веб-сайта. CSS является краеугольной технологией Всемирной паутины, наряду с HTML и JavaScript.</p>\r\n<p class=\"lhMain\">Посетите следующие ресурсы, чтобы узнать больше:</p>\r\n<ul class=\"linkedList fn-accent\">\r\n  <li class=\"item\">\r\n    <a title=\"\" href=\"https://ru.wikipedia.org/wiki/CSS\" class=\"link\">CSS </a>\r\n  </li>\r\n</ul>"
            });

            context.Vertexes.Add(new Models.Vertex()
            {
                VertexId = 9,
                RouteId = 2,
                Name = "Основы",
                MarkdownPage = "<p class=\"lhMain\">CSS или каскадные таблицы стилей - это язык, используемый для оформления интерфейса любого веб-сайта. CSS является краеугольной технологией Всемирной паутины, наряду с HTML и JavaScript.</p>\r\n<p class=\"lhMain\">Посетите следующие ресурсы, чтобы узнать больше:</p>\r\n<ul class=\"linkedList fn-accent\">\r\n  <li class=\"item\">\r\n    <a title=\"\" href=\"https://html5book.ru/osnovy-css/\" class=\"link\">Основы CSS</a>\r\n  </li>\r\n  <li class=\"item\">\r\n    <a title=\"\" href=\"https://practicum.yandex.ru/blog/chto-takoe-css/\" class=\"link\">CSS: что это</a>\r\n  </li>\r\n</ul>"
            });

            context.Vertexes.Add(new Models.Vertex()
            {
                VertexId = 10,
                RouteId = 2,
                Name = "Создание макетов",
                MarkdownPage = "<p class=\"lhMain\">Float, grid, flexbox, позиционирование, отображение и коробчатая модель - вот некоторые из ключевых тем, которые используются при создании макетов.</p>\r\n<p class=\"lhMain\">Посетите следующие ресурсы, чтобы узнать больше:</p>\r\n<ul class=\"linkedList fn-accent\">\r\n  <li class=\"item\">\r\n    <a title=\"\" href=\"https://htmlacademy.ru/blog/css/step-by-step\" class=\"link\">Как сверстать макет</a>\r\n  </li>\r\n  <li class=\"item\">\r\n    <a title=\"\" href=\"https://uroki-css.ru/\" class=\"link\">Уроки CSS</a>\r\n  </li>\r\n</ul>"
            });

            context.Vertexes.Add(new Models.Vertex()
            {
                VertexId = 11,
                RouteId = 2,
                Name = "Отзывчивый дизайн",
                MarkdownPage = "<p class=\"lhMain\">Адаптивный веб-дизайн - это метод, позволяющий вашим веб-страницам хорошо выглядеть на экранах любого размера. Для достижения этого используются определенные методы, например, медиазапросы CSS, процент ширины, минимальная или максимальная высота ширины и т.д.</p>\r\n<p class=\"lhMain\">Посетите следующие ресурсы, чтобы узнать больше:</p>\r\n<ul class=\"linkedList fn-accent\">\r\n  <li class=\"item\">\r\n    <a title=\"\" href=\"https://habr.com/ru/companies/ruvds/articles/718700/\" class=\"link\">Руководство по реализации отзывчивого дизайна</a>\r\n  </li>\r\n  <li class=\"item\">\r\n    <a title=\"\" href=\"https://html5book.ru/otzyvchivyj-dizayn-saita/\" class=\"link\">Отзывчивый дизайн сайта</a>\r\n  </li>\r\n</ul>"
            });

            context.Vertexes.Add(new Models.Vertex()
            {
                VertexId = 12,
                RouteId = 2,
                Name = "JavaScript",
                MarkdownPage = "<p class=\"lhMain\">JavaScript позволяет добавлять интерактивность вашим страницам. Распространенными примерами, которые вы, возможно, видели на веб-сайтах, являются ползунки, взаимодействия при нажатии, всплывающие окна и так далее.</p>\r\n<p class=\"lhMain\">Посетите следующие ресурсы, чтобы узнать больше:</p>\r\n<ul class=\"linkedList fn-accent\">\r\n  <li class=\"item\">\r\n    <a title=\"\" href=\"https://ru.wikipedia.org/wiki/JavaScript\" class=\"link\">JavaScript </a>\r\n  </li>\r\n</ul>"
            });

            context.Vertexes.Add(new Models.Vertex()
            {
                VertexId = 13,
                RouteId = 2,
                Name = "Основы",
                MarkdownPage = "<p class=\"lhMain\">JavaScript позволяет добавлять интерактивность вашим страницам. Распространенными примерами, которые вы, возможно, видели на веб-сайтах, являются ползунки, взаимодействия при нажатии, всплывающие окна и так далее.</p>\r\n<p class=\"lhMain\">Посетите следующие ресурсы, чтобы узнать больше:</p>\r\n<ul class=\"linkedList fn-accent\">\r\n  <li class=\"item\">\r\n    <a title=\"\" href=\"https://habr.com/ru/companies/ruvds/articles/416375/\" class=\"link\">Основы JavaScript</a>\r\n  </li>\r\n  <li class=\"item\">\r\n    <a title=\"\" href=\"https://html5book.ru/osnovy-javascript/\" class=\"link\">Основы JavaScript</a>\r\n  </li>\r\n</ul>"
            });

            context.Vertexes.Add(new Models.Vertex()
            {
                VertexId = 14,
                RouteId = 2,
                Name = "DOM",
                MarkdownPage = "<p class=\"lhMain\">Объектная модель документа (DOM) - это программный интерфейс, созданный для документов HTML и XML. Он представляет страницу, которая позволяет программам и скриптам динамически обновлять структуру, содержимое и стиль документа. С помощью DOM мы можем легко получать доступ к тегам, идентификаторам, классам, атрибутам и т.д. и манипулировать ими.</p>\r\n<p class=\"lhMain\">Посетите следующие ресурсы, чтобы узнать больше:</p>\r\n<ul class=\"linkedList fn-accent\">\r\n  <li class=\"item\">\r\n    <a title=\"\" href=\"https://habr.com/ru/articles/243815/\" class=\"link\">Выразительный JavaScript</a>\r\n  </li>\r\n  <li class=\"item\">\r\n    <a title=\"\" href=\"https://itchief.ru/javascript/dom\" class=\"link\">Что такое DOM и зачем он нужен</a>\r\n  </li>\r\n</ul>"
            });

            context.Vertexes.Add(new Models.Vertex()
            {
                VertexId = 15,
                RouteId = 2,
                Name = "Система контроля версий",
                MarkdownPage = "<p class=\"lhMain\">Системы контроля версий позволяют вам отслеживать изменения в вашей кодовой базе /файлах с течением времени. Они позволяют вам вернуться к какой-либо предыдущей версии кодовой базы без каких-либо проблем. Кроме того, они помогают в совместной работе с людьми, работающими над одним и тем же кодом – если вы когда-либо сотрудничали с другими людьми над проектом, вам, возможно, уже знакомо разочарование, связанное с копированием и объединением изменений, внесенных кем-то другим, в вашу кодовую базу; системы контроля версий позволяют вам избавиться от этой проблемы.</p>\r\n<p class=\"lhMain\">Посетите следующие ресурсы, чтобы узнать больше:</p>\r\n<ul class=\"linkedList fn-accent\">\r\n  <li class=\"item\">\r\n    <a title=\"\" href=\"https://www.atlassian.com/ru/git/tutorials/what-is-version-control#:\\~:text=Системы контроля версий — это,и увеличить количество успешных развертываний\" class=\"link\">Что такое контроль версий</a>\r\n  </li>\r\n  <li class=\"item\">\r\n    <a title=\"\" href=\"https://practicum.yandex.ru/blog/chto-takoe-git-i-dlya-chego-nuzhen/\" class=\"link\">Git: что это</a>\r\n  </li>\r\n  <li class=\"item\">\r\n    <a title=\"\" href=\"https://practicum.yandex.ru/blog/chto-takoe-github-kak-on-rabotaet/\" class=\"link\">Github: что это</a>\r\n  </li>\r\n  <li class=\"item\">\r\n    <a title=\"\" href=\"https://selectel.ru/blog/gitlab/\" class=\"link\">Gitlab: что это</a>\r\n  </li>\r\n</ul>"
            });

            context.Vertexes.Add(new Models.Vertex()
            {
                VertexId = 16,
                RouteId = 2,
                Name = "Системы управления пакетами",
                MarkdownPage = "<p class=\"lhMain\">Менеджеры пакетов позволяют вам управлять зависимостями (внешним кодом, написанным вами или кем-то другим), которые необходимы вашему проекту для корректной работы.</p>\r\n<p class=\"lhMain\">Посетите следующие ресурсы, чтобы узнать больше:</p>\r\n<ul class=\"linkedList fn-accent\">\r\n  <li class=\"item\">\r\n    <a title=\"\" href=\"https://www.atlassian.com/ru/git/tutorials/what-is-version-control#:\\~:text=Системы контроля версий — это,и увеличить количество успешных развертываний\" class=\"link\">Система управления пакетами</a>\r\n  </li>\r\n  <li class=\"item\">\r\n    <a title=\"\" href=\"https://ru.wikipedia.org/wiki/Система_управления_пакетами\" class=\"link\">Система управления пакетами</a>\r\n  </li>\r\n  <li class=\"item\">\r\n    <a title=\"\" href=\"https://thecode.media/package-management/\" class=\"link\">Что такое менеджер пакетов</a>\r\n  </li>\r\n</ul>"
            });

            context.Vertexes.Add(new Models.Vertex()
            {
                VertexId = 17,
                RouteId = 2,
                Name = "Выбор Framework",
                MarkdownPage = "<p class=\"lhMain\">Веб-фреймворки предназначены для написания веб-приложений. Фреймворки - это наборы библиотек, которые помогают в разработке программного продукта или веб-сайта. Фреймворки для разработки веб-приложений - это наборы различных инструментов. Фреймворки различаются по своим возможностям и функциям в зависимости от поставленных задач. Они определяют структуру, устанавливают правила и предоставляют необходимые инструменты разработки.</p>\r\n<p class=\"lhMain\">Посетите следующие ресурсы, чтобы узнать больше:</p>\r\n<ul class=\"linkedList fn-accent\">\r\n  <li class=\"item\">\r\n    <a title=\"\" href=\"https://habr.com/ru/articles/277547/\" class=\"link\">Как выбрать фреймворк для frontend-разработки</a>\r\n  </li>\r\n  <li class=\"item\">\r\n    <a title=\"\" href=\"https://skillbox.ru/media/code/chto-takoe-freymvork-i-kak-vybrat-freymvork-dlya-frontenda-sovety-byvalykh/\" class=\"link\">Фреймворк для фронтенда</a>\r\n  </li>\r\n  <li class=\"item\">\r\n    <a title=\"\" href=\"https://habr.com/ru/companies/yandex_praktikum/articles/587204/\" class=\"link\">Какой JS-фреймворк выбрать</a>\r\n  </li>\r\n</ul>"
            });

            context.Vertexes.Add(new Models.Vertex()
            {
                VertexId = 18,
                RouteId = 2,
                Name = "Написание CSS",
                MarkdownPage = "<p class=\"lhMain\">Способ, которым мы пишем CSS в наших современных интерфейсных приложениях, полностью отличается от того, как мы писали CSS раньше. Существуют такие методы, как стилизованные компоненты, CSS-модули, стилизованный JSX, Emotion и т.д</p>\r\n<p class=\"lhMain\">Посетите следующие ресурсы, чтобы узнать больше:</p>\r\n<ul class=\"linkedList fn-accent\">\r\n  <li class=\"item\">\r\n    <a title=\"\" href=\"https://www.w3.org/Style/Examples/011/firstcss.ru.html\" class=\"link\">Начинаем работу с HTML + CSS</a>\r\n  </li>\r\n  <li class=\"item\">\r\n    <a title=\"\" href=\"https://www.frontender.info/starting-css/\" class=\"link\">Начинаем писать CSS</a>\r\n  </li>\r\n</ul>"
            });

            context.Vertexes.Add(new Models.Vertex()
            {
                VertexId = 19,
                RouteId = 2,
                Name = "Архитектура CSS",
                MarkdownPage = "<p class=\"lhMain\">Общеизвестно, что CSS сложно управлять в больших, сложных, быстро повторяющихся системах. Существуют различные способы написания CSS, которые позволяют создавать более поддерживаемый CSS.</p>\r\n<p class=\"lhMain\">Посетите следующие ресурсы, чтобы узнать больше:</p>\r\n<ul class=\"linkedList fn-accent\">\r\n  <li class=\"item\">\r\n    <a title=\"\" href=\"https://web-standards.ru/articles/css-architecture/\" class=\"link\">Архитектура CSS</a>\r\n  </li>\r\n  <li class=\"item\">\r\n    <a title=\"\" href=\"https://webformyself.com/arxitektura-css-struktura-papok-i-fajlov/\" class=\"link\">Грамотное планирование архитектуры CSS</a>\r\n  </li>\r\n</ul>"
            });
        }

        public static void AddVertexConnectionsPresets(this Context context)
        {
            context.VertexConnections.Add(new Models.VertexConnection()
            {
                PreviousVertexId = 1,
                CurrentVertexId = 2,
            });

            context.VertexConnections.Add(new Models.VertexConnection()
            {
                PreviousVertexId = 3,
                CurrentVertexId = 2,
            });

            context.VertexConnections.Add(new Models.VertexConnection()
            {
                PreviousVertexId = 4,
                CurrentVertexId = 2,
            });

            context.VertexConnections.Add(new Models.VertexConnection()
            {
                PreviousVertexId = 2,
                CurrentVertexId = 5,
            });

            context.VertexConnections.Add(new Models.VertexConnection()
            {
                PreviousVertexId = 6,
                CurrentVertexId = 5,
            });

            context.VertexConnections.Add(new Models.VertexConnection()
            {
                PreviousVertexId = 7,
                CurrentVertexId = 5,
            });

            context.VertexConnections.Add(new Models.VertexConnection()
            {
                PreviousVertexId = 5,
                CurrentVertexId = 8,
            });

            context.VertexConnections.Add(new Models.VertexConnection()
            {
                PreviousVertexId = 9,
                CurrentVertexId = 8,
            });

            context.VertexConnections.Add(new Models.VertexConnection()
            {
                PreviousVertexId = 10,
                CurrentVertexId = 8,
            });

            context.VertexConnections.Add(new Models.VertexConnection()
            {
                PreviousVertexId = 11,
                CurrentVertexId = 8,
            });

            context.VertexConnections.Add(new Models.VertexConnection()
            {
                PreviousVertexId = 8,
                CurrentVertexId = 12,
            });

            context.VertexConnections.Add(new Models.VertexConnection()
            {
                PreviousVertexId = 13,
                CurrentVertexId = 12,
            });

            context.VertexConnections.Add(new Models.VertexConnection()
            {
                PreviousVertexId = 14,
                CurrentVertexId = 12,
            });

            context.VertexConnections.Add(new Models.VertexConnection()
            {
                PreviousVertexId = 12,
                CurrentVertexId = 15,
            });

            context.VertexConnections.Add(new Models.VertexConnection()
            {
                PreviousVertexId = 15,
                CurrentVertexId = 16,
            });

            context.VertexConnections.Add(new Models.VertexConnection()
            {
                PreviousVertexId = 16,
                CurrentVertexId = 17,
            });

            context.VertexConnections.Add(new Models.VertexConnection()
            {
                PreviousVertexId = 17,
                CurrentVertexId = 18,
            });

            context.VertexConnections.Add(new Models.VertexConnection()
            {
                PreviousVertexId = 18,
                CurrentVertexId = 19,
            });
        }

        public static void AddRouteStatusPresets(this Context context)
        {
            context.RouteStatuses.Add(new Models.RouteStatus()
            {
                RouteStatusId = 1,
                StatusName = "Не начат"
            });

            context.RouteStatuses.Add(new Models.RouteStatus()
            {
                RouteStatusId = 2,
                StatusName = "В процессе"
            });

            context.RouteStatuses.Add(new Models.RouteStatus()
            {
                RouteStatusId = 3,
                StatusName = "Закончен"
            });
        }

        public static void AddVertexStatusPresets(this Context context)
        {
            context.VertexStatuses.Add(new Models.VertexStatus()
            {
                StatusId = 1,
                StatusName = "Не изучено"
            });

            context.VertexStatuses.Add(new Models.VertexStatus()
            {
                StatusId = 2,
                StatusName = "Пропустил"
            });

            context.VertexStatuses.Add(new Models.VertexStatus()
            {
                StatusId = 3,
                StatusName = "В процессе"
            });

            context.VertexStatuses.Add(new Models.VertexStatus()
            {
                StatusId = 4,
                StatusName = "Изучил"
            });
        }
    }
}
