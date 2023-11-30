
namespace CodeRoute.DAL
{
    public static class PresetsForContext 
    {
        public static void AddRoutePresets(this Context context)
        {
            context.Routes.Add(new Models.Route() { Title = "", Desctiption = "", MarkDownPage = "" });
            context.Routes.Add(new Models.Route() { Title = "Frontend Разработчик", Desctiption = "Специалист, отвечающий за создание пользовательского интерфейса сайта, приложения или ПО", MarkDownPage = "" });
            context.Routes.Add(new Models.Route() { Title = "Backend Разработчик", Desctiption = "Программист, который пишет серверный код, отвечает за реакцию ресурса на действия пользователя и выдачу информации", MarkDownPage = "" });
            context.Routes.Add(new Models.Route() { Title = "DevOps инженер", Desctiption = "Специалист, который синхронизирует этапы разработки программного продукта", MarkDownPage = "" });
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
                MarkdownPage = "Интернет является основой сети (the Web), технической инфраструктурой, благодаря которой и существует Всемирная Паутина. По своей сути, интернет - очень большая сеть компьютеров, которые могут взаимодействовать друг с другом."
            });

            context.Vertexes.Add(new Models.Vertex()
            {
                VertexId = 4,
                RouteId = 2,
                Name = "Что такое HTTP?",
                MarkdownPage = "HTTP — протокол прикладного уровня передачи данных, изначально — в виде гипертекстовых документов в формате HTML, в настоящее время используется для передачи произвольных данных."
            });

            context.Vertexes.Add(new Models.Vertex()
            {
                VertexId = 5,
                RouteId = 2,
                Name = "HTML",
                MarkdownPage = ""
            });

            context.Vertexes.Add(new Models.Vertex()
            {
                VertexId = 6,
                RouteId = 2,
                Name = "Основы",
                MarkdownPage = ""
            });

            context.Vertexes.Add(new Models.Vertex()
            {
                VertexId = 7,
                RouteId = 2,
                Name = "Cемантическая верстка",
                MarkdownPage = ""
            });

            context.Vertexes.Add(new Models.Vertex()
            {
                VertexId = 8,
                RouteId = 2,
                Name = "CSS",
                MarkdownPage = ""
            });

            context.Vertexes.Add(new Models.Vertex()
            {
                VertexId = 9,
                RouteId = 2,
                Name = "Основы",
                MarkdownPage = ""
            });

            context.Vertexes.Add(new Models.Vertex()
            {
                VertexId = 10,
                RouteId = 2,
                Name = "JavaScript",
                MarkdownPage = ""
            });

            context.Vertexes.Add(new Models.Vertex()
            {
                VertexId = 11,
                RouteId = 2,
                Name = "Основы",
                MarkdownPage = ""
            });

            context.Vertexes.Add(new Models.Vertex()
            {
                VertexId = 12,
                RouteId = 2,
                Name = "Системы контроля версий",
                MarkdownPage = ""
            });

            context.Vertexes.Add(new Models.Vertex()
            {
                VertexId = 13,
                RouteId = 2,
                Name = "Системы управления пакетами",
                MarkdownPage = ""
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
                PreviousVertexId = 8,
                CurrentVertexId = 10,
            });

            context.VertexConnections.Add(new Models.VertexConnection()
            {
                PreviousVertexId = 11,
                CurrentVertexId = 10,
            });

            context.VertexConnections.Add(new Models.VertexConnection()
            {
                PreviousVertexId = 10,
                CurrentVertexId = 12,
            });

            context.VertexConnections.Add(new Models.VertexConnection()
            {
                PreviousVertexId = 12,
                CurrentVertexId = 13,
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
