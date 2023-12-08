
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
                MarkdownPage = "Интернет — это глобальная сеть, которая объединяет огромное количество компьютеров по всему земному шару и дает возможность получения доступа к информационным ресурсам."
            });

            context.Vertexes.Add(new Models.Vertex()
            {
                VertexId = 3,
                RouteId = 2,
                Name = "Как работает интернет?",
                MarkdownPage = "Интернет - это глобальная сеть компьютеров, соединенных друг с другом, которые взаимодействуют посредством стандартизированного набора протоколов."
            });

            context.Vertexes.Add(new Models.Vertex()
            {
                VertexId = 4,
                RouteId = 2,
                Name = "Что такое HTTP?",
                MarkdownPage = "HTTP - это протокол связи прикладного уровня на основе TCP/IP, который стандартизирует взаимодействие клиента и сервера друг с другом. HTTP следует классической модели “Клиент-сервер”, когда клиент открывает запрос на подключение, а затем ожидает получения ответа. HTTP - это протокол без сохранения состояния, это означает, что сервер не сохраняет никаких данных (состояния) между двумя запросами."
            });

            context.Vertexes.Add(new Models.Vertex()
            {
                VertexId = 5,
                RouteId = 2,
                Name = "HTML",
                MarkdownPage = "HTML расшифровывается как язык гипертекстовой разметки. Он используется во внешнем интерфейсе и задает структуру веб-странице, которую вы можете стилизовать с помощью CSS и сделать интерактивной с помощью JavaScript."
            });

            context.Vertexes.Add(new Models.Vertex()
            {
                VertexId = 6,
                RouteId = 2,
                Name = "Основы",
                MarkdownPage = "HTML расшифровывается как язык гипертекстовой разметки. Он используется во внешнем интерфейсе и задает структуру веб-странице, которую вы можете стилизовать с помощью CSS и сделать интерактивной с помощью JavaScript."
            });

            context.Vertexes.Add(new Models.Vertex()
            {
                VertexId = 7,
                RouteId = 2,
                Name = "Cемантическая верстка",
                MarkdownPage = "Семантический элемент четко описывает его значение как для браузера, так и для разработчика. В HTML семантический элемент - это тип элементов, которые могут использоваться для определения различных частей веб-страницы, таких как <form>, <table>, <article>, <header>, <footer>,и т.д."
            });

            context.Vertexes.Add(new Models.Vertex()
            {
                VertexId = 8,
                RouteId = 2,
                Name = "CSS",
                MarkdownPage = "CSS или каскадные таблицы стилей - это язык, используемый для оформления интерфейса любого веб-сайта. CSS является краеугольной технологией Всемирной паутины, наряду с HTML и JavaScript."
            });

            context.Vertexes.Add(new Models.Vertex()
            {
                VertexId = 9,
                RouteId = 2,
                Name = "Основы",
                MarkdownPage = "CSS или каскадные таблицы стилей - это язык, используемый для оформления интерфейса любого веб-сайта. CSS является краеугольной технологией Всемирной паутины, наряду с HTML и JavaScript."
            });

            context.Vertexes.Add(new Models.Vertex()
            {
                VertexId = 10,
                RouteId = 2,
                Name = "Создание макетов",
                MarkdownPage = "Float, grid, flexbox, позиционирование, отображение и коробчатая модель - вот некоторые из ключевых тем, которые используются при создании макетов."
            });

            context.Vertexes.Add(new Models.Vertex()
            {
                VertexId = 11,
                RouteId = 2,
                Name = "Отзывчивый дизайн",
                MarkdownPage = "Адаптивный веб-дизайн - это метод, позволяющий вашим веб-страницам хорошо выглядеть на экранах любого размера. Для достижения этого используются определенные методы, например, медиазапросы CSS, процент ширины, минимальная или максимальная высота ширины и т.д."
            });

            context.Vertexes.Add(new Models.Vertex()
            {
                VertexId = 12,
                RouteId = 2,
                Name = "JavaScript",
                MarkdownPage = "JavaScript позволяет добавлять интерактивность вашим страницам. Распространенными примерами, которые вы, возможно, видели на веб-сайтах, являются ползунки, взаимодействия при нажатии, всплывающие окна и так далее."
            });

            context.Vertexes.Add(new Models.Vertex()
            {
                VertexId = 13,
                RouteId = 2,
                Name = "Основы",
                MarkdownPage = "JavaScript позволяет добавлять интерактивность вашим страницам. Распространенными примерами, которые вы, возможно, видели на веб-сайтах, являются ползунки, взаимодействия при нажатии, всплывающие окна и так далее."
            });

            context.Vertexes.Add(new Models.Vertex()
            {
                VertexId = 14,
                RouteId = 2,
                Name = "DOM",
                MarkdownPage = "Объектная модель документа (DOM) - это программный интерфейс, созданный для документов HTML и XML. Он представляет страницу, которая позволяет программам и скриптам динамически обновлять структуру, содержимое и стиль документа. С помощью DOM мы можем легко получать доступ к тегам, идентификаторам, классам, атрибутам и т.д. и манипулировать ими."
            });

            context.Vertexes.Add(new Models.Vertex()
            {
                VertexId = 15,
                RouteId = 2,
                Name = "Система контроля версий",
                MarkdownPage = "Системы контроля версий позволяют вам отслеживать изменения в вашей кодовой базе /файлах с течением времени. Они позволяют вам вернуться к какой-либо предыдущей версии кодовой базы без каких-либо проблем. Кроме того, они помогают в совместной работе с людьми, работающими над одним и тем же кодом – если вы когда-либо сотрудничали с другими людьми над проектом, вам, возможно, уже знакомо разочарование, связанное с копированием и объединением изменений, внесенных кем-то другим, в вашу кодовую базу; системы контроля версий позволяют вам избавиться от этой проблемы."
            });

            context.Vertexes.Add(new Models.Vertex()
            {
                VertexId = 16,
                RouteId = 2,
                Name = "Системы управления пакетами",
                MarkdownPage = "Менеджеры пакетов позволяют вам управлять зависимостями (внешним кодом, написанным вами или кем-то другим), которые необходимы вашему проекту для корректной работы."
            });

            context.Vertexes.Add(new Models.Vertex()
            {
                VertexId = 17,
                RouteId = 2,
                Name = "Выбор Framework",
                MarkdownPage = "Веб-фреймворки предназначены для написания веб-приложений. Фреймворки - это наборы библиотек, которые помогают в разработке программного продукта или веб-сайта. Фреймворки для разработки веб-приложений - это наборы различных инструментов. Фреймворки различаются по своим возможностям и функциям в зависимости от поставленных задач. Они определяют структуру, устанавливают правила и предоставляют необходимые инструменты разработки."
            });

            context.Vertexes.Add(new Models.Vertex()
            {
                VertexId = 18,
                RouteId = 2,
                Name = "Написание CSS",
                MarkdownPage = "Способ, которым мы пишем CSS в наших современных интерфейсных приложениях, полностью отличается от того, как мы писали CSS раньше. Существуют такие методы, как стилизованные компоненты, CSS-модули, стилизованный JSX, Emotion и т.д"
            });

            context.Vertexes.Add(new Models.Vertex()
            {
                VertexId = 19,
                RouteId = 2,
                Name = "Архитектура CSS",
                MarkdownPage = "Общеизвестно, что CSS сложно управлять в больших, сложных, быстро повторяющихся системах. Существуют различные способы написания CSS, которые позволяют создавать более поддерживаемый CSS."
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
