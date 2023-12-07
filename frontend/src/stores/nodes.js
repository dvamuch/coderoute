import {useAuthorizationStore} from "@/stores/authorization";
import {defineStore} from "pinia";
import {ref} from "vue";

export const useNodesStore = defineStore("nodes", () => {
  const nodeList = ref([]);
  const roadmapInfo = ref({});
  const roadmapProgress = ref({});
  const nodeObjects = ref({});
  const isFetched = ref(false);
  const fetchedRoadmapId = ref(-1);
  const authorizationStore = useAuthorizationStore();

  const fetchRoadmap = async (roadmapId) => {
    if (isFetched.value && roadmapId === fetchedRoadmapId.value) {
      return;
    }

    const options = {};

    if (authorizationStore.isAuthorized) {
      options.headers = {
        Authentication: `Bearer ${authorizationStore.jwtToken}`,
      };
    }

    const result = await (await fetch(`http://${process.env.VUE_APP_BACKEND_HOST}/api/v1/Routes/${roadmapId}`)).json();
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
    nodeObjects.value[nodeId] = await (await fetch(`http://${process.env.VUE_APP_BACKEND_HOST}/api/v1/Vertex/${nodeId}`)).json();
  };

  const updateStatus = async (nodeId, statusId) => {
    const options = {
      method: "POST",
    };
    await (await fetch(`http://${process.env.VUE_APP_BACKEND_HOST}/api/v1/Vertex/${nodeId}/${statusId}`, options)).json();
  };

  return {nodeList, roadmapInfo, roadmapProgress, nodeObjects, fetchRoadmap, fetchNode};
});
