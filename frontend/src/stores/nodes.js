import {useAuthorizationStore} from "@/stores/authorization";
import userFetcher from "@/use/fetcher";
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
  const fetcher = userFetcher();
  const isAuthorized = computed(() => authorizationStore.isAuthorized);
  const jwtToken = computed(() => authorizationStore.jwtToken);

  const fetchRoadmap = async (roadmapId) => {
    if (isFetched.value && roadmapId === fetchedRoadmapId.value) {
      return;
    }

    const options = {};


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

  const updateStatus = async (nodeId, statusId) => {
    const options = {
      method: "POST",
    };
    await (await fetch(`http://${process.env.VUE_APP_BACKEND_HOST}/api/v1/Vertex/${nodeId}/${statusId}`, options)).json();
  };

  return {nodeList, roadmapInfo, roadmapProgress, nodeObjects, fetchRoadmap, fetchNode};
});
