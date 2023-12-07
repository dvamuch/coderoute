import {useAuthorizationStore} from "@/stores/authorization";
import {defineStore} from "pinia";
import {computed, ref} from "vue";

export const useNodesStore = defineStore("nodes", () => {
  const nodeList = ref([]);
  const roadmapInfo = ref({});
  const roadmapProgress = ref({});
  const nodeObjects = ref({});
  const isFetched = ref(false);
  const fetchedRoadmapId = ref(-1);
  const authorizationStore = useAuthorizationStore();
  const isAuthorized = computed(() => authorizationStore.isAuthorized);
  const jwtToken = computed(() => authorizationStore.jwtToken);

  const fetchRoadmap = async (roadmapId) => {
    if (isFetched.value && roadmapId === fetchedRoadmapId.value) {
      return;
    }

    const options = {};

    console.log(1, jwtToken.value, isAuthorized.value);
    if (isAuthorized.value) {
      options.headers = {
        Authorization: `Bearer ${jwtToken.value}`,
      };
      console.log(2, jwtToken.value);
    }

    const result = await (await fetch(`http://${process.env.VUE_APP_BACKEND_HOST}/api/v1/Routes/${roadmapId}`, options)).json();
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
