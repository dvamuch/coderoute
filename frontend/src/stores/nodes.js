import {defineStore} from "pinia";
import {ref} from "vue";

export const useNodesStore = defineStore("nodes", () => {
  const nodeList = ref([]);
  const roadmapInfo = ref({});
  const roadmapProgress = ref({});
  const nodeObjects = ref({});
  const isFetched = ref(false);
  const fetchedRoadmapId = ref(-1);

  const fetchRoadmap = async (roadmapId) => {
    if (isFetched.value && roadmapId === fetchedRoadmapId.value) {
      return;
    }
    const result = await (await fetch(`http://${process.env.VUE_APP_BACKEND_HOST}/Routes/${roadmapId}`)).json();
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
    console.log("kal");
    nodeObjects.value[nodeId] = await (await fetch(`http://${process.env.VUE_APP_BACKEND_HOST}/Vertex/${nodeId}`)).json();
  };

  return {nodeList, roadmapInfo, roadmapProgress, nodeObjects, fetchRoadmap, fetchNode};
});
