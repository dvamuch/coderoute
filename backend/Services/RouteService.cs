using CodeRoute.DAL.Repositories;
using CodeRoute.DTO;
using CodeRoute.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace CodeRoute.Services
{
    public class RouteService
    {
        private static readonly int specialValue = 1;

        private readonly RouteRepository _routeRepository;
        private readonly VertexRepository _vertexRepository;
        public RouteService(RouteRepository routeRepository, VertexRepository vertexRepository) 
        {
            _routeRepository = routeRepository;
            _vertexRepository = vertexRepository;
        }

        public async Task<List<Roadmap>> GetRoutes(int userId) 
        {
            var routes = await _routeRepository.GetAllRoutes();
            var maps = new List<Roadmap>();

            foreach (var route in routes)
            {
                maps.Add(new Roadmap()
                {
                    RouteId = route.RouteId,
                    Description = route.Desctiption,
                    Title = route.Title,
                    StatusId = (await _routeRepository.GetStatusIdByIds(route.RouteId, userId))
                });

                var vertices = await _vertexRepository.GetAllVertexFromRoute(route.RouteId, userId);
                int started = 0;
                foreach (var vertex in vertices)
                {
                    if (vertex.StatusId != 1)
                    {
                        started++;
                    }
                }

                if (vertices.Count > 0)
                {
                    float a = started * 100.0f / vertices.Count();
                    maps[maps.Count - 1].Percentage = Convert.ToInt32(a);
                }
                else
                {
                    maps[maps.Count - 1].Percentage = 0;
                }
            }

            return maps;
        }

        public async Task<List<Models.RouteStatus>> GetStatuses()
        {
            var result = await _routeRepository.GetStatuses();
            return result;
        }

        public async Task<bool> ChangeStatus(int routeId, int statusId, int userId)
        {
            if (userId == specialValue) // user with id = 1 is special and he should not change statuses
            {
                return false;
            }

            var result = await _routeRepository.ChangeRouteStatus(routeId, statusId, userId);
            return result;
        }

        internal async Task<bool> AddRoute(Roadmap roadmap)
        {
            Models.Route route = new Models.Route()
            {
                Title = roadmap.Title,
                Desctiption = roadmap.Description,
                MarkDownPage = ""
            };

            return await _routeRepository.AddRoute(route);
        }

        internal async Task<RouteInfo> GetRouteByIdForUser(int routId, int userId)
        {
            Models.Route route = await _routeRepository.GetRouteById(routId);

            if (route == null) return null;

            Roadmap map = new Roadmap()
            {
                Title = route.Title,
                Description = route.Desctiption,
                StatusId = await _routeRepository.GetRouteStatusById(routId, userId)
            };

            var vertices = await _vertexRepository.GetAllVertexFromRoute(routId, userId);
            if (vertices.Count() == 0)
                return null;

            var connections = await _vertexRepository.GetAllVertexConnectionsInRoute(routId);

            var nodes = GetNodeList(vertices, connections);

            RoadmapProgress progress = CalcProgress(nodes);

            RouteInfo info = new RouteInfo()
            {
                Roadmap = map,
                Nodes = nodes,
                Progress = progress,
            };

            return info;
        }

        private List<Node> GetNodeList(List<UserVertex> vertices, List<VertexConnection> connections)
        {
            var mainAxisIds = connections.Select(c => c.CurrentVertexId).Distinct().ToList();
            var mainAxis = connections.Select(c => c.CurrentVertex).Distinct().ToList();

            List<Node> nodes = new List<Node>();

            foreach (var vertex in mainAxis)
            {
                Node node = NodeFromVertex(vertex, vertices);

                node.SecondaryNodes = new List<Node>();

                var prevVertices = connections
                    .Where(c => c.CurrentVertexId == vertex.VertexId && 
                                !mainAxisIds.Contains(c.PreviousVertexId) && 
                                c.PreviousVertexId != specialValue)
                    .Select(c => c.PreviousVertex);

                foreach (var vert in prevVertices)
                {
                    node.SecondaryNodes.Add(NodeFromVertex(vert, vertices));
                }

                nodes.Add(node);
            }

            return nodes;
        }

        private Node NodeFromVertex(Vertex vertex, List<UserVertex> userStatuses)
        {
            Node node = new Node()
            {
                Id = vertex.VertexId,
                Title = vertex.Name,
                StatusId = userStatuses.FirstOrDefault(uv => uv.VertexId == vertex.VertexId).Status.StatusId,
            };

            return node;
        }

        private RoadmapProgress CalcProgress(List<Node> nodes)
        {
            RoadmapProgress progress = new RoadmapProgress();

            if (nodes == null) return progress;

            foreach (var node in nodes)
            {
                if (node.StatusId == 2) progress.Skipped++;
                if (node.StatusId == 3) progress.InProgress++;
                if (node.StatusId == 4) progress.Finished++;
                progress.Total++;

                RoadmapProgress secondaryProg = CalcProgress(node.SecondaryNodes);

                progress.InProgress += secondaryProg.InProgress;
                progress.Skipped += secondaryProg.Skipped;
                progress.Finished += secondaryProg.Finished;
                progress.Total += secondaryProg.Total;
            }

            if (progress.Total != 0)
            {
                var res = (progress.Finished + progress.Skipped) * 100.0f / progress.Total;
                progress.Percent = Convert.ToInt32(res);
            }

            return progress;
        }
    }
}
