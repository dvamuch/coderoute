import userFetcher from "@/use/fetcher";
import {defineStore} from "pinia";
import {ref} from "vue";

export const useNodesStore = defineStore("nodes", () => {
  const nodeList = ref([]);
  const roadmapInfo = ref({});
  const roadmapProgress = ref({});
  const nodeObjects = ref({});
  const isFetched = ref(false);
  const fetchedRoadmapId = ref(-1);
  const fetcher = userFetcher();
  const fetchRoadmap = async (roadmapId) => {
    if (isFetched.value && roadmapId === fetchedRoadmapId.value) {
      return;
    }

    const result = await fetcher.fetchJson(`http://${process.env.VUE_APP_BACKEND_HOST}/api/v1/Routes/${roadmapId}`);
    nodeList.value = result.nodes;
    roadmapInfo.value = result.roadmap;
    roadmapProgress.value = result.progress;
    isFetched.value = true;
    fetchedRoadmapId.value = roadmapId;
  };

  const fetchNode = async (nodeId) => {
    if (nodeObjects.value[nodeId]) {
      return;
    }
    nodeObjects.value[nodeId] = await fetcher.fetchJson(`http://${process.env.VUE_APP_BACKEND_HOST}/api/v1/Vertex/${nodeId}`);
  };

  const updateStatus = async (parentNodeId, nodeId, statusId) => {
    const options = {
      method: "POST",
    };
    nodeObjects.value[nodeId].statusId = statusId;

    await fetcher.myFetch(`http://${process.env.VUE_APP_BACKEND_HOST}/api/v1/UserVertex/${nodeId}/${statusId}`, options);

    if (parentNodeId) {
      const parentNodeIndex = nodeList.value.findIndex((element) => element.id === parentNodeId);
      const nodeIndex = nodeList.value[parentNodeIndex].secondaryNodes.findIndex((element) => element.id === nodeId);
      nodeList.value[parentNodeIndex].secondaryNodes[nodeIndex].statusId = statusId;
    } else {
      const nodeIndex = nodeList.value.findIndex((element) => element.id === nodeId);
      nodeList.value[nodeIndex].statusId = statusId;
    }
  };

  return {nodeList, roadmapInfo, roadmapProgress, nodeObjects, fetchRoadmap, fetchNode, updateStatus};
});
